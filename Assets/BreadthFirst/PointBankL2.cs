using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointBankL2 : MonoBehaviour
{
    
    [SerializeField] int  initialPoint=150;
   [SerializeField] int currntPoint;

    [SerializeField] TextMeshProUGUI displayScore;

     Castle castle;

    void Start() 
    {
         castle=FindObjectOfType<Castle>();
    }
    public int CurrentPoint    
    {
        get
            {
                return currntPoint;
            }
    }

    void Awake()
     {
         currntPoint=initialPoint;
         DisplayScore();
        
    }
   public void AddPoint(int count)
   
   {
       currntPoint+= Mathf.Abs(count); // converted negative into positive
       DisplayScore();

   }

    public void DedcuctPoint(int count)  // 
   
   {
       currntPoint-= Mathf.Abs(count); // converted negative into positive
       DisplayScore();


       if(currntPoint<0)// we lose the game
       {
           castle.BlastCastle();
           Invoke("GameOver",2f);
          //RestartGame();
           
       }

   }

   void DisplayScore()
   {
        displayScore.text="";
       displayScore.text="Score : "+currntPoint;
       if(currntPoint>=1000)// 
       {
           SceneManager.LoadScene("GameWin");
           
       }
   }

   public void GameOver()
   {
       SceneManager.LoadScene("GameOver");
   }

   void RestartGame()
   {
       LoadNextLevel();
    //    Scene currentScene=SceneManager.GetActiveScene();
    //    SceneManager.LoadScene(currentScene.buildIndex);
   }

   void LoadNextLevel()
   {
    //    int currentIndex =SceneManager.GetActiveScene().buildIndex;
    //    int nextSceneIndex= currentIndex+1;
    //    if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
    //    {
    //        nextSceneIndex=0;
    //    }
       SceneManager.LoadScene("Menu");
   }
}
