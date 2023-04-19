using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public void Credit()
    {
        SceneManager.LoadScene(3);
    }


    public void Options()
    {
        // SceneManager.LoadScene(2);
        print("Pending");
    }


    public void ExitGame()
    {
        print("QUIT");
        Application.Quit();
        
    }

}//class
