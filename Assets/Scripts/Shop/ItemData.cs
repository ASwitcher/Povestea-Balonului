using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Item", menuName = "ShopItem", order = 51)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private Sprite icon;
    [SerializeField]
    private int price;
    [SerializeField]
    private int forceUp;

    public string ItemName
    {
        get
        {
            return itemName;
        }
    }

    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }

    public int Price
    {
        get
        {
            return price;
        }
    }

    public int ForceUp
    {
        get
        {
            return forceUp;
        }
    }
}
