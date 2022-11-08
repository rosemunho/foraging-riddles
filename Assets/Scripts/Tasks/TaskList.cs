using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    [System.Serializable]
    public struct TaskListCategory
    {
        [SerializeField]
        public Task[] tasks;
    }

    public TaskListCategory[] availableTasks = null;
    //TODO: Check how to rename the X and Y later
    public Vector2Int taskAmountLimits = Vector2Int.up;
    public TaskListItem[] tasks;

    public void UpdateTasks()
    {
        ChooseTasks();
    }

    public void ChooseTasks()
    {                         
        ShuffleTasks<TaskListCategory>(availableTasks);

        taskAmountLimits.x = Mathf.Max(1, taskAmountLimits.x);
        taskAmountLimits.y = Mathf.Min(tasks.Length, taskAmountLimits.y);
        int taskAmount = Random.Range(taskAmountLimits.x, taskAmountLimits.y);

        for(int i = 0; i < tasks.Length; i++)
        {
            if(i < taskAmount)
            {
                Task task = availableTasks[i].tasks[Random.Range(0, availableTasks[i].tasks.Length)];
                task.completed = false;
                tasks[i].UpdateTask(task);
            }
            else
            {
                tasks[i].UpdateTask(null);
            }
        }
    }

    public void ShuffleTasks<T>(T[] values)
    {
        T tempValue;
        for (int i = 0; i < values.Length - 1; i++) 
        {
            int rnd = Random.Range(i, values.Length);
            tempValue = values[rnd];
            values[rnd] = values[i];
            values[i] = tempValue;
        }
    }
}