using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public InventoryItem[] items = null;
    
    public void CollectItem(Item item)
    {
        foreach(InventoryItem ii in items)
        {
            if(ii.item.itemName == item.itemName)
            {
                ii.Add();
                break;
            }
        }
    }
    
    public void UseItem(Item item)
    {
        foreach(InventoryItem ii in items)
        {
            if(ii.item.itemName == item.itemName)
            {
                ii.Remove();
                break;
            }
        }
    }
    
}
