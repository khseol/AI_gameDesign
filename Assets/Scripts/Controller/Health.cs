using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script will handle any collision between the player and the gameObjects that can do harm.
/// 
/// the basis for this script is for the player to start out with a health
/// player is hit, health is reuced by one and the player enters a state of invincibility for 3 seconds before the player
/// can actually be hit again
/// 
/// player's health reaches or is below zero:
/// health will stay at zero and the player will be in a GHOST state
/// 
/// while player is ghost state:
/// they are in ghost state for about 5-7 seconds before respawning
/// during, player is able to freely move, but they WILL NOT be able to SET breakers while the timer is still in play.
/// player will be in a isTrigger for players and breakers and burst, NOT for obst or walls!
/// </summary>
public class Health : MonoBehaviour
{
    bool enableScript = false;
    bool enableScript_Ghost = false;
    public int health = 2;
    Invincibility noDamage_script;
    GhostState ghostStateScript;

    void Start()
    {
        noDamage_script = gameObject.GetComponent<Invincibility>();
        ghostStateScript = gameObject.GetComponent<GhostState>();
    }

    void Update()
    {
        if (health <= 0)
        {
            enableScript_Ghost = true;
        }
        else {
            enableScript_Ghost = false;
        }
        if (enableScript_Ghost == true)
        {
            ghostStateScript.enabled = true;
        }
    }

    void OnTriggerStay2D(Collider2D onComing)
    {
        if ((onComing.gameObject.tag == "burst_enemy" || onComing.gameObject.tag == "burst") && noDamage_script.enabled == false && health > 0)
        {
           //Debug.Log("the invulnerability script is " + noDamage_script.enabled);
            applyDamage(1);
            enableScript = true;
        }
        if (enableScript == true)
        {
            noDamage_script.enabled = true;
        }

    }
    public void applyDamage(int damage)
    {
        health = health - damage;
    }

    public void resetHealth()
    {
        health = 2;
    }

    public int getHealth
    {
        get {
            return health;
        }
    }


}
