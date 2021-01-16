using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomContact : MonoBehaviour
{
    //problem is when the explosion is instantiated, it won't automatically call for on trigger or on collision to check overlapping objects or colliders
    //bool isColliding;
    //Collider2D objCollider;
    public Collider2D[] colliderWalls;
    public Collider2D[] colliderObst;
    //public Collider2D[] colliderPlayer; //since this will also affect enemies as well when they are in the crossfire
    public float radius;


    public LayerMask wallFilter;
    public LayerMask obstFilter;
    //public LayerMask players;

    SpriteRenderer burstRender;

    bool render;
    void Awake()
    {
        burstRender = gameObject.GetComponent<SpriteRenderer>();
        //Debug.Log(burstRender); //used to see if we got the component
    }

    void Update()
    {
        render = checkWall();
        if (render == true)
        {
            burstRender.enabled = true;
        }
        destroyObst();
        //Debug.Log("obst contact script returned: " + destroyObst());
        if (destroyObst() == true)
        {
            for (int i = 0; i < colliderObst.Length; i++)
            {
                Destroy(colliderObst[i].gameObject);
            }
        }


        //i will need to create an empty object that will have the same dimensions and properties as the bomb prefab.
        //this will serve as a checking mechanic, controlling how the bursts will form in reaction to the filters presented.
    }

    //by default when the breaker explodes, the sprite render will be disabled, so that as the script checks for any filter for wall, that prefab will remain disabled. 
    bool checkWall()
    {
        colliderWalls = Physics2D.OverlapCircleAll(transform.position, radius, wallFilter); //IT FRICKEN WORKSSS!!!!!!!!!!!

        if (colliderWalls.Length > 0)
        {
            return false;
        }
        else {
            return true;
        }
    }

    //checks for any collisions between the burst and the obstacles that can be destroyed.
    public bool destroyObst()
    {
        //Debug.Log("Inside of the obst contact method of contact script");
        colliderObst = Physics2D.OverlapCircleAll(transform.position, radius, obstFilter);
        if (colliderObst.Length > 0)
        {
            
            return true; //therefore the obst should be destroyed when on impact.
            
        }
        else
        {
            return false;
        }

    }

    //method will be commented out for it is registering a hit on an object...
    //public bool hitPlayer()
    //{
    //    Debug.Log("Inside of the hitPlayers method of contact script ");
    //    colliderPlayer = Physics2D.OverlapCircleAll(transform.position, radius, players);

    //    if (colliderPlayer.Length > 0)
    //    {
    //        Debug.Log("The length of the player collider is: ");
    //        Debug.Log(colliderPlayer.Length);// something is registering a collision.
    //        Debug.Log(colliderPlayer[0]);
    //        return true;
    //    }
    //    else {
    //        return false;
    //    }

    //}
}   
