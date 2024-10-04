using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableStationPrefab : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public string InteractionPrompt => prompt;

    public float maxMeter, meter, meterIncrease, meterDecrease;
    public Slider slider;

    public bool Interact(Interactor interactor)
    {
        meter = maxMeter;
        Debug.Log("Interacting");
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
    }

    private void FixedUpdate()
    {
        slider.value = meter;
        if (meter >= 0)
        {
            meter -= meterDecrease;
        }
    }

    public bool Interact5(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    public bool Interact6(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    public bool Interact7(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }

    public bool Interact8(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }
}
