using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListItem : MonoBehaviour
{
    public Task task = null;
    public Text text;
    public GameObject image;

    public void UpdateTask(Task newTask)
    {
        if(newTask == null)
        {
            task = null;
            gameObject.SetActive(false);
            return;
        }
        task = newTask;
        text.text = "Find " + task.desiredAmount.ToString() + " " + task.item.itemName + "s.";
    }

    void Update()
    {
        if(task != null)
        {
            task.CheckComplete();
            image.SetActive(task.completed);
        }
    }

    public bool IsCompleted()
    {
        return task != null && task.completed;
    }
}
