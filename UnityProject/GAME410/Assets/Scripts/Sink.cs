using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sink : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public float maxMeter, meter, meterIncrease, meterDecrease;
    public float gMaxMeter, gMeter, gMeterInc, gMeterDec;
    public Slider meterProgress;
    public Slider meterGame;

    [SerializeField] private bool start, active;
    [SerializeField] private float timerActive, timerInc, timerMax;
    public GameObject meterGameSlider;

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        if (meter < maxMeter)
        {
            if (start == false) { start = true; }
            
            if ((gMeter >= gMaxMeter * 2 / 12) && (gMeter <= gMaxMeter * 4 / 12)) {
                meter += meterIncrease;
            }
            if ((gMeter >= gMaxMeter * 9 / 12) && (gMeter <= gMaxMeter * 10 / 12)) {
                meter += meterIncrease * 2;
            }
            if (start == true) { active = false; gMeter = 0; }

        }
        Debug.Log("Interacting Cutting Board");
        return true;
    }
    public bool Interact2(Interactor interactor)
    {
        return true;
    }

    public bool Interact3(Interactor interactor)
    {
        return true;
    }

    public bool Interact4(Interactor interactor)
    {
        return true;
    }

    private void Start()
    {
        meterProgress.maxValue = maxMeter;
        meterGame.maxValue = gMaxMeter;

        start = false;
        active = false;
        timerActive = 0;
        meterGameSlider.SetActive(false);
    }

    private void FixedUpdate()
    {
        meterProgress.value = meter;
        meterGame.value = gMeter;
        if (meter >= maxMeter) { Debug.Log("You Won the Minigame"); meter = 0; gMeter = 0; start = false; active = false; meterGameSlider.SetActive(false); }
        else if (meter >= 0) { meter -= meterDecrease; }

        if (gMeter >= gMaxMeter) { active = false; gMeter = 0; }
        if (timerActive > timerMax) { active = true; timerActive = 0; }

        if (start == true)
        {
            if (active == true) {
                timerActive = 0;
                gMeter += gMeterInc;
                meterGameSlider.SetActive(true);
            }
            else if (active == false) {
                timerActive += timerInc;
                meterGameSlider.SetActive(false);
            }

        }
    }

    public bool Interact5(Interactor interactor)
    {
        return true;
    }

    public bool Interact6(Interactor interactor)
    {
        return true;
    }

    public bool Interact7(Interactor interactor)
    {
        return true;
    }

    public bool Interact8(Interactor interactor)
    {
        return true;
    }
}