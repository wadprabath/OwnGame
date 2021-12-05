using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTank : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] ParticleSystem paticalSys;
    
AudioSource audioSource2;
    // Update is called once per frame

     void Start() {
        var emission =paticalSys.emission;    

         emission.enabled=false; 
          audioSource2=GetComponent<AudioSource>();
    }
     void Awake() {
        Invoke("BlastTank",3f);  // this is only for trailer recording
    }
    void Update()
    {

        transform.Rotate(new Vector3(0f,30f,0f)*Time.deltaTime);
    }


   void BlastTank()
   {
        var emission =paticalSys.emission;    

         emission.enabled=true; 
          if(!audioSource2.isPlaying) 
            {  
                             
                audioSource2.Play();
            }
   }

}
