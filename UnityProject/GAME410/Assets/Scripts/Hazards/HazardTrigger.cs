using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTrigger : MonoBehaviour
{
    [Header("-=- Hazard Trigger -=-")]
    [Tooltip("The type of hazard the trigger sends to the player")]
    public Hazard HazardType;

    public enum Hazard
    {
        Slippery,
        Sticky,
        OutOfBounds
    }
}
