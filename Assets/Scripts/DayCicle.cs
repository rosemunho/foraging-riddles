using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCicle : MonoBehaviour
{
    // In Minutes
    public int realTimeDuration = 15;
    // In Hours
    public int dayDuration = 12;
    public int startHour = 6;

    private DateTime timeStarted;
    private DateTime currentTime;
    private bool dayHasStarted = false;

    private DateTime pauseStarted;
    private int previousPauseDuration = 0;
    private bool isPaused = false;

    public void StartDay()
    {
        timeStarted = DateTime.Now;
        dayHasStarted = true;
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
        if(dayHasStarted && !isPaused)
        {
            int elapsedTime = (currentTime.Hour*60 + currentTime.Minute) - (timeStarted.Hour*60 + timeStarted.Minute) - previousPauseDuration;
            UpdateClock(elapsedTime);
            //TOOO: check enemy encounters
        }
    }

    public void UpdateClock(int elapsedTime)
    {
        float dayCompletion = elapsedTime / realTimeDuration;
        float gameDayCompletion = dayCompletion * (dayDuration*60);

        if(Mathf.Approximately(gameDayCompletion, 1f))
        {
            EndDay();
        }

        int currentGameTime = (startHour*60) + (int)Math.Floor(gameDayCompletion);

        int hours = currentGameTime / 60;
        currentGameTime -= hours * 60;
        int minutes = currentGameTime;
        //TODO: set the Ui stuff
    }

    public void EndDay()
    {
        dayHasStarted = false;
        isPaused = false;
        //TODO: Trigger Check Tasks

    }
}
