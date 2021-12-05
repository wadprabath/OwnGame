using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGrid : MonoBehaviour
{
  [SerializeField] Vector2Int size;
  [SerializeField] int editorGridSize=10;

 
      Dictionary<Vector2Int, Node> grid= new Dictionary<Vector2Int, Node>();
      public Dictionary<Vector2Int, Node> Grid
      {
          get{
              return grid;
          }
      }
  
    public int editorGridSise
    {
         get{
              return editorGridSize;
          }
    }

    void Awake()
     {
         BuildGrid();
          
      }

      public Node GetNode(Vector2Int coordinates)
      {
          if(grid.ContainsKey(coordinates))
          {
              return grid[coordinates];
          }
          return null;
      }

      public void Block(Vector2Int coordinates)
      {
          if(grid.ContainsKey(coordinates))
          {
              grid[coordinates].move=false;
          }
      }

         public void ResetNode()
          {
            
            foreach(KeyValuePair<Vector2Int,Node>entry in grid)
            {
                entry.Value.join=null;
                entry.Value.identify=false;
                entry.Value.road=false;
            }
        }
      public Vector2Int GetCoordinates(Vector3 location)
      {
          Vector2Int coordinates=new Vector2Int();
        coordinates.x=Mathf.RoundToInt(location.x / editorGridSise);
        coordinates.y=Mathf.RoundToInt(location.z/editorGridSise); //  x,z
         return coordinates;
      }
      
       public Vector3 getLocation(Vector2Int coordinates)
       {
         Vector3 location =new Vector3();
         location.x=coordinates.x*editorGridSise;
         location.z=coordinates.y*editorGridSise;
         return location;  
       }
      void BuildGrid()
      {
          for(int i=0; i<size.x ;i++)
          {
             for(int j=0;j<size.y;j++)
             {
                 Vector2Int coordinates= new Vector2Int(i,j);
                 grid.Add(coordinates,new Node(coordinates,true));

                
                // Debug.Log(grid[coordinates].coordinates+"="+ grid[coordinates].move);
             }
          }

      }
    // Start is called before the first frame update
    // [SerializeField] Node node;
    // void Start()
    // {
    //     Debug.Log(node.coordinates);
    //     Debug.Log(node.move);
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
  

}
