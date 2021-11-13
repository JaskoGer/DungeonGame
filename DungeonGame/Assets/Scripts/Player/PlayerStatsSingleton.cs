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
	
    public Image HealthBarSlider;
    public Image ArmorBarSlider;

    private float MaxHealth = 100;
    private float Health = 100;
    private float Armor = 0;
    private float DamageReduction = 0;
    private float RegenerationPower = 0.33333f;

    private int PlayerLevel = 1;
    private int PlayerXp = 0;
    private int nextLevelXp = 100;

    private float AttackDamage = 10f;
    private float AttackRange = 4f;

    public Transform PlayerCharacter;

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
        SetUIImage();
    }

    /**
     * @Author Tobias
     * Methode zum Anpassen des Levels und des Lebens in jeden Frame
     */
    void Update()
    {
        
        HealthRegeneration(RegenerationPower);
        

        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelUp();
            /* print("This is a LevelUp"); */
            //Funktioniert zeigt nur keine Armor an oder erhöht den Wert nicht
        }
        /**
         * @Author Laurin
         * Debug Button
         * Debugging der Werte
         */
        if (Input.GetKeyDown(KeyCode.K))
        {
            print("Level:" + GetPlayerLevel() + " Armor:" + GetPlayerArmor());
            SetUIImage();
            /* print("This Button Works"); */
        }

        //Keine Aktualisierung falls in der "Health Regen" schleife
        
    }

    /**
     * @Author Tobias
     * Zurücksetzen des Lebens
     */
    public void ResetHealth()
    {
        Health = MaxHealth;
        SetUIImage();
    }

    /**
     * @Author Laurin
     * Methode für das Regenerieren von Leben
     * Bearbeitet von Tobias
     */
    public void HealthRegeneration(float RegenerationBoost)
    {
        if (Health < MaxHealth)
        {
            SetUIImage();
            Health += RegenerationBoost*Time.deltaTime;
            if (Health > MaxHealth)
                Health = MaxHealth;
            
        }
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
        SetUIImage();
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
        SetUIImage();
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
        SetUIImage();
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
        SetUIImage();
        
    }

    /**
     * @Author Tobias
     * Zurückgeben des Levels
     */
    public int GetPlayerLevel()
    {
        return PlayerLevel;
    }

    /**
     * @author Laurin
     * Zurückgeben der Armor
     */
    public float GetPlayerArmor()
    {
        return Armor;
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

    /**
     * @Author Tobias
     * Angreifen von Gegner
     */
    void AttackEnemyRaycast(RaycastHit hitEnemy)
    {
        GameObject Enemy = hitEnemy.collider.gameObject;
        if (hitEnemy.collider.gameObject.transform.parent != null)
        {
            Enemy = hitEnemy.collider.gameObject.transform.parent.gameObject;
        }
        if (Enemy.layer == LayerMask.NameToLayer("Enemy"))
        {
            Enemy.GetComponent<EnemyController>().GetDamage(GetAttackDamage());
        }
    }

    /**
     * @Author Laurin
     * Getter
     */
    public float GetAttackDamage()
    {
        return AttackDamage;
    }

    /**
     * @Author Laurin
     * Getter
     */
    public float GetAttackRange()
    {
        return AttackRange;
    }

    /**
     * @Author Tobias
     * Setzung des UI
     * bearbeitet von Kacper
     */
    public void SetUIImage()
    {
        HealthBarSlider.fillAmount = Health / MaxHealth;
        ArmorBarSlider.fillAmount = Armor;
    }
} 
