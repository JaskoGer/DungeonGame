using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public static CombatController instance = null;

    private void Awake()
	{
		// Erstellen der Instance dieser Klasse
		if (instance == null)
		{
			instance = this;
		}
		//Zerstöre ein bestehendes Objekt, falls es nicht dieses ist
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        /**
     * @Author Tobias
     * Angreifen von Gegner
     */
    public void AttackEnemy(RaycastHit hitEnemy1, RaycastHit hitEnemy2, RaycastHit hitEnemy3)
    {
        if (hitEnemy1.collider != null)
        {
            AttackEnemyRaycast(hitEnemy1);
        }
        else if (hitEnemy2.collider != null)
        {
            AttackEnemyRaycast(hitEnemy2);
        }
        else if (hitEnemy3.collider != null)
        {
            AttackEnemyRaycast(hitEnemy3);
        }
    }

    void AttackEnemyRaycast(RaycastHit hitEnemy)
    {
        GameObject Enemy = hitEnemy.collider.gameObject;
        if (hitEnemy.collider.gameObject.transform.parent != null)
        {
            Enemy = hitEnemy.collider.gameObject.transform.parent.gameObject;
        }
        if (Enemy.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy.GetComponent<EnemyController>().GetDamage(PlayerStatsSingleton.instance.GetAttackDamage());
        }
    }
}
