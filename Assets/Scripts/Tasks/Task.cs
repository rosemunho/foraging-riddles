using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Task")]
public class Task : ScriptableObject
{
    public Item item;
    public int desiredAmount;
    public bool completed = false;

    public void CheckComplete()
    {
        completed = desiredAmount < item.amount;
    }
}
