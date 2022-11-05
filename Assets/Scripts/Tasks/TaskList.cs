using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    public Task[] availableTasks = null;
    // Check how to rename the X and Y later
    public Vector2Int taskAmountLimits = Vector2Int.up;
    public TaskListItem[] tasks;

    public void UpdateTasks()
    {
        //TODO: define tasks by level or choose randomly? maybe both??
        ChooseTasks();
    }

    public void ChooseTasks()
    {                         
        ShuffleTasks(availableTasks);

        taskAmountLimits.x = Mathf.Max(1, taskAmountLimits.x);
        taskAmountLimits.y = Mathf.Min(tasks.Length, taskAmountLimits.y);
        int taskAmount = Random.Range(taskAmountLimits.x, taskAmountLimits.y);

        for(int i = 0; i < tasks.Length; i++)
        {
            if(i < taskAmount)
            {
                tasks[i].UpdateTask(availableTasks[i]);
            }
            else
            {
                tasks[i].UpdateTask(null);
            }
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
