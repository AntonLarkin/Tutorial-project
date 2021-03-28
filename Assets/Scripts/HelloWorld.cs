using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private int minimalValue = 1;
    [SerializeField] private int maximalValue = 1000;
    int guessValue;
    int countGuessesQuantity = 0;
    [SerializeField] private Text label;
    [SerializeField] private Text title;
    [SerializeField] private Text instructions;

    // Start is called before the first frame update
    void Start()
    {
        showTitleAndInstructions();
        calculateNextPossibleNumber();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            endGame();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            minimalValue = 1;
            maximalValue = 1000;
            restartTheGame();
            calculateNextPossibleNumber();
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minimalValue = guessValue;
            calculateNextPossibleNumber();
            countGuessesQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maximalValue = guessValue;
            calculateNextPossibleNumber();
            countGuessesQuantity++;
        }
        
        
    }

    void calculateNextPossibleNumber()
    {

        guessValue = (minimalValue + maximalValue) / 2;
        label.text = "Загаданное вами число " + guessValue + "?";
    }

    /*void showTheNameOfTheGame()
    {
        title.text = "Let's guess the number from " + minimalValue + " to " + maximalValue;
    }
    void showInsruction()
    {
        instructions.text = "Press ArrowUp, if your number is higer, ArrowDown, if your number is lower. \n Press ENTER, if the number is correct.";
    }*/
    void showTitleAndInstructions()
    {
        title.text = "Давайте выберем число от " + minimalValue + " до " + maximalValue;
        instructions.text = "Нажмите СТРЕЛКУ ВВЕРХ, если число больше того, что на экране;\nСТРЕЛКУ ВНИЗ, если число меньше того, что на экране.\n Нажмите ВВОД, если на экране ваше число.";
    }
    void endGame()
    {
        title.text = "Поздравляю!";
        instructions.text = "Нажмите пробел, чтобы начать сначала!";
        label.text = "Ваше число " + guessValue + "! \n Количество попыток " + countGuessesQuantity + "!";

    }
    void restartTheGame()
    {
        countGuessesQuantity = 0;
        showTitleAndInstructions();
    }
}
