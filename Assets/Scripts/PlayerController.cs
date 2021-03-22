/*
* FILE		    : PlayerController.cs
* PROJECT       : RollaBall
* PROGRAMMER    : Balazs Karner
* FIRST VERSION : 03/17/2021
* LAST UPDATED  : 03/21/2021
* DESCRIPTION   :
*       This file contains the methods necessary for player movement of the sphere. 
*       Force is added to the sphere upon keyboard WASD or arrow key press.
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;



/*
* CLASS   : PlayerController
* PURPOSE :
* The purpose of this class is to model the movement of a player controlled sphere 
* with the WASD or arrow keys. On game start the position of the sphere (Rigidbody) 
* is retrieved and the position is updated on every move on the sphere taking the 
* player's speed into account.
* 
* CLASS FUNCTIONALITY:
* - Get Rigidbody initial location
* - Update sphere location with movement
*/
public class PlayerController : MonoBehaviour
{
    //Publics
    public float speed = 0;
    public float jumpValue = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Vector3 playerSpawnPoint;

    //Privates
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int pickUpCount;

    //Constants
    private const int PICKUP_VICTORY_COUNT = 25;
    private const float JUMP_THRESHOLD = 1.0f;
    private const float RESPAWN_THRESHOLD = 0.0f;
    private const float ZERO_AXIS_VALUE = 0.0f;


    /* 
    * METHOD      : Start()
    * DESCRIPTION :
    *       This method is called before the first game frame is updated.
    * PARAMETERS  :
    *        void : void
    * RETURNS     :
    *        void : void
    */
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Set initial count to 0 when game starts and fix countText label on the canvas UI
        pickUpCount = 0;
        SetCountText();

        //Set the victory text to an empty string
        winTextObject.SetActive(false);
    }



    /* 
    * METHOD      : OnMove()
    * DESCRIPTION :
    *       This method is called every time the player moves the sphere.
    *       It updates the private movementX and movementY variables.
    * PARAMETERS  :
    *  InputValue : movementValue (A Vector in 2d space containing the spheres coordinates)
    * RETURNS     :
    *        void : void
    */
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movementVector = context.ReadValue<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }



    /* 
    * METHOD      : FixedUpdate()
    * DESCRIPTION :
    *       This method is called once per frame to update the location of 
    *       the sphere with player speed and force for movement
    * PARAMETERS  :
    *        void : void
    * RETURNS     :
    *        void : void
    */
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, ZERO_AXIS_VALUE, movementY);
        rb.AddForce(movement * speed);

        if (rb.transform.position.y <= RESPAWN_THRESHOLD)
        {
            rb.transform.position = playerSpawnPoint;
        }
    }



    /* 
    * METHOD      : Jump()
    * DESCRIPTION :
    *       This method is called every time the player presses the space key on
    *       the keyboard to make the player sphere jump.
    * PARAMETERS  :
    *        void : void
    * RETURNS     :
    *        void : void
    */
    public void OnJump(InputAction.CallbackContext context)
    {
        //if (Input.GetKeyDown(KeyCode.Space) && rb.transform.position.y <= 1.0f)
        if (rb.transform.position.y <= JUMP_THRESHOLD)
        {
            Vector3 jump = new Vector3(ZERO_AXIS_VALUE, jumpValue, ZERO_AXIS_VALUE);

            rb.AddForce(jump);
        }
    }



    /* 
    * METHOD      : OnTriggerEnter()
    * DESCRIPTION :
    *       This method detects contact with the player sphere and other objects
    *       to deactivate the objects when they collide.
    * PARAMETERS  :
    *    Collider : other
    * RETURNS     :
    *        void : void
    */
    private void OnTriggerEnter(Collider other)
    {
        //If the player's sphere collides with a game object with tag "PickUp" then 
        //make the game object disappear, and increment the palyer's points
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpCount++;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Trap"))
        {
            rb.transform.position = playerSpawnPoint;
        }
    }



    /* 
    * METHOD      : SetCountText()
    * DESCRIPTION :
    *       This method updates the text for the game that tracks the player's 
    *       current points or number of picked up prefab "PickUps".
    * PARAMETERS  :
    *        void : void
    * RETURNS     :
    *        void : void
    */
    void SetCountText()
    {
        countText.text = "Count: " + pickUpCount.ToString();

        //If the player has picked up 12 "PickUps" then enter here
        if (pickUpCount >= PICKUP_VICTORY_COUNT)
        {
            //Display the victory text
            winTextObject.SetActive(true);
        }
    }
}