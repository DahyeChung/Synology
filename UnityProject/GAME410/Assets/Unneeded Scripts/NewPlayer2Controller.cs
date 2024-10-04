using UnityEngine;

public class NewPlayer2Controller : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component not found on this GameObject.");
        }
        rb.freezeRotation = true; // Prevents the player from rotating due to physics
    }

    void FixedUpdate()
    {
        // Create movement vector
        Vector3 movement = Vector3.zero;

        // Check input from the WASD keys
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
        }

        // Check input for the "A" and "B" buttons on the arcade machine
        bool isActionA = Input.GetKey(KeyCode.BackQuote); // "`" key on the keyboard
        bool isActionB = Input.GetKey(KeyCode.Alpha1);   // "1" key on the keyboard

        // Example action based on "A" and "B" button inputs
        if (isActionA)
        {
            // Perform an action associated with the "A" button
            Debug.Log("Action A triggered!");
        }
        if (isActionB)
        {
            // Perform an action associated with the "B" button
            Debug.Log("Action B triggered!");
        }

        // Apply movement to Rigidbody
        rb.MovePosition(transform.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

