using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;


    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What Would You Like to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter Your Selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            NewMethod(input);
        }
        else if(currentScreen == Screen.Password)
        {
            Debug.Log("Calling this function");
            CheckPassword(input);

        }
    }

    void NewMethod(string input)
    {
        if (input == "1")
        {
            level = 1;
            password = "dog";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "cat";
            StartGame();
        }
        else
        {
            Terminal.WriteLine("Please Choose a valid level");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            Terminal.WriteLine("Congratulations, Well Done");
            Debug.Log("Are you being called");
        }
        else
        {
            Terminal.WriteLine("Wrong Password, try again");
            Debug.Log("Are you being here");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
