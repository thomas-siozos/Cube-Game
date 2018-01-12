using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputControllerScript : MonoBehaviour
{
    public InputField input;        //The Object from the first InputField
    public static int XsizeNumber;

    public void GetInput(string Xsize)
    {
        Xsize = input.text;     //Text from the first Input Field
        int.TryParse(Xsize, out XsizeNumber);       //String to Int
        //Debug.Log(XsizeNumber);
    }
}
