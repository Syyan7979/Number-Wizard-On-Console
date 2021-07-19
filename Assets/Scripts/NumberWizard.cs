using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    // Config Parameters
    [SerializeField] int minimum = 1, upper = 1000;
    int maximum;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        maximum = upper;
        Debug.Log("Welcome to Number Wizard");
        Debug.Log("I will try to guess your number ma dude!!!");
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (guess == upper - 1)
            {
                guess = upper;
                minimum = guess;
                DisplayGuess(guess);
            } else
            {
                minimum = guess;
                guess = GuessCalc(minimum, maximum);
                DisplayGuess(guess);
            }
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            maximum = guess;
            guess = GuessCalc(minimum, maximum);
            DisplayGuess(guess);
        } else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("I'm one smart Mother Fucker");
            ResetGame();
        }
    }

    int GuessCalc(int minVal, int maxVal)
    {
        return (minVal + maxVal) / 2;
    }

    void ResetGame()
    {
        minimum = 1;
        maximum = upper;
        Debug.Log($"Pick a number between {minimum} and {upper}");
        guess = GuessCalc(minimum, maximum);
        DisplayGuess(guess);
    }

    void DisplayGuess(int guess)
    {
        Debug.Log($"My guess is: {guess}");
        Debug.Log("If my guess is wrong press arrow up key if your number is higher and arrow down key if it is lower, otherwise press enter");
    }
}
