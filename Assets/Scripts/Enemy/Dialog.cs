using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Riddle riddle;
    public Riddle[] dummyRiddles;

    //TODO: label for the other thing
    public Button[] buttons;

    //TODO: public void ChooseRiddles() {}

    public void SetOptions()
    {
        //TODO: complete

        // set label text = riddle.question or riddle.answer

        Shuffle();

        //buttons[0].text = riddle.answer or riddle.question
        //set button behaviour
        for(int i = 1; i < buttons.Length; i++)
        {
            //buttons[i].text = dummyRiddles[i-1].answer or question
            //set bad button behaviour
        }
    }

    public void Shuffle()
    {
        Button tempButton;
        for (int i = 0; i < buttons.Length - 1; i++) 
        {
            int rnd = Random.Range(i, buttons.Length);
            tempButton = buttons[rnd];
            buttons[rnd] = buttons[i];
            buttons[i] = tempButton;
        }
    }
}
