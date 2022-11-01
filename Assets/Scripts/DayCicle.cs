using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    // In Minutes
    public int realTimeDuration = 15;
    public int dayDuration = 12 * 60; // 12 hours
    public int startHour = 6 * 60; // 6h

    private DateTime timeStarted;
    private DateTime currentTime;
    private bool isRunning = false;

    private DateTime pauseStarted;
    private int previousPauseDuration = 0;
    private bool isPaused = false;

    public void StartDay()
    {
        timeStarted = DateTime.Now;
        isRunning = true;
        isPaused = false;
    }

    public void TogglePauseDay(bool pause)
    {
        isPaused = pause;
        if(pause)
        {
            pauseStarted = DateTime.Now;
        }
        else
        {
            int elapsedTime = (currentTime.Hour*60 + currentTime.Minute) - (pauseStarted.Hour*60 + pauseStarted.Minute);
            previousPauseDuration += elapsedTime;
        }
    }

    void Update()
    {
        currentTime = DateTime.Now;
        if(isRunning && !isPaused)
        {
            int elapsedTime = (currentTime.Hour*60 + currentTime.Minute) - (timeStarted.Hour*60 + timeStarted.Minute) - previousPauseDuration;
            UpdateClock(elapsedTime);
        }
    }

    public void UpdateClock(int elapsedTime)
    {
        float dayCompletion = elapsedTime / realTimeDuration;
        float gameDayCompletion = dayCompletion * dayDuration;

        if(Mathf.Approximately(gameDayCompletion, 1f))
        {
            EndDay();
        }

        int currentGameTime = startHour + (int)Math.Floor(gameDayCompletion);

        int hours = currentGameTime / 60;
        currentGameTime -= hours * 60;
        int minutes = currentGameTime;
        //TODO: set the Ui stuff
    }

    public void EndDay()
    {
        isRunning = false;
        isPaused = false;
        //TODO: Trigger Check Tasks
    }
}
