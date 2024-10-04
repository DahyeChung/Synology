using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blender : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public float maxMeter, meter, meterIncrease, meterDecrease;
    public Slider slider;

    [SerializeField] private float overheat, overheatInc, overheatDec;
    [SerializeField] private bool overheated;

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        return true;
    }
    public bool Interact2(Interactor interactor)
    {
        if ((meter < maxMeter) && (overheated == false))
        {
            meter += meterIncrease;
            overheat += overheatInc;
        }
        Debug.Log("Interacting Blender");
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
        slider.maxValue = maxMeter;
        overheated = false;
    }

    private void FixedUpdate()
    {
        slider.value = meter;
        if (meter >= maxMeter) { Debug.Log("You Won the Minigame"); meter = 0; overheat = 0; }
        else if (meter >= 0) { meter -= meterDecrease; }

        if (overheat > 3) { overheated = true; }
        else if (overheat <= 0 ) { overheated = false; }
        if (overheat >= 0) { overheat -= overheatDec; }
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
