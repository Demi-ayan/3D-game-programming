using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    //A variable to store player's position
    public Transform player;
    
    //Update position of minimap after user moves
    void LateUpdate()
    {
        //A vector to store position of the player
        Vector3 newPosition = player.position;
        //The original y position stays the same
        newPosition.y = transform.position.y;
        //the position is set to that of the player on the x and z axis but maintains its original y-axis value
        transform.position = newPosition;
        
    }
}
