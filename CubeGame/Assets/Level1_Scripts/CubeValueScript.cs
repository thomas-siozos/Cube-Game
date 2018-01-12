using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CubeValueScript : MonoBehaviour
{
    public Collider col;        //Collider of an Object
    public Renderer rend;       //Renderer of an Object
    public Text CubeValueOnLook;        //What Cube Camera looks
    public Text RemainingCubes;     //Text for remaining Cubes
    public static int countCubes = 0;       //Remaining Cubes
    public static int CurrentHealth = 50;       //CurrentHealth = Points of the Player
    public Text CurrentHealthText;      //Text for Points
    public Text LifesText;      //text for Lifes
    public int Lifes;       //Lifes that the player has
    public GameObject Player;       //The Player
    private int countTopLevel = 0;      //Once on top level
    public static List<float> YValues = new List<float>();      //The YValues when the player is grounded
    public CharacterController controller;      //The character controller of player
    public Rigidbody rb;        //Rigidbody of CreatedCubes
    public bool CapsLockState = false;      //If CapsLock is on/off
    private int CapsState = 0;      //odd = CapsLock On, even == CapsLock Off

    void Start()
    {
        RemainingCubes.text = "0";      //Start the game with 0 Remaining Cubes
        Lifes = 3;      //Start the game with 3 Lifes
    }

    void GetMouseValues(float range)
    {
        Vector3 position = gameObject.transform.position;       //Where the player is
        Vector3 target1 = position + Camera.main.transform.forward * range;     //Where camera looks in range 1
        Vector3 target;     //Vector with round values of target1
        target.x = Mathf.Round(target1.x);       //Round the x where camera looks  
        target.y = Mathf.Round(target1.y);       //Round the y where camera looks
        target.z = Mathf.Round(target1.z);       //Round the z where camera looks
        //Debug.Log(target.x);

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            if (CapsState == 0)
            {
                CapsLockState = true;       //CapsLock On
                CapsState = 1;      //odd
            }
            else
            {
                CapsLockState = false;      //CapsLock Off
                CapsState = 0;      //Even
            }
        }

        for (int i = 0; i < FloorScript.FloorCubesList.Count; i++)
        {
            if (FloorScript.FloorCubesList[i].transform.position.x == target.x && FloorScript.FloorCubesList[i].transform.position.z == target.z && target.y <= 1)      //The values of the floor cubes
            {
                if (FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color == Color.red)
                {
                    CubeValueOnLook.text = "2";     //Capacity of Red Cube
                    if (Input.GetKeyDown(KeyCode.E) && CapsLockState == false)      //Lower e
                    {
                        FindObjectOfType<AudioManagerScript>().Play("TakeCube");        //Play the Sound with name TakeCube
                        countCubes++;
                        CurrentHealth -= 5;
                        FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color = Color.yellow;       //Red to Yellow
                    }
                }
                else if (FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    CubeValueOnLook.text = "3";     //Capacity of Green Cube
                    if (Input.GetKeyDown(KeyCode.E) && CapsLockState == false)      //Lower e
                    {
                        FindObjectOfType<AudioManagerScript>().Play("TakeCube");        //Play the Sound with name TakeCube
                        countCubes++;
                        CurrentHealth -= 5;
                        FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color = Color.red;      //Green to Red
                    }
                } else if (FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color == Color.blue)
                {
                    CubeValueOnLook.text = "0";     //Capacity of Blue Cube
                } else if (FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color == Color.yellow)
                {
                    CubeValueOnLook.text = "1";     //Capacity of Yellow Cube
                    if (Input.GetKeyDown(KeyCode.E) && CapsLockState == false)      //Lower e
                    {
                        FindObjectOfType<AudioManagerScript>().Play("TakeCube");        //Play the Sound with name TakeCube
                        countCubes++;
                        CurrentHealth -= 5;
                        FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color = Color.blue;     //Yellow to Blue
                    }
                }
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    if (FloorScript.FloorCubesList[i].GetComponent<MeshRenderer>().material.color != Color.magenta && target1.y < 1)     //Cant destory the cube with magenta color
                    {
                        FindObjectOfType<AudioManagerScript>().Play("QSound");      //Play the Sound with name QSound
                        col = FloorScript.FloorCubesList[i].GetComponent<Collider>();
                        rend = FloorScript.FloorCubesList[i].GetComponent<Renderer>();
                        col.enabled = false;        //Collider off
                        rend.enabled = false;       //Renderer off
                    }
                }
            }
        }

        for (int i = 0; i < CreateCubes.CreatedCubesList.Count; i++)
        {
            if (CreateCubes.CreatedCubesList[i].transform.position.x == target.x && CreateCubes.CreatedCubesList[i].transform.position.z == target.z && CreateCubes.CreatedCubesList[i].transform.position.y == target.y)       //The values of the created cubes by the player
            {
                if (CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color == Color.red)
                {
                    CubeValueOnLook.text = "2";     //Capacity of Red cube
                    if (Input.GetKeyDown(KeyCode.E) && CapsLockState == false)      //Lower e
                    {
                        FindObjectOfType<AudioManagerScript>().Play("TakeCube");        //Play the Sound with name TakeCube
                        countCubes++;
                        CurrentHealth -= 5;
                        CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color = Color.yellow;     //Red to yellow
                    }
                }
                else if (CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    CubeValueOnLook.text = "3";     //Capacity of Green Cube
                    if (Input.GetKeyDown(KeyCode.E) && CapsLockState == false)      //Lower e
                    {
                        FindObjectOfType<AudioManagerScript>().Play("TakeCube");        //Play the Sound with name TakeCube
                        countCubes++;
                        CurrentHealth -= 5;
                        CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color = Color.red;        //Green to Red
                    }
                } else if (CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color == Color.blue)
                {
                    CubeValueOnLook.text = "0";     //Capacity of Blue Cube
                } else if (CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color == Color.yellow)
                {
                    CubeValueOnLook.text = "1";     //Capacity of Yellow Cube
                    if (Input.GetKeyDown(KeyCode.E) && CapsLockState == false)      //Lower e
                    {
                        FindObjectOfType<AudioManagerScript>().Play("TakeCube");        //Play the Sound with name TakeCube
                        countCubes++;
                        CurrentHealth -= 5;
                        CreateCubes.CreatedCubesList[i].GetComponent<MeshRenderer>().material.color = Color.blue;       //Yellow to Blue
                    }
                }

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    FindObjectOfType<AudioManagerScript>().Play("QSound");      //Play the Sound with name QSound
                    CreateCubes.CreatedCubesList[i].transform.Translate(InputControllerScript.XsizeNumber+2, 0, InputControllerScript1.ZsizeNumber+2);
                    col = CreateCubes.CreatedCubesList[i].GetComponent<Collider>();
                    rend = CreateCubes.CreatedCubesList[i].GetComponent<Renderer>();
                    col.enabled = false;        //Collider off
                    rend.enabled = false;       //Renderer off
                }

                if (Input.GetKeyDown(KeyCode.E) && CapsLockState == true)        //Destroy all cubes where player looks in all y-levels and Upper E
                {
                    FindObjectOfType<AudioManagerScript>().Play("ZSound");      //Play the Sound with name ZSound
                    DestroyCubesOnTarget(target);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))        //All cubes with no other cubes under them fall down
        {
            CurrentHealth -= 10;        // -10 Points
            FindObjectOfType<AudioManagerScript>().Play("RSound");      //Play the Sound with name RSound
            CubesFallDown();
        }

        if (controller.isGrounded)       //If player is grounded
        {
            YValues.Add(Mathf.Round(Player.transform.position.y));      //All the y values when the player is grounded
            if(YValues.Count > 2)
            {
                if (YValues[YValues.Count-1] == YValues[YValues.Count-2] + 1)       //If player jumps on a cube where y is y = y(old) + 1 then takes +5 points
                {
                    CurrentHealth += 5;
                }else if (YValues[YValues.Count-1] < YValues[YValues.Count-2])      //For each y level player fell lost 5 points
                {
                    if(Mathf.RoundToInt(YValues[YValues.Count - 2] - YValues[YValues.Count - 1]) > 1)
                    {
                        CurrentHealth -= Mathf.RoundToInt(YValues[YValues.Count - 2] - YValues[YValues.Count - 1]) * 5;     //y(old) - y(current) * 5, if y(current) < y(old)
                    }
                    if(CurrentHealth <= 0)
                    {
                        DiedOnce();
                    }
                }
            }
        }

        if(Player.transform.position.y < -8)        //When player falls 
        {
            PlayerFallen();
        }
       
        if (Player.transform.position.y >= InputControllerScript.XsizeNumber && countTopLevel == 0 && controller.isGrounded)        //if player is on top level(y = Xsize of map), player didnt reach again and player is Grounded(Cube)
        {
            FindObjectOfType<AudioManagerScript>().Play("TopLevelSound");
            countTopLevel = 1;      //player reached top level only once
            Lifes++;
            LifesText.text = Lifes.ToString("0");
            CurrentHealth += 100;       //When the player reaches the top level he takes 100 points
            CurrentHealthText.text = CurrentHealth.ToString("0");
        }

        RemainingCubes.text = countCubes.ToString("0");
        CurrentHealthText.text = CurrentHealth.ToString("0");

        if (CurrentHealth <= 0)     //Points <= 0 
        {
            DiedOnce();
        }

        if (Lifes <= 0)     //No remaining lifes
        {
            Die();
        }

    }

    void DestroyCubesOnTarget(Vector3 target)
    {
        for(int i=0; i < CreateCubes.CreatedCubesList.Count; i++)
        {
            if(CreateCubes.CreatedCubesList[i].transform.position.x == target.x && CreateCubes.CreatedCubesList[i].transform.position.z == target.z)        //Destroy all the cubes for each level in the point(X,Y)
            {
                col = CreateCubes.CreatedCubesList[i].GetComponent<Collider>();
                rend = CreateCubes.CreatedCubesList[i].GetComponent<Renderer>();
                col.enabled = false;        //Collider off
                rend.enabled = false;       //Renderer off
            }
        }
        Lifes++;        // +1 Life
        LifesText.text = Lifes.ToString("0");
        CurrentHealth -= 20;        // -20 Points
    }

    void CubesFallDown()
    {
        for (int i = 0; i < CreateCubes.CreatedCubesList.Count; i++)
        {
            if (CreateCubes.CreatedCubesList[i].GetComponent<Rigidbody>() == null)      //If cube hasnt Rigidbody
            {
                rb = CreateCubes.CreatedCubesList[i].AddComponent<Rigidbody>();     //Add rigidbody
                rb.mass = 20;       //With mass 50
                rb.isKinematic = false;     //Kinematic off
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;      //Freeze on Rotation X,Y,Z values and on Position X,Z values
            }
        }
    }

    void PlayerFallen()     //Respawn to the Point(0,1,0) or if this point has cubes then respawn to the next possible level(y) 
    {
        Vector3 respawn;        //Respawn Point
        float maxY = 1;
        for(int i = 0; i < CreateCubes.CreatedCubesList.Count; i++)
        {
            if(CreateCubes.CreatedCubesList[i].transform.position.x == 0 && CreateCubes.CreatedCubesList[i].transform.position.z == 0)
            {
                if(CreateCubes.CreatedCubesList[i].transform.position.y > maxY)     //Find max level(y)
                {
                    maxY = CreateCubes.CreatedCubesList[i].transform.position.y;
                }
            }
        }
        respawn.x = FloorScript.CenterCoor.x;
        respawn.y = maxY+1;
        respawn.z = FloorScript.CenterCoor.z;
        controller.transform.position = respawn;        //Respawn player on magenta color cube but on the highest level(y)
        DiedOnceByFall();
    }

	// Update is called once per frame
	void Update ()
    {
        GetMouseValues(1);      //Range = 1
	}

    void DiedOnce()
    {
        CurrentHealth = 50;     //Reset the points on 50 when the player lose 1 life
        CurrentHealthText.text = CurrentHealth.ToString("0");
        FindObjectOfType<AudioManagerScript>().Play("LifeLost");
        Lifes -= 1;     // -1 Life
        if(Lifes == 0)      //If player hasnt lifes
        {
            LifesText.text = Lifes.ToString("0");
            Die();      //If the player hasnt lifes 
        }
        LifesText.text = Lifes.ToString("0");
    }

    void DiedOnceByFall()       //If player die by fall
    {
        FindObjectOfType<AudioManagerScript>().Play("LifeLost");
        Lifes--;        // -1 Life
        LifesText.text = Lifes.ToString("0");
    }

    void Die()      //If the game ends
    {
        Debug.Log("You are dead mate!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);       //Go to the next scene(GameOver)
    }
}