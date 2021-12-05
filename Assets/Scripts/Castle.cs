using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
     [SerializeField] ParticleSystem particalSystem;
    // Start is called before the first frame update
    AudioSource audioSource;
    void Start()
    {
       audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void DisablePrticle()
    {
        var emission =particalSystem.emission;  
        emission.enabled=false;
    }
    public void BlastCastle()
    {
         var emission =particalSystem.emission;  
         emission.enabled=true;
         if(!audioSource.isPlaying) 
            {  
                             
                audioSource.Play();
            }
    }
}
