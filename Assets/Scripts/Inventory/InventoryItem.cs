using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Item item;
    public Image sprite;
    public Text text;

    void Start()
    {
        if(item.icon != null)
        {
            //sprite = item.icon;
            // add slight fade
        }
        text.gameObject.SetActive(false);
    }

    public void Add()
    {
        if(item.amount == 0)
        {
            //remove fade    
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
            // fade sprite
            text.gameObject.SetActive(false);
        }
        item.amount--;
        text.text = item.amount.ToString();
    }
}
