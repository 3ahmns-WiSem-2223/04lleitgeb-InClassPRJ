using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float startingTime = 60;
    [SerializeField] Text timerText;

    void Start()
    {
        startingTime = 60;
    }
    void Update()
    {
        float time = startingTime - Time.time;
        string seconds = (time % 60).ToString("f0");

        timerText.text = "Timer: "  + seconds;

        if (time <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
