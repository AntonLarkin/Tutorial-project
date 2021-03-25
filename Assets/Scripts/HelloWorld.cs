using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    [SerializeField] private int minimalValue = 1;
    [SerializeField] private int maximalValue = 1000;
    int guessValue;
    [SerializeField] private Text label;
    // Start is called before the first frame update
    void Start()
    {
        print("Guess the number from "  + minimalValue + " to " + maximalValue);
        calculateNextPossibleNumber();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            minimalValue = guessValue;
            calculateNextPossibleNumber();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maximalValue = guessValue;
            calculateNextPossibleNumber();
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            print("Great! Your numer is " + guessValue);
        }
    }

    void calculateNextPossibleNumber()
    {
        guessValue = (minimalValue + maximalValue) / 2;
        print("Is your number " + guessValue + "?");
        label.text = "Is your number " + guessValue + "?";
    }
}
