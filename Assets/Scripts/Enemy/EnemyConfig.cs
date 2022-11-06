using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Configuration")]
public class EnemyConfig : ScriptableObject
{
    public int[] oddsStep;
    public int currentOddsIndex = 0;
    public int checkInterval = 0;
    public int currentOdds = 0;

    public void IncrementOdds()
    {
        int min = 0;
        if(currentOddsIndex != 0)
        {
            min = oddsStep[currentOddsIndex-1];
        }
        int oddsIncrement = Random.Range(min, oddsStep[currentOddsIndex]);
        currentOdds += oddsIncrement;
    }

    public void IncrementOddsIndex()
    {
        if(currentOddsIndex == oddsStep.Length - 1)
        {
            return;
        }
        currentOddsIndex++;
    }
}
