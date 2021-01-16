using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Breaker_enemy4 : MonoBehaviour
{
    public float countdown;

    public GameObject getContainer;
    StarBurst_enemy4 explosionScript;

    void Awake()
    {
        explosionScript = getContainer.GetComponent<StarBurst_enemy4>();
    }

    void Update()
    {
        //Debug.Log("Inside of the destroy script");
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {


            //call or reference a method from the starburst script to create the explosio
            explosionScript.Burst(this.gameObject);
            Destroy(gameObject); //this should be caleed after the burst sequence has been fulfilled.
        }
    }

    //there is a problem where the instantiate objects will need to independently run their own destroy timer.
    //only solution available would put this function inside of the burst pixel prefab... so that each prefab acts independently...

}
