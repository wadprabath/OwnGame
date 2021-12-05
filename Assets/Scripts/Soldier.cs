using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] int cost=50;
  public bool GenerateSoldier(Soldier soldier, Vector3 position)
   {
       PointBank pointBank=FindObjectOfType<PointBank>();

       if(pointBank==null)
       {
           return false;
       }
       if(pointBank.CurrentPoint>=cost)
       {
            Instantiate(soldier.gameObject,position,Quaternion.identity);
            pointBank.DedcuctPoint(cost); // solder has a value, when we add a solder, the value is deducted from our point bank
            return true;
       }

       return false;

       
   }
}
