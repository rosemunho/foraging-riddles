using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    public Task[] availableTasks = null;
    public Vector2Int taskAmountLimits = Vector2Int.up;

    private Task[] tasks = null;

    public void ChooseTasks()
    {
        // select amount between vec.x and vec.y
        // shuffle available
        int taskAmount = Random.Range(taskAmountLimits.x, taskAmountLimits.y);
        // subset of available from 0 to amount
    }
}
