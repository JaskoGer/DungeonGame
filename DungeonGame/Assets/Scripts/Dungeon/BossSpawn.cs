using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    #region Singleton

    public static BossSpawn instance;
    public GameObject boss;
    private bool run = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    #endregion Singleton

    private int enemyCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!run && !boss.activeSelf)
        {
            StartCoroutine(EnemyDrop());
        }   
    }

    public void addEnemies(int pA)
    {
        enemyCount += pA;
    }

    IEnumerator EnemyDrop()
    {
        run = true;
        yield return new WaitForSeconds(5f);
        if(enemyCount < 2)
        {
            boss.SetActive(true);
        }
        run = false;
    }
}
