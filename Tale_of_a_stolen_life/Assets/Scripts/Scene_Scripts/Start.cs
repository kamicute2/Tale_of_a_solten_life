using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{
    public  void GoToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("New_Game");
    }
    public void Quit()
    {
        Application.Quit();
}
    }
    
