using UnityEngine;
using System.Collections;

public class CenterScript : MonoBehaviour
{
	// Use this for initialization
	void Start()
    {
        transform.Translate(FloorScript.CenterCoor.x-1, FloorScript.CenterCoor.y, FloorScript.CenterCoor.z-1);      //Set the Player on the center Cube(Magenta)
    }
}
