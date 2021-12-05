using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetWeapon : MonoBehaviour
{
    
    [SerializeField] Transform soldier;
    //[SerializeField] Transform target;
    Transform target;

    [SerializeField] float weaponRange=15f;
    [SerializeField] ParticleSystem paticalSys;

    AudioSource audioSource;
    // Start is called before the first frame update
    // void Start()
    // {
    //     target=FindObjectOfType<Enemy>().transform;
    //     //target=FindObjectOfType<Mover>().transform; // mover is script name
        
    // }

     void Start()
     {
         audioSource=GetComponent<AudioSource>(); 
         var emission =paticalSys.emission;    

         emission.enabled=false; 
        

        
    }

       
    // Update is called once per frame
    void Update()
    {
        AimNearestTarget();
        
        
      GetTarget(); // *** commented for testing only
    }
     void AimNearestTarget()
    {
        Enemy[] enemies=FindObjectsOfType<Enemy>();
        Transform nearestTarget=null;
        float maxLenghth=Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetLenght=Vector3.Distance(transform.position, enemy.transform.position);

            if(targetLenght<maxLenghth)
            {
                nearestTarget=enemy.transform;

                maxLenghth=targetLenght;
            }
        }

        target=nearestTarget;

    }
     void GetTarget()
    {
        float targetLenght= Vector3.Distance(transform.position,target.position);
        soldier.LookAt(target);

      
        
        if(targetLenght<weaponRange)
        {
           
            if(Input.GetKeyDown(KeyCode.Space))
        {
            AttackEnemy(true);
           // Label.enabled=!Label.IsActive(); //view hide label          
           
        } 
          if(Input.GetKeyUp(KeyCode.Space))
             {
                 AttackEnemy(false);
             }       
      
           
        }
          else
        {
            AttackEnemy(false);
            Debug.Log("gun shot off");
        }
       
    }

    void AttackEnemy(bool active) // particals work only when enemy in range
    {
        var emission =paticalSys.emission;    

         emission.enabled=active;

         if(!audioSource.isPlaying)
         {
             if(active) 
             {
                   
                audioSource.Play(); 
                 

             }

             
         }
        
        
         
    }
}
