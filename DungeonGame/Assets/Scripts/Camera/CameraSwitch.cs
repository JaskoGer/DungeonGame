using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Tobias Haubold
 * @Since 22.09.2021
 * Script für die Steuerung der Kameraperspektive und dazu gehöringen Tasten
 */
public class CameraSwitch : MonoBehaviour
{
    public Transform target;
	public Transform character;

    public float speed = 0.2f;
    public Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    public Quaternion rotation2 = Quaternion.Euler(0, 0, 0);
    public Boolean isTurning = false;

    private Vector3 normalCameraVector = new Vector3(0, 1f, -5f);
    private Vector3 normalCameraPosition = new Vector3(0, 1f, -5f);

    private int notPlayerLayer;

    // Start is called before the first frame update
    void Start()
    {
        notPlayerLayer = ~LayerMask.GetMask("Player");
    }


    void Update()
    {
        MoveCam();
        RotateCam();
    }
	
	/**
     * @Author Tobias
     * Steuerung der Kamera, 90 switch in die jeweilige Richtung
     */
	void RotateCam()
	{
		//Erhaltung des Winkels zwischen 0 und 360°
        float rotation;
        if (target.eulerAngles.y <= 360f)
        {
            rotation = (float) target.eulerAngles.y;
        }
        else
        {
            rotation = (float) target.eulerAngles.y - 360;
        }

        rotation1 = Quaternion.Euler(0, rotation, 0);

        //Kamerawinkeländerung bei E und Q um 90°
        if (Input.GetKeyDown(KeyCode.E) && !isTurning)
        {
            rotation2 = Quaternion.Euler(0, rotation + 90, 0);
            StartCoroutine(RotateOverTime(rotation1, rotation2, speed));
        }

        if (Input.GetKeyDown(KeyCode.Q) && !isTurning)
        {
            rotation2 = Quaternion.Euler(0, rotation - 90, 0);
            StartCoroutine(RotateOverTime(rotation1, rotation2, speed));
        }
	}

    /**
     * @Author Tobias
     * Steuerung der Kamera, Bewegung nach vorne falls Kollision und nach hinten, wenn keine mehr vorhanden.
     */
    void MoveCam() 
	{
        normalCameraPosition = target.localRotation * normalCameraVector;

        if (Physics.Raycast(character.position + new Vector3(0, 3f, 0), target.rotation * normalCameraVector, Vector3.Distance(transform.position, character.position + new Vector3(0, 3f, 0)), notPlayerLayer))
        {
            if(Vector3.Distance(transform.position, target.position) > 0.4f)
            {
                transform.Translate(0.01f * ((Quaternion.Inverse(transform.localRotation)) * -normalCameraVector));
            }
        }
        else if(!Physics.Raycast(transform.position, target.rotation * normalCameraVector, 2.0f))
        {
            if (Vector3.Distance(transform.position, target.position) < normalCameraVector.magnitude)
            {
                transform.Translate(0.01f * ((Quaternion.Inverse(transform.localRotation)) * normalCameraVector));
            }
        }
    }
	
	//Enumerator um Lerp zu benutzen, interpolarisiert zwischen zwei Drehungen/Winkeln
    IEnumerator RotateOverTime(Quaternion originalRotation, Quaternion finalRotation, float duration)
    {
        isTurning = true;
        if (duration > 0f)
        {
            float startTime = Time.time;
            float endTime = startTime + duration;
            target.transform.rotation = originalRotation;
            yield return null;
            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / duration;
                target.transform.rotation = Quaternion.Slerp(originalRotation, finalRotation, progress);
                yield return null;
            }
        }
        target.transform.rotation = finalRotation;
        isTurning = false;
    }
}
