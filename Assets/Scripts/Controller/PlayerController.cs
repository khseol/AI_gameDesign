using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    //public float moveSpeed; // used to test how fast the player and the enemies should be moving at
    public float maxSpeed = 3.25f;
    private Rigidbody2D rb;
    private Vector2 velocityMove;
    

    //public GameObject long_breaker;//references the game object of the DnD
    //public GameObject short_breaker;

    // Start is called before the first frame update
    void Start()
    {
        //controller will grab access of the rigidbody 2d component off from the player
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame to gather information on 'input' information
    void Update()
    {
        //per frame update, the controller will take in movement inputs for the new 
        //position of the character
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        velocityMove = movement.normalized * maxSpeed;
        Vector3 characterFlip = transform.localScale;

        //if statement of when to flip the character sprite when it goes left/right
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterFlip.x = -1;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            characterFlip.x = 1;
        }
        transform.localScale = characterFlip;

        
        
    }

    void FixedUpdate()//method to create the action of movement
    {
        rb.MovePosition(rb.position + velocityMove * Time.deltaTime);

    }

    //a test for checking collision in 2D world
    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("I collided with something."); //works on parent objects that contain a collider, but not on objects where the parent has no coliider but the children do.
    //}
    
}
