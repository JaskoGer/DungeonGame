using UnityEngine;
using System.Collections;

/*@Author Laurin
*Methode für das Angreifen auf Distanz
*
*/

public class RangeAttack : MonoBehaviour
{

    private float damage = 10f;
    private float range = 100f;
	private float speed = 50f;
    private float cooldown = 0f;
	public Rigidbody Visual;
	public GameObject Player;
	private Vector3 playerPos;
    RaycastHit hit;

	

    private Transform Entity;
    public TrailRenderer tracerEffect;
    // Start is called before the first frame update
    void Start()
    {
        Entity = ObjectManager.instance.playerCharacter.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if(cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if(cooldown < 0)
            {
                cooldown = 0;
            } 
        }

        if (Input.GetButtonDown("Fire2") && cooldown == 0)
        {
            Attack();
            cooldown = 2.5f;
        }

    }
    
    
     /*@Author Laurin
    *updated position und spawnt Projektile
    *
    */
    public void Attack()
    {

    playerPos = Player.transform.position + new Vector3(0f, 1f, 0f);
     var clone = Instantiate(Visual, playerPos, Player.transform.rotation);
     clone.velocity = Player.transform.TransformDirection(new Vector3(0, 0, speed)) + new Vector3(0, 1 ,0);
     Destroy (clone.gameObject, 5);
		
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
