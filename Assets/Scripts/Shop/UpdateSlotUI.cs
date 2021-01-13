using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateSlotUI : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TextMeshProUGUI text;

    public void UpdateMySlotUI(ItemData itemData)
    {
        image.sprite = itemData.Icon;
        text.text = itemData.Price.ToString();
    }
}
