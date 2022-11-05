using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int amountOfDays;
    public DayCycle dayCycle;
    public Inventory inventory;
    public TaskList taskList;
    public EncounterController encounterController;

    public GameObject endOfDayGO;

    private int currentDay = 0;
    private bool dayHasStarted = true;

    void Start()
    {
        NextDay();
    }

    void Update()
    {
        if(!dayHasStarted && Input.GetMouseButtonUp(0))
        {
            if(currentDay < amountOfDays)
            {
                NextDay();
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void EndDay()
    {
        endOfDayGO.SetActive(true);
        dayHasStarted = false;
    }

    public void NextDay()
    {
        currentDay++;
        inventory.Reset();
        taskList.UpdateTasks();
        endOfDayGO.SetActive(false);
        dayHasStarted = true;
        dayCycle.StartDay();
    }
}
