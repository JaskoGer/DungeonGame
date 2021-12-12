using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
 * @Author Jonas
 * speichert die Spielerdaten
 */

[System.Serializable]
public class PlayerData
{
	//Deklarierung der Variablen
	public int level;
	public float health;
	public int moneten;
	public int xp;
	public int scene;
	public int[] inventory;

	//Variablen werden im Constructor befuellt
	public PlayerData(PlayerStatsSingleton player, int[] inv)
	{
		level = player.GetPlayerLevel();
		health = player.GetPlayerHealth();
		moneten = player.GetPlayerMoneten();
		xp = player.GetPlayerXP();
		scene = player.GetCurrentScene();
		inventory = inv;
	}
}
