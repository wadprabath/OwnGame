using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyL2))]
public class EnemyHitL2 : MonoBehaviour
{
        [SerializeField] int maxHitScore=5;

    [SerializeField] int gunShotIncrement=2;

  //  [SerializeField] int currentHitScore=0;

  int currentHitScore=0;

   [SerializeField] ParticleSystem paticalSystem;

    EnemyL2 enemy;
    
    AudioSource audioSource2;
    // Start is called before the first frame update
    // void Start()
    // {
    //     currentHitScore=maxHitScore;
    // }

    
      void OnEnable() {
         
        currentHitScore=maxHitScore;
     }
 
     void Start() 
    {

        var emission =paticalSystem.emission;  
        emission.enabled=false;

        enemy=GetComponent<EnemyL2>();
       
       
        audioSource2=GetComponent<AudioSource>();
    }
  private void OnParticleCollision(GameObject other)
   {
     
      ExecuteHit();     
      
  }

 

  void ExecuteHit()
  {
      currentHitScore--; // need to activae send collison message text box in particale system under collion
     //  Debug.Log(""+currentHitScore);

      // var emission =paticalSystem.emission;  
      // emission.enabled=false;

     if(currentHitScore<=0)
      {
         var emission =paticalSystem.emission;  
         emission.enabled=true;
          //Destroy(gameObject);
         
          // StartCoroutine (Blast());
            // gameObject.SetActive(false); 
            if(!audioSource2.isPlaying) 
            {  
                             
                audioSource2.Play();
               
                Debug.Log("Max Hit Count "+currentHitScore);
                Invoke("DestroyTank",audioSource2.clip.length);
            }         
        
        
         
      }
  }

  void DestroyTank()
  {
      var emission =paticalSystem.emission;  
      emission.enabled=false;
      gameObject.SetActive(false); 
       maxHitScore+=gunShotIncrement; // 1st tank needs five gun shot to destroy, 2nd tank needs 7 gun shots to destroy
      enemy.GetReward(); // when we hit enemy, we can get points 
     
  }

//  IEnumerator Blast(){
//          audioSource2.Play ();
//          yield return new WaitWhile (()=> audioSource2.isPlaying);
//          audioSource2.Stop();
//           gameObject.SetActive(false);
//          //do something
//      }

}
