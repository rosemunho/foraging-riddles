using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    public EnemyConfig enemy;
    public GameController gameController;
    public AudioSource encounterAudio;

    private DateTime lastCheck;

    public void CheckForEncounter(int timeElapsed)
    {
        DateTime currentTime = DateTime.Now;
        if((lastCheck.Hour == currentTime.Hour && lastCheck.Minute == currentTime.Minute && lastCheck.Second == currentTime.Second)
            || timeElapsed % enemy.checkInterval != 0)
        {
            return;
        }
        
        lastCheck = DateTime.Now;
        if(enemy.currentOdds >= 100)
        {
            gameController.StartFight();
            enemy.currentOdds = 0;
            enemy.IncrementOddsIndex();
            encounterAudio.Play();
        }
        else
        {
            enemy.IncrementOdds();
        }
    }

    public void ResetEncounterChances()
    {
        enemy.currentOddsIndex = 0;
        enemy.currentOdds = 0;
        lastCheck = DateTime.Now;
    }
}
