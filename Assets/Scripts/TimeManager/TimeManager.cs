using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    float bestLapTime;
    public static bool isTimeRunning;

    float time;
    public Text timerText;
    public Text bestTimeText;
    private void Start()
    {
        time = 0;
        isTimeRunning = false;
        bestLapTime = PlayerPrefs.GetFloat("BestLapTime", 0);
        SaveBestTime();
    }
    private void Update()
    {
        if (isTimeRunning)
        {
            if(time > -1)
            {
                time += Time.deltaTime;
                DisplayTime(time);
            }
        }
    }

    private void DisplayTime(float time)
    {
        float hours = Mathf.FloorToInt(time / 3600);
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("Lap Time: " + "{0:00}:{1:00}:{2:00}", hours, minutes, seconds);

        if (GameManager.isRaceFinished)
        {
            if (time > bestLapTime && bestLapTime == 0)
            {
                PlayerPrefs.SetFloat("BestLapTime", time);
            }
            else
            {
                if (time < bestLapTime)
                {
                    PlayerPrefs.SetFloat("BestLapTime", time);
                }
            }
            SaveBestTime();
        }
    }

    private void SaveBestTime()
    {
        bestLapTime = PlayerPrefs.GetFloat("BestLapTime", 0);
        float bestHour = Mathf.FloorToInt(bestLapTime / 3600);
        float bestMinutes = Mathf.FloorToInt(bestLapTime / 60);
        float bestSeconds = Mathf.FloorToInt(bestLapTime % 60);

        bestTimeText.text = string.Format("Best Time: " + "{0:00}:{1:00}:{2:00}", bestHour, bestMinutes, bestSeconds);
    }
}
