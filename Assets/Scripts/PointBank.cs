using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PointBank : MonoBehaviour
{
    [SerializeField] int  initialPoint=100;
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
           Invoke("GameOver",1f);
          //RestartGame();
           
       }
       if(currntPoint>=150)// we Won the game
       {

        //   int current=SceneManager.GetActiveScene().buildIndex;
        //   SceneManager.UnloadSceneAsync(current); 
         // 
        
           
       }

   }

   void DisplayScore()
   {
        displayScore.text="";
       displayScore.text="Score : "+currntPoint;
        if(currntPoint>=500)// we Won the game
       {
            SceneManager.LoadScene("GameWin");
       }
   }

   void GameOver()
   {
       SceneManager.LoadScene("GameOver");
      // LoadNextLevel();
    //    Scene currentScene=SceneManager.GetActiveScene();
    //    SceneManager.LoadScene(currentScene.buildIndex);
   }

   void LoadNextLevel()
   {
       int currentIndex =SceneManager.GetActiveScene().buildIndex;
       int nextSceneIndex= currentIndex+1;
       if(nextSceneIndex==SceneManager.sceneCountInBuildSettings)
       {
           nextSceneIndex=0;
       }
       SceneManager.LoadScene(nextSceneIndex);
   }
}
