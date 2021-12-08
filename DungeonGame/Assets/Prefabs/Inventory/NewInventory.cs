using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour
{
    #region Singleton

    public static NewInventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Mehr als eine Instanz von NewInventory gefunden!");
        }
        instance = this;
    }

    #endregion Singleton

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int invSpace = 20;

    public List<NewItem> items = new List<NewItem>();

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

    public void Remove(NewItem item)
    {
        if(onItemChangedCallback != null)
            items.Remove(item);
    }
}
