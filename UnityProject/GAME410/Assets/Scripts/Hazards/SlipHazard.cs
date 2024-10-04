using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipHazard : MonoBehaviour
{
    [Tooltip("Determines how fast the player moves while under the effects of the slipping hazard.")]
    public float slipForce = 3.5f;

    [Tooltip("The amount of time the player is stunned upon collision.")]
    [SerializeField] float stunTime = 2f;

    [Tooltip("The cooldown for the player to be affected by this hazard again once walking away from the hazard.")]
    [SerializeField] float hazardCD = 5.5f;


    // All hazard functions moved to player controller script
    // to prevent a memory crash with triggerstay firing during update inside of a foreach loop (very bad)

    /*private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Player") && !other.GetComponent<PlayerController>().hazardImmune)
        {
            //stop player input and cause them, to slide in current direction
            other.GetComponent<PlayerController>().inHazard = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().hazardImmune && other.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
        {
            //stop player input and cause them, to slide in current direction
            other.GetComponent<PlayerController>().inHazard = true;
        }
    }

    //resolves collision for the affected player when they hit an non-player object
    public void ResolveCollision(GameObject player)
    {
        player.GetComponent<PlayerController>().hazardImmune = true;

        StartCoroutine(EnactHazard(player));

        StartCoroutine(RevertHazardImmunity(player));
    }

    //resolves collision for the affected player when they hit another player
    public void ResolveCollision(GameObject player1, GameObject player2)
    {
        player1.GetComponent<PlayerController>().hazardImmune = true;

        StartCoroutine(EnactHazard(player1));

        StartCoroutine(RevertHazardImmunity(player1));

        //if the second player hasn't been affected by a hazard recently, they'll also be stunned
        if (!player2.GetComponent<PlayerController>().hazardImmune)
        {
            player2.GetComponent<PlayerController>().hazardImmune = true;

            StartCoroutine(EnactHazard(player2));

            StartCoroutine(RevertHazardImmunity(player2));
        }
    }

    IEnumerator EnactHazard(GameObject player)
    {
        player.GetComponent<PlayerController>().inHazard = true;

        //stop player movement
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        //make player drop any held items
        if (player.GetComponent<PlayerController>().currentItem)
        {
            player.GetComponent<PlayerController>().currentItem.DropMe();
            player.GetComponent<PlayerController>().currentItem = null;
        }

        //player is stuck for the specified amount of time
        yield return new WaitForSeconds(stunTime);

        //resume player movement
        player.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePosition;
        player.GetComponent<PlayerController>().inHazard = false;
    }

    IEnumerator RevertHazardImmunity(GameObject player)
    {
        //player is immune from hazards
        yield return new WaitForSeconds(hazardCD);

        //player can be affected by hazards again
        player.GetComponent<PlayerController>().hazardImmune = false;
    }*/
}
