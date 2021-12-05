using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLevel : MonoBehaviour
{
    
   public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene 1");
    }
    public void GoToNextLevel()
    {
         SceneManager.LoadScene("Level2");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
