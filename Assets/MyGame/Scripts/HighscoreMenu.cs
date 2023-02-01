using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreMenu : MonoBehaviour
{

    public Text highscoreText;
   
    void Start()
    {
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
    }

    // Update is called once per frame
    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
