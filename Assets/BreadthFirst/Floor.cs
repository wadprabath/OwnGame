using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] bool curentLocation; // location true only for garden and false for road.

[SerializeField] SoldierL2 soldierL2; // adding tower object in edit mode

ManageGrid manageGrid;
FindRoad findRoad;
Vector2Int  coordinates =new Vector2Int();

private void Awake()
 {
    manageGrid=FindObjectOfType<ManageGrid>();
    findRoad=FindObjectOfType<FindRoad>();
}


 void Start() 
 {
     if(manageGrid!=null)
     {
         coordinates=manageGrid.GetCoordinates(transform.position);
         if(!curentLocation)
         {
             manageGrid.Block(coordinates);

         }
     }
    
}
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
        // if(curentLocation) // if gardern location true
        if(manageGrid.GetNode(coordinates).move && !findRoad.bolockRoad(coordinates) )
         {
             bool done = soldierL2.GenerateSoldier(soldierL2,transform.position);
             if(done)
             {
                manageGrid.Block(coordinates);
                findRoad.ReceiveResponse();
             }
            // curentLocation=!located;
          
            // Instantiate(soldier,transform.position,Quaternion.identity);// // user can place tower on the garden by clicking mouse
             //curentLocation=false; // avoiding duplication of tower to the same place
              //Debug.Log(transform.name);
         }
       // Debug.Log(transform.name);
    }
}
