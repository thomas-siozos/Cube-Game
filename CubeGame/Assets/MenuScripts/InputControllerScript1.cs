using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputControllerScript1 : MonoBehaviour
{
    public InputField input;        ////The Object from the second InputField
    public static int ZsizeNumber;

    public void GetInput(string Zsize)
    {
        Zsize = input.text;     //Text from the secondInput Field
        int.TryParse(Zsize, out ZsizeNumber);       //String to Int
        //Debug.Log(ZsizeNumber);
    }
}
