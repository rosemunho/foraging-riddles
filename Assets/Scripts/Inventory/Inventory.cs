using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] items = null;

    public void AddItem(InventoryItem item)
    {
        item.amount++;
    }
    
    public void UseItem(InventoryItem item)
    {
        if (item.amount > 0)
        {
            item.amount--;
        }
    }
}
