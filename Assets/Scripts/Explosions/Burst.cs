using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this is the script in which whenever the destroyed breaker will be replaced with their
/// corresponding burst pattern
/// 
/// short range will hava e a pattern of  
///       +
///     +++++
///       +
///       
/// while long range will have a patternf of
///        +
///        +
///    ++++++++++
///        +
///        +
/// which is at least twice as much range as the short range one.
/// 
/// specifics will change the way the breakers will behave such as unpathable objects ie. walls and the obstacles.
/// The game WILL ALLOW THE OBSTACLES TO BE DESTROYED when the burst collides with the obstacle
/// the breakers WILL HAVE A FRIENDLY FIRE function, meaning that the breaker set by the player will also hurt the player the player is in the way.
/// </summary>
public class Burst : MonoBehaviour
{
    //this script will be called the moment that the breaker is destoryed...so I will need the breaker type
    //SR type will have their burst from the center and be 1 unit apart from each other.
    //with a 2D platform, the only transforms affected are the x and Y transform.

    //the LR will be 2x's the unit from the center, and movement from one unit to the next consecutive one is 1.


    //will need to take in the type of breaker that is passing through


    //will need the transform position of the breaker passing through.

    //will need a check coliision of the burst on walls and on obstacles.

    //NOTE THERE IS AN OFFSET BETWEEN THE THE TRANSFORMS OF THE OBJECTS PLACED IN THE GRID AND THE OBJECTS PLACED ON THE WORLD
    //UNLESS THE TRANSFORM ON THE CONTAINER IS RESETTED.

    void burstType(string prefabName, Vector2 breakerPosition)
    {
        if (prefabName == "LR_Breaker(Clone)")
        {
            //the position of the burst will happen at the center
            //GameObject burst = Instantiate();

        }
    }
}
