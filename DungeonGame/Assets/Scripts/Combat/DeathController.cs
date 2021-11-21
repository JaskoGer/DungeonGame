using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public Animator animator;
    public GameObject Button;
    public GameObject DeathCanvas;
    // Start is called before the first frame update
    void Start()
    {
        DeathCanvas = GameObject.Find("DeathScreen");
        DeathCanvas.gameObject.SetActive(false);
        Button = GameObject.Find("Exit");
        Button.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    public void Die ()
    {
        float Health = PlayerStatsSingleton.instance.GetPlayerHealth();
        if(Health <= 0 )
        {
            DeathCanvas.gameObject.SetActive(true);
            animator.SetTrigger("FadeOut");
            StartCoroutine(waiter(3));
            
        }
        
    }

    public void ExitButton()
    {
        animator.SetTrigger("Exit");
        Application.Quit();
    }

    IEnumerator waiter(float Time)
    {
        yield return new WaitForSeconds(Time);
    }
}