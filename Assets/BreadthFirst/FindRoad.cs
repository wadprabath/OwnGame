using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRoad : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Node currentFindNode;
    Vector2Int[] direction ={Vector2Int.right,Vector2Int.left,Vector2Int.up,Vector2Int.down};

    [SerializeField] Vector2Int startPoint;
    public Vector2Int StartPoint
    {
        get {return startPoint; }
    }
     [SerializeField] Vector2Int endpoint;

      public Vector2Int EndPoint
      {
          get{return endpoint;}
      }

    Node startNode;
    Node endNode;
    Dictionary<Vector2Int,Node> grid = new Dictionary<Vector2Int, Node>();
    Dictionary<Vector2Int,Node> arrived=new Dictionary<Vector2Int, Node>();
    Queue<Node> boarder =new Queue<Node>();
    ManageGrid manageGrid ;
     void Awake() 
     {
        manageGrid =FindObjectOfType<ManageGrid>();
        if(manageGrid !=null)
        {
            grid=manageGrid.Grid;
            startNode=grid[startPoint];
            endNode=grid[endpoint];

            // startNode.move=true;  // can move to find path, but cant locate soldiers
            // endNode.move=true;
        }
       // startNode=new Node(startPoint,true);
       // endNode=new Node(endpoint,true);
    }

    void Start()
    {
       // startNode=manageGrid.Grid[startPoint];
       // endNode=manageGrid.Grid[endpoint];
       // Identify();
    //    BreadthFirst();
    //    createRoad();
       GetNewRoad();
    }

    public List<Node> GetNewRoad()
    {
        return GetNewRoad(startPoint);
        // manageGrid.ResetNode();
        // BreadthFirst(startPoint);
        // return createRoad();
    }
     public List<Node> GetNewRoad(Vector2Int coordinates)
    {
        manageGrid.ResetNode();
        BreadthFirst(coordinates);
        return createRoad();
    }
    void Identify()
    {
        List<Node>nextNodes=new List<Node>();
        foreach(Vector2Int direction in direction)
        {
            Vector2Int nextNodeCoordinates= currentFindNode.coordinates+direction; //Eg. if current noode (2,2) and direction is right then next node (3,2)   

            if(grid.ContainsKey(nextNodeCoordinates))
            {
                    nextNodes.Add(grid[nextNodeCoordinates]);


                   // grid[nextNodeCoordinates].identify=true;
                   // grid[currentNode.coordinates].road=true;
            } 

            foreach(Node nextNode in nextNodes)
            {
                if(!arrived.ContainsKey(nextNode.coordinates)&& nextNode.move)
                {
                    nextNode.join=currentFindNode;
                    arrived.Add(nextNode.coordinates, nextNode);
                    boarder.Enqueue(nextNode);
                }
            }

        }


    }

    void BreadthFirst(Vector2Int coordinates)
    {
         startNode.move=true;  // can move to find path, but cant locate soldiers
        endNode.move=true;

        boarder.Clear();
        arrived.Clear();

        bool executing=true;
         boarder.Enqueue(grid[coordinates]);
      //  boarder.Enqueue(startNode);
        //arrived.Add(startPoint,startNode);

          arrived.Add(coordinates,grid[coordinates]);

        while(boarder.Count>0 && executing)
        {
            currentFindNode=boarder.Dequeue();
            currentFindNode.identify=true;
            Identify();
            if(currentFindNode.coordinates==endpoint)
            {
                executing=false;
            }
        }
    }

    List<Node> createRoad()
    {
        List<Node> road=new List<Node>();
        Node currentNode= endNode;
        road.Add(currentNode);
        currentNode.road=true;

        while(currentNode.join !=null)
        {
            currentNode=currentNode.join;
            road.Add(currentNode);
            currentNode.road=true;
        }

        road.Reverse();
        return road;


    }

    public bool bolockRoad(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            bool lastState=grid[coordinates].move;

            grid[coordinates].move=false;
            List<Node> newRoad =GetNewRoad();
            grid[coordinates].move=lastState;

            if(newRoad.Count<=1) //road block
            {
                GetNewRoad();
                return true;
            }
            

        }
        return false;
    }

    public void ReceiveResponse()
    {
            BroadcastMessage("CalulateRoad",false,SendMessageOptions.DontRequireReceiver);
    }
 
}
