/*
* FILE		    : Rotator.cs
* PROJECT       : RollaBall
* PROGRAMMER    : Balazs Karner
* FIRST VERSION : 03/17/2021
* LAST UPDATED  : 03/21/2021
* DESCRIPTION   :
*       This file contains the methods necessary to continuously rotate game objects
*       while the game is active
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
* CLASS   : Rotator
* PURPOSE :
* The purpose of this class is to model the rotation of various game objects while
* the game is still active in order to draw attention to the objects in the game.
* 
* CLASS FUNCTIONALITY:
* - Rotates the game object's transform
*/
public class Rotator : MonoBehaviour
{
    public int rotationX = 0;
    public int rotationY = 0;
    public int rotationZ = 0;



    /* 
    * METHOD      : Update()
    * DESCRIPTION :
    *       This method is called once per frame before the frame to rotate the 
    *       game object's transform. This rotates the game object by rotationX units in 
    *       the x axis, rotationY units in the y axis, and rotationZ in the z axis multiplied by
    *       deltaTime in order to make it once per second instead of once per frame
    * PARAMETERS  :
    *        void : void
    * RETURNS     :
    *        void : void
    */
    void Update()
    {
        transform.Rotate(new Vector3(rotationX, rotationY, rotationZ) * Time.deltaTime);
    }
}