using UnityEngine;

public class RangeAttack : MonoBehaviour
{

    private float damage = 10f;
    private float range = 100f;

    public GameObject Entity;
    public TrailRenderer tracerEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            Attack();
        }

    }
    
     /**
     *@Author Laurin   
     * damage apply am Enemy
     * bearbeitet von Tobias
     */
    public void Attack()
    {

        /* var tracer = Instantiate(tracerEffect, Entity.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity); */
     /*    tracer.transform.position = Entity.transform.forward; */
        
        RaycastHit hit;
        
        if (Physics.Raycast(Entity.transform.position + new Vector3(0f, 1f, 0f), Entity.transform.forward, out hit, range))
        {
            GameObject Enemy = hit.collider.gameObject;
            if (hit.collider.gameObject.transform.parent != null)
            {
                Enemy = hit.collider.gameObject.transform.parent.gameObject;
            }
            if (Enemy.layer == LayerMask.NameToLayer("Enemy"))
            {
                Enemy.GetComponent<EnemyController>().GetDamage(PlayerStatsSingleton.instance.GetAttackDamage());
            }
        }
    }

    public void setDamage(float newdamage)
    {
        damage = newdamage;
    }

    public void setRange(float newrange)
    {
        range = newrange;
    }

    public float getDamage()
    {
        return damage;
    }

    public float getRange()
    {
        return range;
    }

}
