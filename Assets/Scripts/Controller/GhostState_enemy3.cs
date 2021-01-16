using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostState_enemy3 : MonoBehaviour
{

    //for this script to execute, it requires:
    //the health script
    //the breakerSpawner script

    Health_enemy healthScript;
    SpriteRenderer playerSprite;
    SpriteRenderer ghostColor;
    public GameObject spawnObj;
    BreakerSpawner_Enemy3 spawnScript;

    public float ghostTimer;
    

    //script will by default be disabled until the conditions are met for this code to be enabled.
    void Awake()
    {
        //Debug.Log("Character Died and is in ghost state");
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        healthScript = gameObject.GetComponent<Health_enemy>();
        ghostColor = gameObject.GetComponent<SpriteRenderer>();

        spawnScript = spawnObj.GetComponent<BreakerSpawner_Enemy3>();
        ghostTimer = 5f;
       

    }

    // Update is called once per frame
    void Update()
    {
        
        ghostTimer -= Time.deltaTime;
        ghostColor.color = new Color(0, 0, 0,1f);
        spawnScript.enabled = false;
        ScoreScript.scoreValue += 0;
        if (ghostTimer <= 0f)
        {
            revive();
            Debug.Log("ghost timer ended");
        }
    }

    void revive()
    {
        healthScript.resetHealth();
        playerSprite.color = new Color(1, 1, 1, 1f);
        spawnScript.enabled = true;
        ghostTimer = 5f;
        this.enabled = false;
    }

    

}
