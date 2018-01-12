using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateCubes : MonoBehaviour
{
    public Transform SpawnPosition; //Position of the cube that created before
    public GameObject CreatedCube;  //Cubes to create
    public GameObject Player;       //Player Object
    private GameObject CubeFloorHere;   //The created cube
    public static List<GameObject> CreatedCubesList = new List<GameObject>();     //List with all Cubes that Player creates
    private int count = 0;      //Count for the first cube that the player will create
    private int countfor = 0;       //If in front of the player has cube

    void GetMouseHoverObject(float range)
    {
        int number_color;
        number_color = Random.Range(1, 5);      //1-4
        countfor = 0;
        //Debug.Log(number_color);
        Vector3 position = gameObject.transform.position;
        Vector3 target = position + Camera.main.transform.forward * range;
        //Debug.Log(position + Camera.main.transform.forward);
        target.x = Mathf.Round(target.x);
        target.y = Mathf.Round(target.y);
        target.z = Mathf.Round(target.z);
        if(Mathf.Round(Player.transform.position.y) == target.y)        //If where camera looks is on the same level with player and not the same position as player
        {
            if (count == 0)     //The first
            {
                FindObjectOfType<AudioManagerScript>().Play("CreateCube");
                CubeFloorHere = Instantiate(CreatedCube, target, SpawnPosition.rotation);
				CubeValueScript.countCubes--;       //-1 on reamaining cubes
				CubeValueScript.CurrentHealth += 5;     //+5 on points
            }
            else
            {
                for (int i = 0; i < CreatedCubesList.Count; i++)
                {
                    if (CreatedCubesList[i].transform.position.x == target.x && CreatedCubesList[i].transform.position.z == target.z)       //If a cube is in front of the player the next cube will created to the next level
                    {
                        target.y += 1;      //If in front of the player has cube, the next cube it will be on the next level(y)
                        countfor = 1;       //Check 
                    }
                }
                if(countfor == 1)
                {
                    if (target.y < InputControllerScript.XsizeNumber)        //If the next level is less than N(Size of the map)
                    {
                        FindObjectOfType<AudioManagerScript>().Play("CreateCube");
                        CubeFloorHere = Instantiate(CreatedCube, target, SpawnPosition.rotation);
						CubeValueScript.countCubes--;       //-1 on reamaining cubes
						CubeValueScript.CurrentHealth += 5;     //+5 on points
                    }
                }else if(countfor == 0)
                {
                    if (target.y < InputControllerScript.XsizeNumber)        //If the next level is less than N(Size of the map)
                    {
                        FindObjectOfType<AudioManagerScript>().Play("CreateCube");
                        CubeFloorHere = Instantiate(CreatedCube, target, SpawnPosition.rotation);
						CubeValueScript.countCubes--;       //-1 on reamaining cubes
						CubeValueScript.CurrentHealth += 5;     //+5 on points
                    }
                }
            }
            if(number_color == 1)       //Red Color Cube
            {
                CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.red;
            }
            else if(number_color == 2)      //Green Color Cube
            {
                CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else if(number_color == 3)      //Blue Color Cube
            {
                CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.blue;
            }else if(number_color == 4)     //Yellow Color Cube
            {
                CubeFloorHere.GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
            CreatedCubesList.Add(CubeFloorHere);
            count = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))     //If the player clicks the left click 
        {
            if (CubeValueScript.countCubes > 0)     //If player has reamining cubes to create one
            {
                GetMouseHoverObject(1);     //The range of the camera
            }
        }
    }
}
