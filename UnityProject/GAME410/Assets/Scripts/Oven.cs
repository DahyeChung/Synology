using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Oven : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public float maxMeter, meter, meterIncrease, meterDecrease;
    public Slider slider;

    [SerializeField] private bool start;
    [SerializeField] private bool alternate;

    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        if (start == false) { start = true; }
        if ((meter >= maxMeter * 1/4) && (meter <= maxMeter * 3/4))
        {
            Debug.Log("You Win");
            start = false;
            meter = 0;

        }
        Debug.Log("Interacting Oven");
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
        slider.maxValue = maxMeter;
        alternate = true;
        start = false;
    }

    private void FixedUpdate()
    {
        slider.value = meter;
        if (start == true)
        {
            if (meter >= maxMeter) { alternate = false; }
            else if (meter < 0) { alternate = true; }

            if (alternate == true) { meter += meterIncrease; }
            else if (alternate == false) { meter -= meterDecrease; }
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
