using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown : MonoBehaviour
{
    public float coolDown;

    public GameObject spawnerObj;
    BreakerSpawner_Enemy spawnScript;

    void Awake()
    {
        spawnScript = spawnerObj.GetComponent<BreakerSpawner_Enemy>();
        coolDown = 2f;
    }

    void Update()
    {
        spawnScript.enabled = false;
        coolDown -=Time.deltaTime;
        if (coolDown <= 0)
        {
            spawnScript.enabled = true;
            coolDown = 2f;
            this.enabled = false;

        }
        

    }
}
