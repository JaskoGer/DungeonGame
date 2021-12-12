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
	//speichert die Daten des Players und des Inventars
	public static void SavePlayer(PlayerStatsSingleton player)
	{
		//GameObject inv = ObjectManager.instance.inventory;

		//Datei zum Speichern wird aufgerufen und die Daten werden verschoben
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.alexander";
		FileStream stream = new FileStream(path, FileMode.Create);

		//Daten werden an PlayerData übergeben
		PlayerData data = new PlayerData(player, NewInventory.instance.getInv());

		formatter.Serialize(stream, data);
		stream.Close();
	}

	//lädt die Daten des Players und des Inventars 
	public static PlayerData LoadPlayer()
	{
		string path = Application.persistentDataPath + "/player.alexander";
		if (File.Exists(path))
		{
			//formatiert die Daten Daten wieder zurück und überschreibt die PlayerData Klasse
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			PlayerData data = formatter.Deserialize(stream) as PlayerData;
			stream.Close();

			return data;
		}
		else
		{
			//gibt Feedback, wenn keine Datei zum Laden der Daten vorhanden ist
			Debug.LogError("Save file not found in " + path);
			return null;
		}
	}
}
