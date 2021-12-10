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
	public int level;
	public float health;
	public int moneten;
	public float[] position;
	public int xp;
	public Scene scene;
	public int[] inventory;

	public PlayerData(PlayerStatsSingleton player, int[] inv)
	{
		level = player.GetPlayerLevel();
		health = player.GetPlayerHealth();
		moneten = player.GetPlayerMoneten();
		xp = player.GetPlayerXP();
		scene = player.GetCurrentScene();
		inventory = inv;

		position = new float[3];
		position[0] = player.transform.position.x;
		position[1] = player.transform.position.y;
		position[2] = player.transform.position.z;


	}
}
