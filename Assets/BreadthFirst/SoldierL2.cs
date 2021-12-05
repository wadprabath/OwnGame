using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierL2 : MonoBehaviour
{
    [SerializeField] int cost=50;

  
  public bool GenerateSoldier(SoldierL2 soldier2, Vector3 position)
   {
       PointBankL2 pointBank=FindObjectOfType<PointBankL2>();

       if(pointBank==null)
       {
           return false;
       }
       if(pointBank.CurrentPoint>=cost)
       {
            Instantiate(soldier2.gameObject,position,Quaternion.identity);
            pointBank.DedcuctPoint(cost); // solder has a value, when we add a solder, the value is deducted from our point bank
            return true;
       }

       return false;
   }

  

  
}
