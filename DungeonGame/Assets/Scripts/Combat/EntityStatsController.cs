using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatsController : MonoBehaviour
{
    public static EntityStatsController instance = null;

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

 /*
     * @Author Laurin
     * Methode für das Regenerieren von Leben
     * Ausgelagerter Code geschrieben von Tobias
     */
    public void HealthRegeneration(float RegenerationBoost, float Health, float MaxHealth)
    {
        if (Health < MaxHealth)
        {
            Health += RegenerationBoost*Time.deltaTime;
            if (Health > MaxHealth)
                Health = MaxHealth;
        }
        
    }

        /**
     * @Author Tobias
     * Zurücksetzen des Lebens
     */
    public float ResetHealth(float Health, float MaxHealth)
    {
        Health = MaxHealth;
        return Health;
    }

}
