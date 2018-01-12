using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour
{

    Vector2 CamMouseLook;   //Keep track how much movement camera made
    Vector2 smoothV;    //Smooth the camera look
    public float sensitivity = 3.0f;
    public float smoothing = 2.0f;

    GameObject character;

	// Use this for initialization
	void Start ()
    {
        character = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!PauseMenuScript.GameIsPaused)
        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); //The mouse delta
            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
            smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
            CamMouseLook += smoothV;
            CamMouseLook.y = Mathf.Clamp(CamMouseLook.y, -90f, 90f);
            transform.localRotation = Quaternion.AngleAxis(-CamMouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(CamMouseLook.x, character.transform.up);
        }
    }
}
