using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateShopUI: MonoBehaviour
{

    public List<ItemData> items = new List<ItemData>();

    public Text text;

    public GameObject slot;

    public Transform shopList;

    private void Start()
    {
        for(int i = 0; i < items.Count; i++)
        {
            Debug.Log(i);
            GameObject slotObj = Instantiate(slot, shopList.transform.position, Quaternion.identity);
            slotObj.transform.parent = shopList.transform;
            UpdateSlotUI updateUIperSlot = slotObj.GetComponent<UpdateSlotUI>();
            updateUIperSlot.UpdateMySlotUI(items[i]);
        }
        UpdateCurrentMoney();
    }

    private void UpdateCurrentMoney()
    {
        text.text = "Money: " + GameManager.instance.currentMoney.ToString();
    }

}
