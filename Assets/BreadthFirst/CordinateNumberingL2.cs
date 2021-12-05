using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro; // access to text mesh pro

[ExecuteAlways]
public class CordinateNumberingL2 : MonoBehaviour
{
    TextMeshPro Label;
    Vector2Int coordinates= new Vector2Int();
   
    ManageGrid manageGrid;

    [SerializeField] Color RoadColor=Color.red;
    [SerializeField] Color detectColor=Color.green;
    [SerializeField] Color defaultColor=Color.white;
    [SerializeField] Color blockedColor=Color.gray;

     void Awake() // execute initialy
     {  
        manageGrid =FindObjectOfType<ManageGrid>();
         Label=GetComponent<TextMeshPro>();
         Label.enabled=false; // hide label
       
          DisplayCoordinate();
        
    }
    
   

    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
                DisplayCoordinate();
                updateFloorTileName();
        }

        ChangeColorCoordinates();
       // HideLable();
      // GoToMainMenu();
    }

    void ChangeColorCoordinates()
    {
        if(manageGrid==null)
        {
            return;
        }

        Node node=manageGrid.GetNode(coordinates);

        if(node==null)
        {
            return;
        }
        if(!node.move)
        {
            Label.color=blockedColor;
        }
        else if(node.road)
        {
            Label.color=RoadColor;
        }
        else if (node.identify)
        {
            Label.color= detectColor;
        }
        else
        {
            Label.color=defaultColor;
        }
    }

     void GoToMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        SceneManager.LoadScene("Menu");
        }
    }

    void HideLable() // not hide, just view
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Label.enabled=!Label.IsActive(); //view hide label
        }
    }
    void DisplayCoordinate()
    {
       // coordinates.x=Mathf.RoundToInt(transform.parent.position.x); // move according to the grid snap setting values in editor
        //coordinates.y=Mathf.RoundToInt(transform.parent.position.z); //  x,z 
        if(manageGrid==null)
        {
            return;
        }
        coordinates.x=Mathf.RoundToInt(transform.parent.position.x / manageGrid.editorGridSise);
        coordinates.y=Mathf.RoundToInt(transform.parent.position.z/manageGrid.editorGridSise); //  x,z
        //Label.text= "X,Z";
        Label.text= coordinates.x+","+coordinates.y;
    }

    void updateFloorTileName()
    {
        transform.parent.name=coordinates.ToString();
    }
}
