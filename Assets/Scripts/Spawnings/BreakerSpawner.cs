using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakerSpawner : MonoBehaviour //where the actual spawning of the breakers will take place
{
    public GameObject LR_breaker_prefab;
    public GameObject SR_breaker_prefab;

    public GameObject the_player;
    CharacterController player_script;

    // Update is called once per frame

    //WASD as alt movement are disabled from the project setting.
    

    int limit_LR = 3;
    int counter_LR;
    int limit_SR = 2;
    int counter_SR;

    Vector2 spawning;

    void Start()
    {
        player_script = the_player.GetComponent<CharacterController>();

       
        counter_LR = 0;
        counter_SR = 0;

    }
    //responsible for confirming bomb spawn location and limits
    void Update()
    {
        //checking to see if the keydown of 'Q' was pushed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (counter_LR != limit_LR)
            {
                //checking if the key was pressed
                //lr_script.toRender(keyDownA);
                //Debug.Log("LR was confirmed");
                //will be able to get the player's position and spawn the breakers

                canSpawn(limit_LR, LR_breaker_prefab); // will need to track the clones through some array
                //counter_LR += 1;
                //Debug.Log(clones_LR[0]);
                
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (counter_SR != limit_SR)
            {
                //Debug.Log("SR was confirmed");
                canSpawn(limit_SR, SR_breaker_prefab); // will need to track the clones through some array
                                                                 //counter_SR += 1;
                                                                 //Debug.Log(counter_SR);
            }
        }
        reCount();
        //showArray();
    }
    //10/15/2020 WORK ON TRACKING, TIMER AND BREAKER SET OFF
    void canSpawn(int limit, GameObject prefab)
    {
        string prefabName = prefab.name + "(Clone)";
        bool statement = countChildren(prefabName, limit_SR, limit_LR);

        //if the list is in fact NOT empty, then placement of breakers is set to false 
        if (statement == false) //a crude way of limiting the number of clones produced...will need to change this to keep track of clones, NOT COUNT.
        {
            //Debug.Log("limit reached, breaker cannot be placed");
        }
        if (statement == true)
        {
            spawning = new Vector2(the_player.transform.position.x, the_player.transform.position.y);
            GameObject spawner = Instantiate(prefab, spawning, Quaternion.identity, this.transform); //i will need to round the x and y positions of the breakers set to their nearest int and add by 0.5 for the center offset.
           
            //Debug.Log("condition met, breaker placed");
        }

    }
 
    bool countChildren(string prefabName, int limitSR, int limitLR)
    {//the point of the script is to count how many of each instantiated objects of breakers there are, starting from 0, FOR EACH CALL
        //counter_LR = 0;
        //counter_SR = 0;

        //Debug.Log("Inside the count children method");
        if (transform.childCount <= 0 || counter_LR <= 0 || counter_SR <= 0)
        {
            //Debug.Log("at least one child is not present confirmed");
            //Debug.Log("Counter for LR: " + counter_LR);
            //Debug.Log("Counter for SR: " + counter_SR);
            return true;
        }
        if (transform.childCount > 0)
        {
            //Debug.Log("More than 0 children found in the object confirmed.");
            if (Input.GetKeyDown(KeyCode.Q) && counter_LR <=limit_LR)
            {
                //Debug.Log("Input A condition confirmed");
                
                foreach (Transform child in this.transform)
                {
                    if (child.name == prefabName)
                    {
                        counter_LR += 1;
                        //Debug.Log("Counter for LR: " + counter_LR);
                        //Debug.Log("Counter for SR: " + counter_SR);
                        return true;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && counter_SR <=limit_SR)
            {
                //Debug.Log("Input D condition confirmed");
                //Debug.Log(limit_SR);
                foreach(Transform child in this.transform)
                {
                    if (child.name == prefabName)//this will return false if none are present.
                    {
                        counter_SR += 1;
                        //Debug.Log("Counter for LR: " + counter_LR);
                        //Debug.Log("Counter for SR: " + counter_SR);
                        return true;
                    }
                }
            }


        }
        return false;
    }

    void reCount()
    {
        int newCountLR = 0;
        int newCountSR = 0;

        if (transform.childCount > 0)
        {
            foreach (Transform child in this.transform)
            {
                if (child.name == "LR_Breaker(Clone)")
                {
                    newCountLR += 1;
                }
                if (child.name == "SR_Breaker(Clone)")
                {
                    newCountSR += 1;
                }
            }
            counter_LR = newCountLR;
            counter_SR = newCountSR;
        }

        if (transform.childCount <= 0)
        {
            counter_LR = newCountLR;
            counter_SR = newCountSR;
        }

        //Debug.Log("New Counters for LR: " + counter_LR);
        //Debug.Log("New Counters for SR: " + counter_SR);
    }
}
