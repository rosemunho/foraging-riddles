using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Riddle[] availableRiddles;

    public Text prompt;
    public Button[] buttons;
    public bool useQuestionPrompt = true;

    public GameController gameController;
    public GameObject dialogUI;
    public GameObject mainUI;

    public void StartDialog()
    {
        ChooseRiddles();
        mainUI.SetActive(false);
        dialogUI.SetActive(true);
    }

    private void ChooseRiddles()
    {
        Shuffle<Riddle>(availableRiddles);
        Shuffle<Button>(buttons);
        if (useQuestionPrompt)
        {
            prompt.text = availableRiddles[0].question;
        }
        else
        {
            prompt.text = availableRiddles[0].answer;
        }
        for(int i = 0; i < buttons.Length; i++)
        {
            bool isCorrect = i == 0;
            if (useQuestionPrompt)
            {
                buttons[i].GetComponent<Text>().text = availableRiddles[i].answer;
            }
            else
            {
                buttons[i].GetComponent<Text>().text = availableRiddles[i].question;
            }
            buttons[i].onClick.AddListener(() => ChooseOption(isCorrect));
        }
    }

    private static void Shuffle<T>(T[] array)
    {
        T temp;
        for (int i = 0; i < array.Length - 1; i++) 
        {
            int rnd = Random.Range(i, array.Length);
            temp = array[rnd];
            array[rnd] = array[i];
            array[i] = temp;
        }
    }

    public void ChooseOption(bool isCorrect)
    {
        dialogUI.SetActive(false);
        mainUI.SetActive(true);
        gameController.WinFight(isCorrect);
    }
}
