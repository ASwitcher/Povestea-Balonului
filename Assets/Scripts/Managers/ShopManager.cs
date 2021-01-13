using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();

    public GameObject parentTransform;

    public GameObject slot;

    private void Start()
    {
        float offsetX = slot.GetComponent<RectTransform>().rect.width;
        float startX = parentTransform.GetComponent<RectTransform>().rect.x;

        for (int i = 0; i <= 5; i++)
        {
            GameObject slotObj = Instantiate(slot, new Vector3(-startX + (offsetX * i), 0f), Quaternion.identity);
            slotObj.transform.SetParent(parentTransform.transform, false);
            slots.Add(slotObj);
        }
    }


}
