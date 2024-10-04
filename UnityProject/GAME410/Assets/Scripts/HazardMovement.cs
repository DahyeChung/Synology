using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMovement : MonoBehaviour
{
    GameObject target;
    public float moveSpeed = 1;
    public float followDistance = 1.5f;
    public string targetTag = "Player";

    // Flags to prevent repeated messages
    private bool isChasing = false;
    private bool inTriggerBox = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag(targetTag);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 petToTarget = target.transform.position - transform.position;
        if (Vector3.SqrMagnitude(petToTarget) > followDistance * followDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        }
    }

    // Called when the hazard first touches the player's trigger box
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag) && !inTriggerBox)
        {
            Debug.Log("The rat has caught you and is taking your ingredients! Get away from it now!");
            inTriggerBox = true;  // Set flag to indicate hazard is inside the trigger
            isChasing = false;    // Stop chasing message while inside the trigger box
        }
    }

    // Called when the hazard exits the player's trigger box
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("You got away from the rat. You're safe... for now.");
            inTriggerBox = false;  // Reset the flag so the message will log again on next entry
            StartCoroutine(ChasingMessageAfterDelay());
        }
    }

    private IEnumerator ChasingMessageAfterDelay()
    {
        yield return new WaitForSeconds(1f);  // Wait for 1 second
        if (!isChasing)  // Log chasing message only if not already chasing
        {
            Debug.Log("The rat is chasing you!");
            isChasing = true;  // Set the flag to prevent multiple logs until next exit
        }
    }
}

