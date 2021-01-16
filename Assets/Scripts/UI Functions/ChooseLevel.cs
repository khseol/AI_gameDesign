using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseLevel : MonoBehaviour
{
    public void loadEasy()
    {
        SceneManager.LoadScene("Level Easy");
        Time.timeScale = 1f;
    }

    public void loadHard()
    {
        SceneManager.LoadScene("Level Hard");
        Time.timeScale = 1f;
    }
}
