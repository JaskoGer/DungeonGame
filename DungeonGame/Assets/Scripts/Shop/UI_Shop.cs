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
    [SerializeField]
    private Transform shopItemTemplate;

    /**
	 * @author Manuel
	 * Methode Awake() wird aufgerufen, wenn die Skriptinstanz geladen wird
	 * zeigt das UI für den Shop an
	 */
    private void Awake()
    {
        
        // zeigt den Shop an
        shopItemTemplate.gameObject.SetActive(true);
        shop_Background.gameObject.SetActive(true);
    }

    /**
	 * @author Manuel
	 * Methode Start() wird vor dem ersten geladenen Bild aufgerufen
	 * setzt die verschiedenen Items in dem Shop
	 */
    private void Start()
    {
        CreateItems(/*Items.GetSprite(Items.ItemType.crossbow),*/ "Crossbow", Items.GetCost(Items.ItemType.crossbow), 1);
        CreateItems(/*Items.GetSprite(Items.ItemType.helmet),*/ "Helmet", Items.GetCost(Items.ItemType.helmet), 2);
        CreateItems(/*Items.GetSprite(Items.ItemType.chestplate),*/ "Chestplate", Items.GetCost(Items.ItemType.chestplate), 3);
        CreateItems(/*Items.GetSprite(Items.ItemType.healthPotion),*/ "HealthPotion", Items.GetCost(Items.ItemType.healthPotion), 4);
        CreateItems(/*Items.GetSprite(Items.ItemType.meat),*/ "Meat", Items.GetCost(Items.ItemType.meat), 5);
        
    }


    /**
	 * @author Manuel
	 * erstellt die verschiedenen Items für den Shop
	 */
    private void CreateItems(/*Sprite itemSprite,*/ string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 45f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("priceText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());
        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);

        // shopItemTransform.Find("itemIcon").GetComponent<Image>().sprite = itemSprite;
    }
}
