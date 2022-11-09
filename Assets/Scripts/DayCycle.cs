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
    public float elapsedTime = 0;

    private DateTime timeStarted;
    private DateTime lastUpdate;
    private DateTime currentTime;
    private bool dayHasStarted = false;

    private DateTime pauseStarted;
    private float previousPauseDuration = 0;
    private bool isPaused = false;

    public Text time;

    public void StartDay()
    {
        timeStarted = DateTime.Now;
        lastUpdate = DateTime.Now;
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
            float elapsedPauseTime = (currentTime.Hour*360 + currentTime.Minute*60 + currentTime.Second) -
                    (pauseStarted.Hour*360 + pauseStarted.Minute*60 + pauseStarted.Second);
            previousPauseDuration += elapsedPauseTime;
        }
    }

    void Update()
    {
        currentTime = DateTime.Now;
        if(dayHasStarted && !isPaused &&
            !(currentTime.Hour == lastUpdate.Hour && currentTime.Minute == lastUpdate.Minute && currentTime.Second == lastUpdate.Second))
        {
            lastUpdate = currentTime;
            elapsedTime = (currentTime.Hour*360 + currentTime.Minute*60 + currentTime.Second) -
                	(timeStarted.Hour*360 + timeStarted.Minute*60 + timeStarted.Second) - previousPauseDuration;
            UpdateClock();
        }
    }

    public void UpdateClock()
    {
        float dayCompletion = elapsedTime / (realTimeDuration*60);
        if(dayCompletion > 1f)
        {
            EndDay();
            gameController.EndDay();
            return;
        }

        float gameDayCompletion = dayCompletion * (dayDuration*60);
        int currentGameTime = (startHour*60) + (int)Math.Round(gameDayCompletion);

        int hours = currentGameTime / 60;
        currentGameTime -= hours * 60;
        int minutes = currentGameTime;
        time.text = (hours < 10 ? "0" : "") + hours.ToString() + ":" + (minutes < 10 ? "0" : "") + minutes.ToString();
    }

    public void EndDay()
    {
        dayHasStarted = false;
        isPaused = false;
    }
}
