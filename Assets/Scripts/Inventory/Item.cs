using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class Item : ScriptableObject
{
    public string itemName = "";
    public int amount = 0;
    public Sprite icon = null;
}
