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
    public Dialog dialog;
    public EncounterController encounterController;

    public GameObject endOfDayUI;
    public GameObject lossUI;

    private int currentDay = 0;
    private bool dayHasStarted = true;
    private bool isFighting = false;

    void Start()
    {
        NextDay();
    }

    void Update()
    {
        if(dayHasStarted && !isFighting)
        {
            encounterController.CheckForEncounter((int)dayCycle.elapsedTime);
        }
        else if(!dayHasStarted && Input.GetMouseButtonUp(0))
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

    public void StartFight()
    {
        dayCycle.TogglePauseDay(true);
        dialog.StartDialog();
        isFighting = true;
    }

    public void WinFight(bool win)
    {
        if(!win)
        {
            lossUI.SetActive(true);
            return;
        }

        dayCycle.TogglePauseDay(false);
        isFighting = false;
    }

    public void EndDay()
    {
        endOfDayUI.SetActive(true);
        dayHasStarted = false;
    }

    public void NextDay()
    {
        currentDay++;
        inventory.Reset();
        taskList.UpdateTasks();
        endOfDayUI.SetActive(false);
        lossUI.SetActive(false);
        isFighting = false;
        dayHasStarted = true;
        dayCycle.StartDay();
        encounterController.ResetEncounterChances();
    }
}
