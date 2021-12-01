using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CloudData
{

public Vector3 pos;

public Vector3 scale;

public Quaternion rot;

private bool _isActive;

//Verhindert andere Klassen vom veraendern der isActive Variable

public bool isActive
    {
     get
        {
            return _isActive;
        }

    }

    public int x;

    public int y;

    public float distFromCam;


//returns die Matrix der Wolken

public Matrix4x4 matrix
    {
        get
        {
            return Matrix4x4.TRS(pos, rot, scale);
        }
    }

    //fuer das instanzieren der Wolken

    public CloudData(Vector3 pos, Vector3 scale, Quaternion rot, int x, int y, float distFromCam)
    {
        this.pos = pos;
        this.scale = scale;
        this.rot = rot;
        SetActive(true);
        this.x = x;
        this.y = y;
        this.distFromCam = distFromCam;
    }


    //setzen der isActive

    public void SetActive(bool desState)
    {
        _isActive = desState;
    }




}

public class CloudController : MonoBehaviour
{
    //Meshes

    public Mesh cloudMesh;

    public Material cloudMat;

    //Cloud Data

    public float cloudSize = 5;

    public float maxScale = 1;

    //Noise Generation

    public float timeScale = 1;

    public float texScale = 1;

    //Cloud Scaling Info 

    public float minNoiseSize = 0.5f;

    public float sizeScale = 0.25f;

    //Culling Data

    public Camera cam;

    public int maxDist;

    //Number of Batches

    public int batchesToCreate;

    //private Stuff

    private Vector3 prevCamPos;

    private float offsetX = 1;

    private float offsetY = 1;

    private List<List<CloudData>> batches = new List<List<CloudData>>();

    private List<List<CloudData>> batchesToUpdate = new List<List<CloudData>>();

    private void Start()
    {
     for(int batchesX = 0; batchesX < batchesToCreate; batchesX++)
        {
            for(int batchesY = 0; batchesY < batchesToCreate; batchesY++)
            {
                BuildCloudBatch(batchesX, batchesY);
            }
        }
    }

    // Wiederholen der X und Y Werte um ein 31x31 Batch an Wolken zu erstellen
    // Max 1024 -> Graphics.DrawMeshInstanciated

    private void BuildCloudBatch(int xLoop, int yLoop)
    {
        //Mark batch wenn in Kamera reichweite

        bool markBatch = false;
        //Cloud Batch welches erstellt wird

        List<CloudData> currBatch = new List<CloudData>();

        for(int x = 0; x < 31; x++)
        {
            for(int y = 0; y < 31; y++)
            {
                //Erstellen einer Wolke pro Loop

                AddCloud(currBatch, x + xLoop * 31, y + yLoop * 31);
            }
        }

        //Check if Batch should be Marked

        markBatch = CheckForActiveBatch(currBatch);

        //hinzufuegen des neusten batches zur List
        batches.Add(currBatch);

        //falls batch markiert ist zur update Liste hinzufügen

        if (markBatch) batchesToUpdate.Add(currBatch);
    }

    //methode zum checken ob das Batch in Kamera Reichweite ist
    //True if Clouds within Range
    //False if  CLouds are not within Range

    private bool CheckForActiveBatch(List<CloudData> batch)
    {
        foreach (var cloud in batch)
        {
            cloud.distFromCam = Vector3.Distance(cloud.pos, cam.transform.position);
            if (cloud.distFromCam < maxDist) return true;
        }
        return false;
    }

    //Erstellen der Wolken als CloudData object

    private void AddCloud(List<CloudData> currBatch, int x, int y)
    {
        //Setzen der neuen Cloud positions

        Vector3 position = new Vector3(transform.position.x + x * cloudSize, transform.position.y, transform.position.z + y * cloudSize);

        //Setzen der Wolken distanz zur Kamera

        float disToCam = Vector3.Distance(new Vector3(x, transform.position.y, y), cam.transform.position);

        //Hinzufuegen der CloudData zum aktuellen batch
        currBatch.Add(new CloudData(position, Vector3.zero, Quaternion.identity, x, y, disToCam));
    }

    //generation der noise
    //updaten der offsets

    void Update()
    {
        MakeNoise();
        offsetX += Time.deltaTime * timeScale;
        offsetY += Time.deltaTime * timeScale;
    }

    private void MakeNoise()
    {
     if (cam.transform.position == prevCamPos)
        {
            UpdateBatches();
        }
        else
        {
            prevCamPos = cam.transform.position;
            UpdateBatchList();
            UpdateBatches();
        }
        RenderBatches();
        prevCamPos = cam.transform.position;
    }

    //Methode die die Wolken updated

    private void UpdateBatches()
    {
        foreach (var batch in batchesToUpdate)
        {
            foreach (var cloud in batch)
            {

                float size = Mathf.PerlinNoise(cloud.x * texScale + offsetX, cloud.y * texScale + offsetY);

                if (size > minNoiseSize)
                {
                    float localScaleX = cloud.scale.x;

                    if (!cloud.isActive)
                    {
                        cloud.SetActive(true);
                        cloud.scale = Vector3.zero;

                    }

                    if(localScaleX < maxScale)
                    {
                        ScaleCloud(cloud, 1);

                        if(cloud.scale.x > maxScale)
                        {
                            cloud.scale = new Vector3(maxScale, maxScale, maxScale);
                        }
                    }
                }
                
                else if (size < minNoiseSize)
                {
                    float localScaleX = cloud.scale.x;
                    ScaleCloud(cloud, -1);

                    if (localScaleX <= 0.1)
                    {
                        cloud.SetActive(false);
                        cloud.scale = Vector3.zero;
                    }
                }
            }
        }
    }

    //sets cloud to new size

    private void ScaleCloud(CloudData cloud, int direction)
    {
        cloud.scale += new Vector3(sizeScale * Time.deltaTime + direction, sizeScale * Time.deltaTime * direction, sizeScale * Time.deltaTime * direction);
    }

    //methode zum leeren der batchesToUpdate list, nur visible batches

    private void UpdateBatchList()
    {
        //List clear

        batchesToUpdate.Clear();

        //Loop durch alle batches

        foreach(var batch in batches)
        {
            //if cloud within range add batch to list

            if (CheckForActiveBatch(batch))
            {
                batchesToUpdate.Add(batch);
            }
        }

       
    }

    private void RenderBatches()
    {
        foreach (var batch in batchesToUpdate)
        {
            Graphics.DrawMeshInstanced(cloudMesh, 0, cloudMat, batch.Select((a) => a.matrix).ToList());
        }
    }
}
