using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/**
 * @Author Jonas
 * verschlüsselt und entschlüsselt die Daten, die gespeichert werden
 * führt das Speichern in der PlayerData-Klasse durch
 */
public static class SaveSystem
{
	public static void SavePlayer(PlayerStatsSingleton player)
	{
		//GameObject inv = ObjectManager.instance.inventory;
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.alexander";
		FileStream stream = new FileStream(path, FileMode.Create);

		PlayerData data = new PlayerData(player, NewInventory.instance.getInv());

		formatter.Serialize(stream, data);
		stream.Close();
	}

	public static PlayerData LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player.alexander";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;
		}
		else
		{
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}
}
