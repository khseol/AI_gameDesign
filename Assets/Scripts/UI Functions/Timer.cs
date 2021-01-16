using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float levelCountdown = 30f;
    public GameObject scoringUI;

    Text timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
       timeRemaining = GetComponent<Text>();
        Debug.Log("Time Started up: time is " + levelCountdown);
    }

    // Update is called once per frame
    void Update()
    {
        levelCountdown -= Time.deltaTime;
        timeRemaining.text = "Time: " + Mathf.RoundToInt(levelCountdown);

        if (levelCountdown <= 0f)
        {
            Time.timeScale = 0f;
            scoringUI.SetActive(true);
        }
        else if (levelCountdown == 30f)
        {
            Time.timeScale = 1f;
        }
    }
}
