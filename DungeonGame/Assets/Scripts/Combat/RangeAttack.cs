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

    public void Attack()
    {

        /* var tracer = Instantiate(tracerEffect, Entity.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity); */
     /*    tracer.transform.position = Entity.transform.forward; */
        
        RaycastHit hit;
        
        if (Physics.Raycast(Entity.transform.position + new Vector3(0f, 1f, 0f), Entity.transform.forward, out hit, range))
        {
            /* Debug.Log(hit.transform.name);
            Debug.DrawRay(Entity.transform.position + new Vector3(0f, 1f, 0f), Entity.transform.forward, Color.green, 2, false); */
            EnemyController target = hit.transform.GetComponent<EnemyController>();
            /* tracer.AddPosition(hit.point); */
            if (target != null)
            {
                target.instance.GetDamage(getDamage());
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
