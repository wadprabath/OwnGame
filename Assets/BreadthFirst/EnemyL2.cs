using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyL2 : MonoBehaviour
{
     [SerializeField] int reward=20;
    [SerializeField] int penalty=20;
    // Start is called before the first frame update
    static int count=0;
    
    Castle castle;
    PointBankL2 pointbank;

     void Awake() {
         castle=FindObjectOfType<Castle>();
        castle.DisablePrticle();
    }
    void Start()
    {
        pointbank =FindObjectOfType<PointBankL2>();
       
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
            
            Invoke("GameOver",1.5f);

        }

          if(pointbank==null)
        {

           // castle.BlastCastle();
            return;
        }
        pointbank.DedcuctPoint(penalty);
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
