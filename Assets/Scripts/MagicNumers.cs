using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicNumers : MonoBehaviour
{
    [SerializeField] private Text label;
    [SerializeField] private Text title;
    [SerializeField] private Text instructions;

    [SerializeField] int maxSum = 50;

    int sum ;
    int countPressedButtonsQuantity = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Game2 = GetComponent<GameObject>();

        showTitleAndInstructions();
        
    }

    // Update is called once per frame
    void Update()
    {
        addValue();
        ShowSum();
        if (sum >= maxSum && Input.GetKeyDown(KeyCode.Space))
        {
            sum = 0;
            restartTheGame();
        }
    }

    void showTitleAndInstructions() 
    {
        title.text = "Давайте суммировать числа!";
        instructions.text = "Нажмите клавишу 1-9 чтобы их просуммировать. Ваша цель достичь 50.";
        label.text = "Текущая сумма 0! Нажмите цифру...";
    }
    void addValue()
    {
        if (sum >= maxSum ) 
        { 
            endGame();
        }
        
        else if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1)) 
        { 
            sum += 1;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2)) 
        { 
            sum += 2;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3)) 
        { 
            sum += 3;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4)) 
        { 
            sum += 4;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5)) 
        { 
            sum += 5;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6)) 
        { 
            sum += 6;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7)) 
        { 
            sum += 7;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8)) 
        { 
            sum += 8;
            countPressedButtonsQuantity++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9)) 
        { 
            sum += 9;
            countPressedButtonsQuantity++;
        }
    }

    void ShowSum()
    {
        if (sum < maxSum) 
        {
            label.text = "Текущая сумма " + sum + "!";
        }
        
    }
    void endGame()
    {
        title.text = "Поздравляю!";
        instructions.text = "Нажмите ПРОБЕЛ, чтобы начать сначала!";
        label.text = "Вы достигли 50! \n Количество слагаемых чисел " + countPressedButtonsQuantity + "!";
    }
    void restartTheGame()
    {
        countPressedButtonsQuantity = 0;
        showTitleAndInstructions();
    }
}
