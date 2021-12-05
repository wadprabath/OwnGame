using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverL2 : MonoBehaviour
{
      //  [SerializeField] List<Floor> floorLocation= new List<Floor>();
         List<Node> floorLocation= new List<Node>();
   // [SerializeField] float waitingTime=1f;
   [SerializeField] [Range(0f,20f)] float enemySpeed=20f; // range beteen 0 and 5, it avoid minus values

   EnemyL2 enemy;
   ManageGrid manageGrid;
   FindRoad findRoad;
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

  
  //  void Start() 
  //  {
  //    enemy =GetComponent<Enemy>();
      
  //   }
    void OnEnable()
     {
        ReturnToBegining();
        CalulateRoad(true); // re calulate for alternative path
       
      
       // Debug.Log("Finnishing");

    }
     void Awake()   
   {
     enemy =GetComponent<EnemyL2>();
     manageGrid =FindObjectOfType<ManageGrid>();
     findRoad=FindObjectOfType<FindRoad>();
      
    }

    void CalulateRoad(bool resetRoad)
    {
      Vector2Int coordinate=new Vector2Int();

      if(resetRoad)
      {
        coordinate=findRoad.StartPoint;
      }
      else
      {
        coordinate=manageGrid.GetCoordinates(transform.position);
      }

      StopAllCoroutines();
      floorLocation.Clear();
      floorLocation=findRoad.GetNewRoad(coordinate);
       StartCoroutine(DisplayLocation()); // like invokerepeating
    //   GameObject ParentRoad= GameObject.FindGameObjectWithTag("Road"); // tage Road object as Road in editor
    //  // GameObject[] waypaoints = GameObject.FindGameObjectsWithTag("Road");

    //   foreach(Transform childRoad in ParentRoad.transform)
    //   {
    //       Floor floorTile=childRoad.GetComponent<Floor>();

    //       if(floorTile !=null)
    //       {
    //         floorLocation.Add(floorTile);
    //       }
    //   }

      // foreach(GameObject waypoint in waypaoints)
      // {
      //   floorLocation.Add(waypoint.GetComponent<WayPoints>());
      // }
    }

    void ReturnToBegining() //  start from begining of the road
    {
      //transform.position=floorLocation[0].transform.position;
      transform.position=manageGrid.getLocation(findRoad.StartPoint);
    }
    IEnumerator  DisplayLocation() // return something that syste that count
    {
        for(int i=1;i<floorLocation.Count;i++)
        {
          // Debug.Log(waypoints.name);
          Vector3 StartLocation=transform.position;

          Vector3 FinnishLocation=manageGrid.getLocation(floorLocation[i].coordinates);
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
