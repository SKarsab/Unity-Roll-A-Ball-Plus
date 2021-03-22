/*
* FILE		    : AttachPlayerToMovingPlatform.cs
* PROJECT       : RollaBall
* PROGRAMMER    : Balazs Karner
* FIRST VERSION : 03/17/2021
* LAST UPDATED  : 03/21/2021
* DESCRIPTION   :
*       This file contains the methods necessary to attach the player sphere to moving
*       platforms
* REFERENCE     :
*       The movement/attachment of the player to platforms was adapted form the Youtube solution linked below and therefore is not my own code
*       Jayanam. (April 18, 2018). Unity Moving Platform Tutorial. From https://www.youtube.com/watch?v=rO19dA2jksk
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
* CLASS   : AttachPlayerToMovingPlatform
* PURPOSE :
* The purpose of this class is to attach the player's sphere to the platform
* if the platform is moving either vertically or horizontally.
* 
* CLASS FUNCTIONALITY:
* - Move player if on a moving platform
*/
public class AttachPlayerToMovingPlatform : MonoBehaviour
{
    public GameObject Player;



    /* 
    * METHOD      : OnTriggerEnter()
    * DESCRIPTION :
    *       This method makes the player sphere a child of the moving platform 
    *       if the player sphere touches the trigger box collider.
    * PARAMETERS  :
    *    Collider : other (The game object that has collided with the platform)
    * RETURNS     :
    *        void : void
    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = transform;
        }
    }



    /* 
    * METHOD      : OnTriggerEnter()
    * DESCRIPTION :
    *       This method removes the player sphere as a child of the moving platform 
    *       if the player sphere leaves the trigger box collider.
    * PARAMETERS  :
    *    Collider : other (The game object that is no longer colliding with the platform)
    * RETURNS     :
    *        void : void
    */
    private void OnTrigerExit(Collider other)
    {
        //Remove parent platform from player sphere is the sphere leaves the platform
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
        }
    }
}