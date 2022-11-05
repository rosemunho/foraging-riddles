using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayCycle : MonoBehaviour
{
    public GameController gameController;

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

    public Text time;

    public void StartDay()
    {
        timeStarted = DateTime.Now;
        dayHasStarted = true;
        isPaused = false;
        previousPauseDuration = 0;
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
            int elapsedTime = (currentTime.Hour*360 + currentTime.Minute*60 + currentTime.Second) - (pauseStarted.Hour*360 + pauseStarted.Minute*60 + pauseStarted.Second);
            previousPauseDuration += elapsedTime;
        }
    }

    void Update()
    {
        currentTime = DateTime.Now;
        if(dayHasStarted && !isPaused)
        {
            float elapsedTime = (currentTime.Hour*360 + currentTime.Minute*60 + currentTime.Second) - (timeStarted.Hour*360 + timeStarted.Minute*60 + timeStarted.Second) - previousPauseDuration;
            UpdateClock(elapsedTime);
        }
        
        if(Input.GetMouseButtonUp(1))
        {
            TogglePauseDay(!isPaused);
        }
    }

    public void UpdateClock(float elapsedTime)
    {
        float dayCompletion = elapsedTime / (realTimeDuration*60);
        float gameDayCompletion = dayCompletion * (dayDuration*60);

        if(Mathf.Approximately(dayCompletion, 1f))
        {
            EndDay();
            gameController.EndDay();
        }

        int currentGameTime = (startHour*60) + (int)Math.Floor(gameDayCompletion);

        int hours = currentGameTime / 60;
        currentGameTime -= hours * 60;
        int minutes = currentGameTime;
        time.text = (hours < 10 ? "0" : "") + hours.ToString() + ":" + (minutes < 10 ? "0" : "") + minutes.ToString();
    }

    public void EndDay()
    {
        dayHasStarted = false;
        isPaused = false;
        //TODO: Trigger Check Tasks
    }
}
