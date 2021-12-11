using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * @author Kacper Purtak
 * version 1.0
 * 30.11.2021
 * Description: Vorlage für das Inventar mit Methoden zum bearbeiten
 */

public class NewInventory : MonoBehaviour
{
    #region Singleton

    public static NewInventory instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    #endregion Singleton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int invSpace = 6;   //Anzahl der Itemplaetze

    public List<NewItem> items = new List<NewItem>();   //eine Liste aus Items

    //fuegt ein neues Item hinzu, wenn genuegend Platz vorhanden ist
    public bool Add (NewItem item)
    {
        if (!item.isDefaultItem)
        {
            if(items.Count >= invSpace)
            {
                Debug.Log("Das Inventar ist voll!");
                return false;
            }
			print("1");
            items.Add(item);

            if(onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    //entfernt ein Item
    public void Remove(NewItem item)
    {
        if(onItemChangedCallback != null)
            items.Remove(item);
    }

    /**
	 * @Author Jasko, Jonas
	 * gibt die Liste mit Items zurueck
	 */
    public int[] getInv()
    {
        int[] inv = new int[items.Count];
        for (int i = 0; i < items.Count; i++)
        {
            inv[i] = items[i].itemID;
        }
        return inv;
    }
}
