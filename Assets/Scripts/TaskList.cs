using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    public Task[] availableTasks = null;
    // Check how to rename the X and Y later
    public Vector2Int taskAmountLimits = Vector2Int.up;

    private Task[] tasks = null;

    public void ChooseTasks()
    {                         
        ShuffleTasks(availableTasks);
        int taskAmount = Random.Range(taskAmountLimits.x, taskAmountLimits.y);
        tasks = new Task[taskAmount];
        for(int i = 0; i < taskAmount; i++)
        {
            tasks[i] = availableTasks[i];
        }
    }

    public void ShuffleTasks(Task[] values)
    {
        Task tempValue;
        for (int i = 0; i < values.Length - 1; i++) 
        {
            int rnd = Random.Range(i, values.Length);
            tempValue = values[rnd];
            values[rnd] = values[i];
            values[i] = tempValue;
        }
    }
}
