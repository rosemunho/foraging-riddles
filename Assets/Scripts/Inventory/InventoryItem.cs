using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Item")]
public class InventoryItem : ScriptableObject
{
    public string item_name = "";
    public int amount = 0;
    public Sprite icon = null;

}
