using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int amountOfDays;
    public DayCycle dayCycle;
    public Inventory inventory;
    public TaskList taskList;
    public Dialog dialog;
    public EncounterController encounterController;

    public GameObject mainUI;
    public Text dayLabel;
    public GameObject endOfDayUI;
    public Text tasksCounter;
    public GameObject loseRiddleUI;
    public GameObject winRiddleUI;

    private int currentDay = 0;
    private bool dayHasStarted = true;
    private bool isFighting = false;

    void Start()
    {
        currentDay = 0;
        NextDay();
    }

    void Update()
    {
        if(dayHasStarted && !isFighting)
        {
            encounterController.CheckForEncounter((int)dayCycle.elapsedTime);
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
            loseRiddleUI.SetActive(true);
            return;
        }
        
        winRiddleUI.SetActive(true);
    }

    public void ContinueDay()
    {
        dayCycle.TogglePauseDay(false);
        isFighting = false;
    }

    public void EndDay()
    {
        mainUI.SetActive(false);
        endOfDayUI.SetActive(true);
        dayHasStarted = false;
        tasksCounter.text = taskList.GetCompletedTasks().ToString() + " / " + taskList.GetTotalTasks().ToString() + " Tasks Completed";
    }

    public void CheckForLoss()
    {
        if(taskList.GetCompletedTasks()/taskList.GetTotalTasks() == 1)
        {
            EndGame(false);
            return;
        }

        if(currentDay < amountOfDays)
        {
            NextDay();
            return;
        }
        
        EndGame(true);
    }

    public void NextDay()
    {
        currentDay++;
        dayLabel.text = "Day " + (currentDay < 10 ? "0" : "") + currentDay.ToString();
        inventory.Reset();
        taskList.UpdateTasks();
        endOfDayUI.SetActive(false);
        mainUI.SetActive(true);
        isFighting = false;
        dayHasStarted = true;
        dayCycle.StartDay();
        encounterController.ResetEncounterChances();
    }

    public void EndGame(bool success)
    {
        SceneManager.LoadScene("Menu");
    }
}
