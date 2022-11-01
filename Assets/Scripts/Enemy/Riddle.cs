using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Riddle")]
public class Riddle : ScriptableObject
{
    public string question = "";
    public string  answer = "";
}