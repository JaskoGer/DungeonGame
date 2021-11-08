using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Tobias
 * @Since 22.09.2021
 * Script für das Mobspawning
 */
public class MobSpawning : MonoBehaviour
{
    public GameObject Enemy;
    public float xPos1;
    public float xPos2;
    public float yPos;
    public float zPos1;
    public float zPos2;
    private int enemies;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemies < enemyCount)
        {
            Instantiate(Enemy, new Vector3(Random.Range(xPos1, xPos2), yPos, Random.Range(zPos1, zPos2)), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            enemies += 1;
        }
    }
}