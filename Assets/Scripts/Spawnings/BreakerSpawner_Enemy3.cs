using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this  script will need to call and reference the enemy controller, checking the status of the inner circle.
/// </summary>

public class BreakerSpawner_Enemy3 : MonoBehaviour
{
    public GameObject enemyPlayer;
    Cooldown coolDownScript;

    public GameObject LR_breaker_prefab;
    public GameObject SR_breaker_prefab;

    public GameObject the_enemy;
    EnemyController enemy_script;

    int limit_LR = 3;
    int counter_LR;
    int limit_SR = 2;
    int counter_SR;

    Vector2 spawning;
    // Start is called before the first frame update
    void Start()
    {
        enemy_script = the_enemy.GetComponent<EnemyController>();
        counter_LR = 0;
        counter_SR = 0;
        coolDownScript = enemyPlayer.GetComponent<Cooldown>();
    }

    // Update is called once per frame
    void Update()
    {
        //will need to cinsistently check for the number instantiate prefabs reach or exceed the limit
        //enemy will be checking radius 
        if (enemy_script.checkOuterCircle() == true)
        {
            if (counter_LR != limit_LR) //when outer circle is breached ie while this is 
            {
                //checking if the key was pressed
                //lr_script.toRender(keyDownA);
                //Debug.Log("LR was confirmed");
                //will be able to get the player's position and spawn the breakers

                bool z = canSpawn(limit_LR, LR_breaker_prefab); // will need to track the clones through some array
                                                                //counter_LR += 1;
                                                                //Debug.Log(clones_LR[0]);
                if (z == true)
                {
                    coolDownScript.enabled = true;
                    this.enabled = false;
                }
                

            }
        }

        if (enemy_script.checkOuterCircle() == true && enemy_script.checkInnerCircle() == true)
        {
            if (counter_SR != limit_SR) //when the inner and outer circle have been breached
            {
                //Debug.Log("SR was confirmed");
                bool x = canSpawn(limit_SR, SR_breaker_prefab); // will need to track the clones through some array
                                                                //counter_SR += 1;
                                                                //Debug.Log(counter_SR);
                if (x == true)
                {
                    coolDownScript.enabled = true;
                    this.enabled = false;
                }
            }
        }
        reCount();

    }

    bool canSpawn(int limit, GameObject prefab)
    {
        string prefabName = prefab.name + "(Clone)";
        bool statement = countChildren(prefabName, limit_SR, limit_LR);
        bool enableCoolDown = false;

        //if the list is in fact NOT empty, then placement of breakers is set to false 
        if (statement == false) //a crude way of limiting the number of clones produced...will need to change this to keep track of clones, NOT COUNT.
        {
            //Debug.Log("limit reached, breaker cannot be placed");
            enableCoolDown = false;
        }
        if (statement == true)
        {
            spawning = new Vector2(the_enemy.transform.position.x, the_enemy.transform.position.y);
            GameObject spawner = Instantiate(prefab, spawning, Quaternion.identity, this.transform); //i will need to round the x and y positions of the breakers set to their nearest int and add by 0.5 for the center offset.

            enableCoolDown = true;
            //Debug.Log("condition met, breaker placed");
        }
        return enableCoolDown;

    }

    bool countChildren(string prefabName, int limitSR, int limitLR)
    {//the point of the script is to count how many of each instantiated objects of breakers there are, starting from 0, FOR EACH CALL
        //counter_LR = 0;
        //counter_SR = 0;

        //Debug.Log("Inside the count children method");
        if (transform.childCount <= 0 || counter_LR <= 0 || counter_SR <= 0)
        {
            return true;
        }
        if (transform.childCount > 0)
        {
            //Debug.Log("More than 0 children found in the object confirmed.");
            if (enemy_script.checkOuterCircle() == true && counter_LR <= limit_LR)
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

            if ((enemy_script.checkOuterCircle() == true && enemy_script.checkInnerCircle() == true) && counter_SR <= limit_SR)
            {
                //Debug.Log("Input D condition confirmed");
                //Debug.Log(limit_SR);
                foreach (Transform child in this.transform)
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
                if (child.name == "LR_Breaker_enemy3(Clone)")
                {
                    newCountLR += 1;
                }
                if (child.name == "SR_Breaker_enemy3(Clone)")
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
