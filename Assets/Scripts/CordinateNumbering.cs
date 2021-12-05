using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // access to text mesh pro
using UnityEngine.SceneManagement;

[ExecuteAlways] // execute in edit mode and play mode
[RequireComponent(typeof(TextMeshPro))]
public class CordinateNumbering : MonoBehaviour
{
    TextMeshPro Label;
    Vector2Int coordinates= new Vector2Int();
    WayPoints wayPoints;

    [SerializeField] Color defaultColor=Color.white;
    [SerializeField] Color blockedColor=Color.gray;

     void Awake() // execute initialy
     {  

         Label=GetComponent<TextMeshPro>();
         Label.enabled=false; // hide label
         wayPoints=GetComponentInParent<WayPoints>();
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
     //  GoToMainMenu();
    }

    void ChangeColorCoordinates()
    {
        if(wayPoints.CurentLocation)
        {
            Label.color=defaultColor;

        }
        else
        {
            Label.color=blockedColor;
        }
    }

    void GoToMainMenu()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
        SceneManager.LoadScene("Menu");
        }
    }

    void HideLable()//not hide, just view
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

        coordinates.x=Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y=Mathf.RoundToInt(transform.parent.position.z/UnityEditor.EditorSnapSettings.move.z); //  x,z
        //Label.text= "X,Z";
        Label.text= coordinates.x+","+coordinates.y;
    }

    void updateFloorTileName()
    {
        transform.parent.name=coordinates.ToString();
    }
}
