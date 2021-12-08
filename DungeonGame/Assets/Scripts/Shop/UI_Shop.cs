using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * @author Manuel
 * Erstellung der Klasse UI_Shop und Deklarierung der Variablen
 */
public class UI_Shop : MonoBehaviour
{

    // Deklarierung der Variablen
    [SerializeField]
    private Transform shop_Background;
    [SerializeField]
    private Transform container;
    ShopSlot[] shopSlots;
    public int shopSpace = 6;
    public List<NewItem> shopItems = new List<NewItem>();

    /**
	 * @author Manuel
	 * Methode Awake() wird aufgerufen, wenn die Skriptinstanz geladen wird
	 * zeigt das UI für den Shop an
	 */
    private void Awake()
    {
        
        // zeigt den Shop an
        shop_Background.gameObject.SetActive(true);
        container.gameObject.SetActive(true);

    }

    private void Start()
    {
        shopSlots = container.GetComponentsInChildren<ShopSlot>();
        UpdateShop();
    }

    public void UpdateShop()
    {
        for(int i = 0; i < shopSpace; i++)
        {
            shopSlots[i].AddItemToShop(shopItems[i]);
        }
    }

}
