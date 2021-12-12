using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

/**
 * @Author Tobias
 * @Since 27.10.2021
 * Script für Playerstats
 */
public class PlayerStatsSingleton : MonoBehaviour
{
	public static PlayerStatsSingleton instance = null;
	
    public Image healthBarSlider;

    [SerializeField]
    private Text HealthValue;

    [SerializeField]
    private Text PlayerMoneten;

    private float maxHealth = 100;
    private float health = 100;
    private float regenerationPower = 0.33333f;
    private int playerLevel = 1;
    private int playerXp = 0;
    private int nextLevelXp = 100;
    private int moneten = 1000;
    private int scene;

    private float attackDamage = 10f;
    private float attackRange = 4f;

    private Transform playerCharacter;

    private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		DontDestroyOnLoad (gameObject);
	}

    // Start is called before the first frame update
    void Start()
    {
        playerCharacter = ObjectManager.instance.playerCharacter.transform;
        SetUIImage();
        SetPlayerMoneten();

        scene = GlobalScene.currentScene;
    }

    /**
     * @Author Tobias
     * Methode zum Anpassen des Levels in jeden Frame
     * Lebensregeneration von Laurin Angepasst
     */
    void Update()
    {
        float tempHealth;
        tempHealth = EntityStatsController.instance.HealthRegeneration(regenerationPower, health, maxHealth);
        SetPlayerHealth(tempHealth);
        SetUIImage();
        if (Input.GetKeyDown(KeyCode.K))
        {
            SavePlayer();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPlayer();
        } 
    }

    /**
	 * @Author Jonas
	 * Speichert die Spielerinfos
	 */
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    /**
	 * @Author Jonas
	 * Laedt den Spielstand
	 */
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        scene = data.scene;
        SceneManager.LoadScene(scene);  

        playerLevel = data.level;
        health = data.health;
        moneten = data.moneten;
        playerXp = data.xp;
    }

    /**
     * @Author Tobias
     * Festlegen des Lebens
     */
    public void SetPlayerHealth(float pHealth)
    {
        health = pHealth;
        if (health <= 0)
        {
            health = 0;
        }
    }

    /**
     * @Author Tobias
     * Zurückgeben des Lebens
     */
    public float GetPlayerHealth()
	{
		return health;
	}

    /**
     *@Author Laurin   
     *Zurückgeben des Maximalen Lebens
     */
    public float GetPlayerMaxHealth()
    {
        return maxHealth;
    }

    /**
     *@Author Laurin   
     *Zurückgeben der Regenerationskraft
     */
    public float GetRegenerationPower()
    {
        return regenerationPower;
    }

    /**
     * @Author Tobias   
     * Getter für Damage
     */
    public float GetAttackDamage()
    {
        return attackDamage;
    }

    /**
     * @Author Tobias   
     * Getter für Range
     */
    public float GetAttackRange()
    {
        return attackRange;
    }

    /**
     * @Author Tobias
     * Hinzufügen von Leben
     */
    public void AddPlayerHealth(float pHealth)
    {
        health = health + pHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    /**
     * @Author Tobias
     * Schaden an den Spieler geben
     */
    public void PlayerDamage(float pDamage)
    {
        health = health - pDamage;
        if (health <= 0)
        {
            health = 0;
        }
    }

    /**
     * @Author Tobias
     * Level wird erhöht und Stats werden angepasst
     */
    public void LevelUp()
    {
        playerLevel++;
        maxHealth += 10;
        health += 10;
    }

    /**
     * @Author Tobias
     * Zurückgeben des Levels
     */
    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    /**
	 * @Author Jonas
	 * Zurückgeben der XP
	 */
    public int GetPlayerXP()
    {
        return playerXp;
    }

    /**
     * @Author Jonas
     * gibt aktuell verwendete Szene zurück
     */
    public int GetCurrentScene()
    {
        print(GlobalScene.currentScene);
        return GlobalScene.currentScene;
    }

    /**
     * @Author Tobias
     * Hinzufügen von extra XP
     */
    public void AddPlayerXp(int pXp)
    {
        playerXp += pXp;
        if (playerXp >= nextLevelXp)
        {
            LevelUp();
        }
        playerXp = playerXp - nextLevelXp;
        nextLevelXp = 100 * playerLevel * playerLevel;
    }

    /**
	 * @Author Jonas
	 * Zurückgeben der Moneten
	 */
    public int GetPlayerMoneten()
    {
        return moneten;
    }

    /**
	 * @Author Jasko
	 * addiert neu verdiente Moneten hinzu
	 */
    public void AddPlayerMoneten(int ernie)
    {
        moneten += ernie;
        SetPlayerMoneten();
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
            Enemy.GetComponent<EnemyController>().GetDamage(attackDamage);
        }
    }

    /**
     * @Author Tobias
     * Setzung des UI
     * bearbeitet von Kacper
     * Anzeige der Lebenszahl/Rüstungszahl und rundung von Laurin
     */
    public void SetUIImage()
    {
        float RoundedHealth;
        if(health == maxHealth)
        {
          HealthValue.text = health + " / " + maxHealth;
        }
        else if (health != maxHealth)
        {
          RoundedHealth = Mathf.Round(health);  
          HealthValue.text = RoundedHealth + " / " + maxHealth;
        }
        healthBarSlider.fillAmount = health / maxHealth;
    }


    public void SetPlayerMoneten()
    {
        PlayerMoneten.text = moneten.ToString();
    }
} 
