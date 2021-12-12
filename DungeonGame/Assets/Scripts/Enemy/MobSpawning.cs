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
    public float hp;
    public GameObject Enemy;
    float xPos;
    float yPos;
    float zPos;
    public float radiant;
    private int enemies;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        BossSpawn.instance.addEnemies(enemyCount);
        xPos = gameObject.transform.localPosition.x;
        yPos = gameObject.transform.localPosition.y;
        zPos = gameObject.transform.localPosition.z;
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemies < enemyCount)
        {
            var clone = Instantiate(Enemy, new Vector3(Random.Range(xPos - radiant, xPos + radiant), yPos, Random.Range(zPos - radiant, zPos + radiant)), Quaternion.identity);
            clone.GetComponent<EnemyController>().setHealth(hp);
            yield return new WaitForSeconds(0.01f);
            enemies += 1;
        }
    }
}