using UnityEngine;
using System.Collections;

public class CharacterMove: MonoBehaviour
{
    public float speed = 6.0f;
    public float rotateSpeed = 6.0f;
    public float jumpSpeed = .0f;
    public float gravity = 10.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; //Lock the cursor and the cursor isn't visible on the screen
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //W and S or Up-Down Keys for the keyboard and A and D or Left-Right Keys for the keyboard
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetKeyDown("space"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        /**float translation = Input.GetAxis("Vertical") * speed;  //W and S or Up-Down Keys for the keyboard
        float straffe = Input.GetAxis("Horizontal") * speed;    //A and D or Left-Right Keys for the keyboard
        translation *= Time.deltaTime; //Make the movement smooth and in time with update
        **/

        /**if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; //If the user clicks Escape button the cursor is visible again
        }

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked; //Lock the cursor and the cursor isn't visible on the screen when left click pressed
        }**/
    }
}
