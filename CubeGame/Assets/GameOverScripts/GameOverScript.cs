using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    void Start ()
    {
        Cursor.lockState = CursorLockMode.None;     //Free the cursor
    }
	public void BackToMenu ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);       //Go to the menu
    }

}
