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
    public float xPos;
    public float yPos;
    public float zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        yPos = -6f;
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 10)
        {
            xPos = Random.Range(0, -14);
            zPos = Random.Range(-230, -250);
            Instantiate(Enemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
