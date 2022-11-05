using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item item;
    public Image image;
    public Text text;

    public void Add()
    {
        if(item.amount == 0)
        {
            image.color = new Color(1, 1, 1, 1);
            text.text = "";
            text.gameObject.SetActive(true);
        }
        item.amount++;
        text.text = item.amount.ToString();
    }

    public void Remove()
    {
        if(item.amount == 0)
        {
            return;
        }
        else if(item.amount == 1)
        {
            image.color = new Color(1, 1, 1, 0.5f);
            text.gameObject.SetActive(false);
        }
        item.amount--;
        text.text = item.amount.ToString();
    }

    public void Reset()
    {
        item.amount = 0;
        if(item.icon != null)
        {
            image.sprite = item.icon;
            image.color = new Color(1, 1, 1, 0.5f);
        }
        text.gameObject.SetActive(false);
    }
}
