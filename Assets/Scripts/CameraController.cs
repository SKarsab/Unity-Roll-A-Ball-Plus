/*
* FILE		    : CameraController.cs
* PROJECT       : RollaBall
* PROGRAMMER    : Balazs Karner
* FIRST VERSION : 03/17/2021
* LAST UPDATED  : 03/21/2021
* DESCRIPTION   :
*       This file contains the methods necessary for controlling the camera position/movement 
*       relative to the player controlled sphere.
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
* CLASS   : CameraController
* PURPOSE :
* The purpose of this class is to model the movement of the camera attached to the 
* player controlled sphere. On game start the offset of the camera is retrieved and 
* the position is updated on every player move of the sphere.
* 
* CLASS FUNCTIONALITY:
* - Get camera initial offset
* - Update camera location with movement
*/
public class CameraController : MonoBehaviour
{
    //Publics
    public GameObject player;

    //Privates
    private Vector3 offset;



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
        offset = transform.position - player.transform.position;
    }



    /* 
    * METHOD      : LateUpdate()
    * DESCRIPTION :
    *       This method is called once per frame to update the location of 
    *       the camera relative to the sphere + an offset
    * PARAMETERS  :
    *        void : void
    * RETURNS     :
    *        void : void
    */
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}