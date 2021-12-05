using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] int reward=20;
    [SerializeField] int penalty=20;
    // Start is called before the first frame update
    static int count=0;
    
    Castle castle;
    PointBank pointbank;

     void Awake() {
         castle=FindObjectOfType<Castle>();
        castle.DisablePrticle();
    }
    void Start()
    {
        pointbank =FindObjectOfType<PointBank>();
       
    }

    public void GetReward()  // when we hit enemy, we get points  
    {
        if(pointbank==null)
        {
            return;
        }
        pointbank.AddPoint(reward);

    }

    public void LossReward() // wehen enemy reach to the destination, we loss point
    {       
        
       count++;
      
       

        if(count==5)
        {
            Debug.Log("Enemy Count " + count);
            castle.BlastCastle();
            Invoke("GoToMenu",2f);

        }

          if(pointbank==null)
        {
           // castle.BlastCastle();
            return;
        }
        pointbank.DedcuctPoint(penalty);
        
      
        
    }

 void GoToMenu()
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