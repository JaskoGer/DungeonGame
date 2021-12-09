using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    /**
     *@Author Laurin   
     * damage apply am Enemy
     * bearbeitet von Tobias
     */
    void OnCollisionEnter(Collision col)
        {
        
          GameObject Enemy = col.collider.gameObject;

            if (col.collider.gameObject.transform.parent != null)
            {
                Enemy = col.collider.gameObject.transform.parent.gameObject;
            }
            if (Enemy.layer == LayerMask.NameToLayer("Enemy"))
            {
                Enemy.GetComponent<EnemyController>().GetDamage(PlayerStatsSingleton.instance.GetAttackDamage());
            }   
        }
}