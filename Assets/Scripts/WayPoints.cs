using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

[SerializeField] bool curentLocation; // location true only for garden and false for road.

[SerializeField] Soldier soldier; // adding tower object in edit mode



public bool CurentLocation
{
    get
    {
        return curentLocation;

    }
}

public bool GetCurentLocaion()
{
    return curentLocation;
}
    void OnMouseDown()
     {
         if(curentLocation) // if gardern location true
         {
             bool located = soldier.GenerateSoldier(soldier,transform.position);
             curentLocation=located;
            // Instantiate(soldier,transform.position,Quaternion.identity);// // user can place tower on the garden by clicking mouse
             //curentLocation=false; // avoiding duplication of tower to the same place
              //Debug.Log(transform.name);
         }
       // Debug.Log(transform.name);
    }
//   private void OnMouseOver() 
//   {
//       Debug.Log(transform.name);
//   }
}
