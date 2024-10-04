using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour
{
    [Header("-=- Pickupable Item -=- ")]

    [Tooltip("The item's physics rigidbody. Leave blank to not use physics.")]
    public Rigidbody ItemPhsyics;
    [Tooltip("The item's 'range' trigger. Ensure 'isTrigger' is marked on this collider component.")]
    public Collider PickupTrigger;

    [HideInInspector] public bool CurrentlyHeld = false; // to check if the item is being held
    [HideInInspector] public int playerlastheld; // store the ID of the player who last held the item
    private Transform Self;

    private PlayerController lastplayerref;

    public float throwForce = 10f; // Force applied when throwing the item

    void Start()
    {
        Self = this.gameObject.transform; // cache reference to this object's transform
        this.gameObject.layer = 7; // ensure pickup is on correct layer
    }

    private void OnTriggerStay(Collider other) // Use stay for a proximity check
    {
        if (!CurrentlyHeld && other.gameObject.GetComponent<PlayerController>()) // check if the player is within the trigger range and not already holding the item
        {
            PlayerController player = other.gameObject.GetComponent<PlayerController>(); // reference the player in range
            if (player.ActionPickup)
            {
                lastplayerref = player;
                Pickup(player); // Call the pickup function
            }
            else
            {
                player.currentItem = this; // set the player's current item reference without picking it up
            }
        }
    }

    public void Pickup(PlayerController player)
    {
        // Player is pressing the pickup button, and the item is in range and not held
        Self.SetParent(player.PickupPoint); // Move the pickup to the player's holding point
        Self.localPosition = Vector3.zero; // Reset position relative to the pickup point
        if (ItemPhsyics) { ItemPhsyics.isKinematic = true; } // Disable physics
        PickupTrigger.enabled = false; // Disable the trigger while holding
        playerlastheld = player.PlayerID; // Store the player's ID who is holding the item
        player.currentItem = this; // Set the player's current item reference
        CurrentlyHeld = true; // Mark as being held
    }

    public void DropMe() // Called when the player drops the item without throwing
    {
        if (CurrentlyHeld)
        {
            Self.SetParent(null);
            if (ItemPhsyics)
            {
                ItemPhsyics.isKinematic = false;
                ItemPhsyics.AddForce(Self.forward * 10f, ForceMode.Impulse);
            }

            PickupTrigger.enabled = true;
            CurrentlyHeld = false;
        }
    }
}