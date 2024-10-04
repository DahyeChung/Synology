using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CuttingStation : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public float maxMeter, meter, meterIncrease, meterDecrease;
    public float gMaxMeter, gMeter, gMeterInc, gMeterDec;
    public Slider meterProgress;
    public Slider meterGame;

    [SerializeField] private bool start;
    [SerializeField] private bool alternate;

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        if (meter < maxMeter)
        {
            if (start == false) { start = true; }
            if ((gMeter >= gMaxMeter * 2/12) && (gMeter <= gMaxMeter * 4 / 12))
            {
                meter += meterIncrease;
            }
            if ((gMeter >= gMaxMeter * 9/12) && (gMeter <= gMaxMeter * 10 / 12))
            {
                meter += meterIncrease * 2;
            }
            
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

        alternate = true;
        start = false;
    }

    private void FixedUpdate()
    {
        meterProgress.value = meter;
        meterGame.value = gMeter;
        if (meter >= maxMeter) { Debug.Log("You Won the Minigame"); meter = 0; gMeter = 0; start = false; }
        else if (meter >= 0) { meter -= meterDecrease; }

        if (start == true)
        {
            if (gMeter >= gMaxMeter) { alternate = false; }
            else if (gMeter <= 0) { alternate = true; }

            if (alternate == true) { gMeter += gMeterInc; }
            else if (alternate == false) { gMeter -=gMeterDec; }
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
