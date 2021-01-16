using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// the script that will handle what type of breakers to use for the enemy BASED on the distance between the enemy player and OTHER PLAYERS
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float radiusOuterCircle; //made public to experiment 
    public float radiusInnerCircle;
    public Collider2D[] enemeyIsCollidingWith;
    public Collider2D[] enemyIsCollidingWith2;
    public LayerMask otherPlayer;//will need to check every frame what enemies are close to the object based on the distance

    //public GameObject burst_Spawn; //wil have access to the burst formation of the breaker prefab when instantiated.
    //StarBurst boom_script;
    

    public bool checkOuterCircle()
    {
        //this is the method that will check is the other player are inside the radius of the outer or inner circle

        //method will go like this:
        //if other player is inside outer circle but NOT the inner, enemy will set a long range breaker
        //if the other player is inside the outer circle AND inside of the inner, the enemy will set a short range breaker.

        enemeyIsCollidingWith = Physics2D.OverlapCircleAll(transform.position, radiusOuterCircle, otherPlayer);
        if (enemeyIsCollidingWith.Length > 0)
        {
            return true;
        }

        else {
            return false;
        }
        

    }

    public bool checkInnerCircle()
    {
        enemyIsCollidingWith2 = Physics2D.OverlapCircleAll(transform.position, radiusInnerCircle, otherPlayer);
        if (enemyIsCollidingWith2.Length > 0)
        {
            return true;
        }
        else
        { 
        return false;
        }
    }

    //should the enemy keep a distance between itself and the other player?????

    void OnCollisionExit2D(Collision2D notTouching) //this is the method that will need to reset the length of the inner and outer circles whenever the enemy is not close ot the other players.
    {
        //this wil be called every frame to check the status of the outer and inner circle
        //array length cannot be reset but, elements can be cleared out of the array

        Debug.Log("no longer touching the player");
        for (int i = 0; i < enemeyIsCollidingWith.Length; i++)
        {
            enemeyIsCollidingWith[i] = null;
        }
        for (int i2 = 0; i2 < enemyIsCollidingWith2.Length; i2++)
        {
            enemyIsCollidingWith2[i2] = null;
        }

    }
}
