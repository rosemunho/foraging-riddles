using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Configuration")]
public class EnemyConfig : ScriptableObject
{
    public int[] oddsStep;
    //TODO: trigger increment index from day cycle
    public int currentOddsIndex = 0;
    // In Minutes
    public int checkInterval = 0;
    public int currentOdds = 0;
}
