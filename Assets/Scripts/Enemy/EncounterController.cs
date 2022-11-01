using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterController : MonoBehaviour
{
    public EnemyConfig[] availableEnemies;

    public void CheckForEncounter(int timeElapsed)
    {
        foreach(EnemyConfig enemy in availableEnemies)
        {
            if(timeElapsed % enemy.checkInterval != 0)
            {
                continue;
            }
            if(enemy.currentOdds >= 100)
            {
                // trigger attack dialog
                enemy.currentOdds = 0;
            }
            else
            {
                enemy.currentOdds += enemy.oddsStep[enemy.currentOddsIndex];
            }
        }
    }

    public void ResetEncounterChances()
    {
        foreach(EnemyConfig enemy in availableEnemies)
        {
            enemy.currentOddsIndex = 0;
            enemy.currentOdds = 0;
        }
    }
}
