using UnityEngine;
using System.Collections;

public class TheLimitScript : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject TheLimit;
    private GameObject Limit1;
    private GameObject Limit2;
    private GameObject Limit3;
    private GameObject Limit4;
    // Use this for initialization
    void Start ()
    {
        Vector3 ScaleData;
        Vector3 Coor;
        //Limit 1
        Coor.x = -1;
        Coor.y = 1;
        Coor.z = -1;
        ScaleData.x = Coor.x;
        Limit1 = Instantiate(TheLimit, Coor, SpawnPosition.rotation);   //Create limit1
        ScaleData.x = 2 * InputControllerScript.XsizeNumber+1;
        ScaleData.y = 100;
        ScaleData.z = 1;
        Limit1.transform.localScale = ScaleData;        //Scale limit1
        //Limit 2
        Coor.x = -1;
        Coor.y = 1;
        Coor.z = -1;
        ScaleData.x = Coor.x;
        Limit2 = Instantiate(TheLimit, Coor, SpawnPosition.rotation);       //Create limit2
        ScaleData.x = 1;
        ScaleData.y = 100;
        ScaleData.z = 2 * InputControllerScript1.ZsizeNumber+1;     //Scale limit2
        Limit2.transform.localScale = ScaleData;
        //Limit 3
        Coor.x = -1;
        Coor.y = 1;
        Coor.z = InputControllerScript1.ZsizeNumber;
        ScaleData.x = Coor.x;
        Limit1 = Instantiate(TheLimit, Coor, SpawnPosition.rotation);       //Create limit3
        ScaleData.x = 2 * InputControllerScript.XsizeNumber+1;
        ScaleData.y = 100;
        ScaleData.z = 1;
        Limit1.transform.localScale = ScaleData;        //Scale limit3
        //Limit 4
        Coor.x = InputControllerScript.XsizeNumber;
        Coor.y = 1;
        Coor.z = -1;
        ScaleData.x = Coor.x;
        Limit1 = Instantiate(TheLimit, Coor, SpawnPosition.rotation);       //Create limit4
        ScaleData.x = 1;
        ScaleData.y = 100;
        ScaleData.z = 2 * InputControllerScript1.ZsizeNumber+1;     //Scale limit4
        Limit1.transform.localScale = ScaleData;
        Debug.Log("Size of X = " +InputControllerScript.XsizeNumber);       //Print size of x player gave
        Debug.Log("Size of Z = " +InputControllerScript1.ZsizeNumber);      //Print size of z player gave 
    }

}
