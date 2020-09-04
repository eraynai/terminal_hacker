using UnityEngine;

public class Hacker : MonoBehaviour
{

    //Game Configuration Data
    string[] level1Passwords = {"books", "aisle", "self", "password", "font", "borrow"};
    string[] level2Passwords = { "cars", "food", "mitch", "house", "wild" };

    //Game State
    int level;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;
    string password;


    // Start is called before the first frame update
    void Start()
    {
        print(level1Passwords[0]);
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
        bool isValidLevelNumber = (input == "1" || input == "2");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please Choose a valid level");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            default:
                Debug.LogError("Invalid Case");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();

        }
        else
        {
            AskForPassword();
            
        }
    }


    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a Book...");
                Terminal.WriteLine(@"

    _______
   /      //
  /      //
 /______//
(______(/

");
                break;
            case 2:
                Terminal.WriteLine("Have a Cat....");
                Terminal.WriteLine(@"

    |\       /|  
    | \_____/ |
    (___  ^__^)
  _ )         (
(( /           \
 (    )  ||   ||
 '----' '--' '--'
");
                break;
            default:
                Debug.LogError("Help");
                break;
        }
        
    }
}
