/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    public float speed = 5f;                  // Speed at which the hazard moves
    private Transform player;                 // Reference to the player's transform
    private PlayerInventory playerInventory;  // Reference to the player's inventory

    private void Start()
    {
        // Find the player by tag in the scene and get their transform and inventory components
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerInventory = playerObject.GetComponent<PlayerInventory>();
        }
    }

    private void Update()
    {
        // If the player is found, move towards them
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Calculate direction to move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the hazard collided with the player
        if (other.CompareTag("Player"))
        {
            // If it touches the player, remove items from the player's inventory
            if (playerInventory != null)
            {
                playerInventory.RemoveItems(1); // Remove 1 item
            }
        }
    }
}
*/