using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This is an example script on how you can reference pickups in minigames or whatever.
// You can simply take this whole script and replace ResetPickup() with whatever action you want to do with the pickup.
// In this script, it just sets the object to a transform after forcing the player to drop it.


public class PickupReferenceTester : MonoBehaviour
{
    public TextMeshPro Display;
    private PickupItem pickup;
    private string displaymsg;
    public Transform ResetHere;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            // pickup found!
            pickup = other.GetComponent<PickupItem>();
            if (pickup.CurrentlyHeld)
            {
                pickup.DropMe();
                pickup.enabled = false;
                displaymsg = "Player " + pickup.playerlastheld + " scored!";
                Display.text = displaymsg;
                ResetPickup();
            }
            
        }
    }

    void ResetPickup()
    {
        pickup.transform.position = ResetHere.position;
    }
}
