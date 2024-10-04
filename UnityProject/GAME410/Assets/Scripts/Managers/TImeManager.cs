using System;
using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float _minute = 60;

    public void Init()
    {

        TimerStart();
    }


    public void TimerStart()
    {
        StartCoroutine(CoStartTimer());
    }

    // Count down the game time
    IEnumerator CoStartTimer()
    {
        while (Managers.Game.TimeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            Managers.Game.TimeRemaining--;

            // Remaining time in MM:SS format
            TimeSpan timeSpan = TimeSpan.FromSeconds(Managers.Game.TimeRemaining);
            string formattedTime = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            Debug.Log("Time Remaining in this Stage : " + formattedTime);
        }

        Debug.Log("Time Out!!");
    }

#if UNITY_EDITOR

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Managers.Game.TimeRemaining = 0;
        }
    }


#endif


}