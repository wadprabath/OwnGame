using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // serialize node class , then grid manager can acess
public class Node 
{
       
     public bool road;
    public bool move;

    public Node join;
    public bool identify;
    public Vector2Int coordinates;

  public Node(Vector2Int _coordinates, bool _move)
  {

      this.coordinates=_coordinates;
      this.move=_move;
  }


}
