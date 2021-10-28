using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/**
 * @Author Tobias
 * @Since 27.10.2021
 * Script für Playerstats
 */
public class PlayerStatsSingleton : MonoBehaviour
{
	public static PlayerStatsSingleton instance = null;
	
    public Text HealthText;
    public Text ArmorText;

    private float MaxHealth = 100;
    private float Health = 100;
    private float Armor = 0;
    private float DamageReduction = 0;

    private int PlayerLevel = 1;
    private int PlayerXp = 0;
    private int nextLevelXp = 100;

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

    /**
     * @Author Tobias
     * Methode zum Anpassen des Levels und des Lebens in jeden Frame
     */
    void Update()
    {
        if (Health < MaxHealth)
        {
            Health += 0.33333f*Time.deltaTime;
            if (Health > MaxHealth)
                Health = MaxHealth;
            SetUIText();
        }
        if (Input.GetKeyUp(KeyCode.L))
        {
            LevelUp();
        }
    }

    /**
     * @Author Tobias
     * Zurücksetzen des Lebens
     */
    public void resetHealth()
    {
        Health = MaxHealth;
        SetUIText();
    }

    /**
     * @Author Tobias
     * Festlegen des Lebens
     */
    public void SetPlayerHealth(float pHealth)
    {
        Health = pHealth;
        if (Health <= 0)
        {
            Health = 0;
        }
        SetUIText();
    }

    /**
     * @Author Tobias
     * Zurückgeben des Lebens
     */
    public float GetPlayerHealth()
	{
		return Health;
	}

    /**
     * @Author Tobias
     * Hinzufügen von Leben
     */
    public void AddPlayerHealth(float pHealth)
    {
        Health = Health + pHealth;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
        SetUIText();
    }

    /**
     * @Author Tobias
     * Setzen der Armor
     */
    public void SetPlayerArmor(float pArmor)
    {
        Armor = pArmor;
        DamageReduction = 5 / (-(float)Math.Sqrt(Armor + 25)) + 1;
    }

    /**
     * @Author Tobias
     * Schaden an den Spieler geben
     */
    public void PlayerDamage(float pDamage)
    {
        Health = Health - pDamage * (1 - DamageReduction);
        if (Health <= 0)
        {
            Health = 0;
        }
        SetUIText();
    }

    /**
     * @Author Tobias
     * Level wird erhöht und Stats werden angepasst
     */
    public void LevelUp()
    {
        PlayerLevel++;
        MaxHealth += 10;
        Health += 10;
        SetPlayerArmor(Armor + 1);
        
    }

    /**
     * @Author Tobias
     * Zurückgeben des Levels
     */
    public int getPlayerLevel()
    {
        return PlayerLevel;
    }

    /**
     * @Author Tobias
     * Hinzufügen von extra XP
     */
    public void AddPlayerXp(int pXp)
    {
        PlayerXp += pXp;
        if (PlayerXp >= nextLevelXp)
        {
            LevelUp();
        }
        PlayerXp = PlayerXp - nextLevelXp;
        nextLevelXp = 100 * PlayerLevel * PlayerLevel;
    }

    /**
     * @Author Tobias
     * vorläufige Setzung des UI zum testen
     */
    public void SetUIText()
    {
        HealthText.text = (int)Health + "/" + (int)MaxHealth;
        ArmorText.text = (int)Armor + "";
    }
}
