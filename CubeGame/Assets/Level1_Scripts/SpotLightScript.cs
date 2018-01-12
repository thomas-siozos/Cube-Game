using UnityEngine;
using System.Collections;

public class SpotLightScript : MonoBehaviour
{
    public Transform SpotLight1Rotation;
    public Transform SpotLight2Rotation;
    public Transform SpotLight3Rotation;
    public Transform SpotLight4Rotation;
    public GameObject TheSpotLight1;
    public GameObject TheSpotLight2;
    public GameObject TheSpotLight3;
    public GameObject TheSpotLight4;
    // Use this for initialization
    void Start ()
    {
        Vector3 Coor;
        //SpotLight1
        Coor.x = 1;
        Coor.y = 10;
        Coor.z = 1;
        Instantiate(TheSpotLight1, Coor, SpotLight1Rotation.rotation);      //Create the Spolight1
        //SpotLight2
        Coor.x = 1;
        Coor.y = 10;
        Coor.z = InputControllerScript1.ZsizeNumber-1;
        Instantiate(TheSpotLight2, Coor, SpotLight2Rotation.rotation);      //Create the Spotlight2
        //SpotLight3
        Coor.x = InputControllerScript.XsizeNumber-1;
        Coor.y = 10;
        Coor.z = InputControllerScript1.ZsizeNumber-1;

        Instantiate(TheSpotLight3, Coor, SpotLight3Rotation.rotation);      //Create the Spotlight3
        //SpotLight4
        Coor.x = 1;
        Coor.y = 10;
        Coor.z = InputControllerScript1.ZsizeNumber - 1;
        Instantiate(TheSpotLight4, Coor, SpotLight4Rotation.rotation);      //Create the Spotlight4
    }
}
