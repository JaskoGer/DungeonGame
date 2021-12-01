using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData
{
    public int level;
	public float health;
	public int moneten;
	public float[] position;
	public int xp;
	
	public PlayerData (PlayerStatsSingleton player)
	{
		level = player.GetPlayerLevel();
		health = player.GetPlayerHealth();
		moneten = player.GetPlayerMoneten();
		xp = player.GetPlayerXP();
		
		position = new float[3];
		position[0] = player.transform.position.x;
		position[1] = player.transform.position.y;
		position[2] = player.transform.position.z;
	}
}
