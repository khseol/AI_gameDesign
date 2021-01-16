using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : MonoBehaviour
{
    public float timer;
    SpriteRenderer playerSprite;

    void Awake()
    {
        //Debug.Log("Script is enabled");
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
        timer = 1.5f;

    }
    void Update()
    {
        
        timer -= Time.deltaTime;
        playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0.3f);
        if (timer <= 0f)
        {
            playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            this.enabled = false;
            timer = 1.5f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled == true)
        {
            ScoreScript.scoreValue += 0;
        }
    }
}
