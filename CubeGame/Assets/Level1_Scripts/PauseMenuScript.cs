using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pausemenuUI;
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                Cursor.lockState = CursorLockMode.Locked; //Lock the cursor and the cursor isn't visible on the screen when left click pressed
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Pause();
            }
        }
	}

    public void Resume()
    {
        pausemenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);       //Previous Scene(Menu)
    }
}
