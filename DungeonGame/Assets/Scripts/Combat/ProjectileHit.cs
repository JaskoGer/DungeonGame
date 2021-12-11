using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    /**
     *@Author Laurin   
     * damage apply am Enemy und Sound
     * prinzip der Schleife von Tobias
     */
    public AudioSource HitWall;
    public AudioSource HitEnemy;
    double cooldown = 0;

    

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
                HitEnemy.Play();
            }   
            if (Enemy.layer == LayerMask.NameToLayer("Player"))
            {

            }
            else
            {
                if(cooldown <= Time.time)
                {
                    HitWall.Play();
                    cooldown = Time.time + 0.5;
                }
            }


        }

}