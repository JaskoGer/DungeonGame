using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    public static DeathController instance = null;
    /*    public Animator animator;
       public GameObject Button; */
    public GameObject DeathCanvas;
    public GameObject MusicSource;
    public GameObject SoundSource;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
    }

    void Update()
    {
        Die();
    }

    public void Die ()
    {
        float Health = PlayerStatsSingleton.instance.GetPlayerHealth();
        if(Health <= 0 )
        {
            gameObject.GetComponent<PlayerMovement>().died = true;
            DeathCanvas.gameObject.SetActive(true);
            SoundSource.gameObject.SetActive(true);
            MusicSource.gameObject.SetActive(false);
        }
        
    }

    /**
     * @Author Tobias
     * Methode zum reviven eines Players
     */
    public void Revive ()
    {
        gameObject.GetComponent<PlayerMovement>().died = false;
        SceneManager.LoadScene(GlobalScene.currentScene);
        PlayerStatsSingleton.instance.SetPlayerHealth(PlayerStatsSingleton.instance.GetPlayerMaxHealth());
        DeathCanvas.gameObject.SetActive(false);
        SoundSource.gameObject.SetActive(false);
        MusicSource.gameObject.SetActive(true);
        PlayerManager man = ObjectManager.instance.GetGameManager().GetComponent<PlayerManager>();
        transform.position = new Vector3(man.startPointx, man.startPointy, man.startPointz);
        transform.rotation = man.startRotation;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    IEnumerator waiter(float Time)
    {
        yield return new WaitForSeconds(Time);
    }
}
