using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] List<WayPoints> floorLocation= new List<WayPoints>();
   // [SerializeField] float waitingTime=1f;
   [SerializeField] [Range(0f,5f)] float enemySpeed=5f; // range beteen 0 and 5, it avoid minus values

   Enemy enemy;
    // Start is called before the first frame update
    // void Start()
    // {
    //     //Debug.Log("Starting");
    //     //DisplayLocation();
    //    // InvokeRepeating("DisplayLocation",0,1f);


    //     FindRoad();
    //     ReturnToBegining();
    //    StartCoroutine(DisplayLocation()); // like invokerepeating
    //    // Debug.Log("Finnishing");

    // }
   void Start() 
   {
     enemy =GetComponent<Enemy>();
      
    }
    void OnEnable()
     {
        FindRoad();
        ReturnToBegining();
       StartCoroutine(DisplayLocation()); // like invokerepeating
       // Debug.Log("Finnishing");

    }

    void FindRoad()
    {
      floorLocation.Clear();
      GameObject ParentRoad= GameObject.FindGameObjectWithTag("Road"); // tage Road object as Road in editor
     // GameObject[] waypaoints = GameObject.FindGameObjectsWithTag("Road");

      foreach(Transform childRoad in ParentRoad.transform)
      {
          WayPoints wayPoints=childRoad.GetComponent<WayPoints>();

          if(wayPoints !=null)
          {
            floorLocation.Add(wayPoints);
          }
      }

      // foreach(GameObject waypoint in waypaoints)
      // {
      //   floorLocation.Add(waypoint.GetComponent<WayPoints>());
      // }
    }

    void ReturnToBegining() //  start from begining of the road
    {
      transform.position=floorLocation[0].transform.position;
    }
    IEnumerator  DisplayLocation() // return something that syste that count
    {
        foreach(WayPoints waypoints in floorLocation)
        {
          // Debug.Log(waypoints.name);
          Vector3 StartLocation=transform.position;
          Vector3 FinnishLocation=waypoints.transform.position;
          float moving=0f;

          transform.LookAt(FinnishLocation); // move enemy face to correct direction

          while(moving<1f) // creating a slow moving
          {
             moving+=Time.deltaTime *enemySpeed;
             transform.position=Vector3.Lerp(StartLocation,FinnishLocation,moving);

             yield return new WaitForEndOfFrame();

          }

          //Destroy(gameObject);

            
            //transform.position=waypoints.transform.position;

           // yield return new WaitForSeconds(waitingTime); //  give up controll and come back after one second (go to top and come back)
        }
        //Destroy(gameObject);
        enemy.LossReward(); // we loss our point when enemy reach to the distination
        gameObject.SetActive(false);
    }
}
