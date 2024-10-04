using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RollingPin : MonoBehaviour, Interactable
{
    [SerializeField] private string prompt;
    public float maxMeter, meter, meterIncrease, meterDecrease;
    public Slider slider;

    [SerializeField] private bool start;
    [SerializeField] private float alternate;


    public string InteractionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        if (start == false) { start = true; interactor.playerController.canMove = false; alternate = 4; }
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
        start = false;
        alternate = 0;
    }

    private void FixedUpdate()
    {
        slider.value = meter;
        if (meter >= maxMeter) { Debug.Log("You Won the Minigame"); meter = 0; start = false; }
        else if (meter > 0) { meter -= meterDecrease; }
    }

    public bool Interact5(Interactor interactor)
    {
        if (meter < maxMeter && alternate == 4)
        {
            meter += meterIncrease;
            alternate = 1;
            if (meter >= maxMeter) { interactor.playerController.canMove = true; }
        }
        return true;
    }

    public bool Interact6(Interactor interactor)
    {
        if (meter < maxMeter && alternate == 1)
        {
            meter += meterIncrease;
            alternate += 1;
            if (meter >= maxMeter) { interactor.playerController.canMove = true; }
        }
        return true;
    }

    public bool Interact7(Interactor interactor)
    {
        if (meter < maxMeter && alternate == 2)
        {
            meter += meterIncrease;
            alternate += 1;
            if (meter >= maxMeter) { interactor.playerController.canMove = true; }
        }
        return true;
    }

    public bool Interact8(Interactor interactor)
    {
        if (meter < maxMeter && alternate == 3)
        {
            meter += meterIncrease;
            alternate += 1;
            if (meter >= maxMeter) { interactor.playerController.canMove = true; }
        }
        return true;
    }
}
