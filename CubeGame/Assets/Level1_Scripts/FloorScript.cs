using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorScript : MonoBehaviour
{
    public Transform SpawnPosition;     //The position of a created cube
    public GameObject CubeFloor;        //Created Cube from before
    private Vector3 Coor;
    public static Vector3 CenterCoor;       //Coordinates for the Center Cube
    private GameObject CubeFloorHere;           //Cube
    public static List<GameObject> FloorCubesList = new List<GameObject>();     //List with all the Floor Cubes

	// Use this for initialization
	void Start ()
    {
        int count = 0;      //For the Center Cube
        int number_color;
		for(int i=0; i < InputControllerScript.XsizeNumber; i++)        //Create the floor
        {
            for(int j=0; j < InputControllerScript1.ZsizeNumber; j++)
            {
                count = 0;
                number_color = Random.Range(1, 5);
                if (i == Mathf.Round(InputControllerScript.XsizeNumber / 2) && j == Mathf.Round(InputControllerScript1.ZsizeNumber / 2) && count == 0)      //Center Cube(Magenta)
                {
                    Coor.x = i;
                    Coor.y = 0;
                    Coor.z = j;
                    CenterCoor.x = i;
                    CenterCoor.y = 1;
                    CenterCoor.z = j;
                    CubeFloorHere = Instantiate(CubeFloor, Coor, SpawnPosition.rotation);
                    CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.magenta;
                    FloorCubesList.Add(CubeFloorHere);
                    count = 1;
                }
                if (number_color == 1 && count == 0)        //Cube with Red Color
                {
                    Coor.x = i;
                    Coor.y = 0;
                    Coor.z = j;
                    CubeFloorHere = Instantiate(CubeFloor, Coor, SpawnPosition.rotation);
                    CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.red;
                    FloorCubesList.Add(CubeFloorHere);
                }
                else if(number_color == 2 && count == 0)        //Cube with Green Color
                {
                    Coor.x = i;
                    Coor.y = 0;
                    Coor.z = j;
                    CubeFloorHere = Instantiate(CubeFloor, Coor, SpawnPosition.rotation);
                    CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.green;
                    FloorCubesList.Add(CubeFloorHere);
                }
                else if(number_color == 3 && count == 0)        //Cube with Blue Color
                {
                    Coor.x = i;
                    Coor.y = 0;
                    Coor.z = j;
                    CubeFloorHere = Instantiate(CubeFloor, Coor, SpawnPosition.rotation);
                    CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.blue;
                    FloorCubesList.Add(CubeFloorHere);
                }else if(number_color == 4 && count == 0)
                {
                    Coor.x = i;
                    Coor.y = 0;
                    Coor.z = j;
                    CubeFloorHere = Instantiate(CubeFloor, Coor, SpawnPosition.rotation);
                    CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    FloorCubesList.Add(CubeFloorHere);
                }
            }
        }
	}
}
