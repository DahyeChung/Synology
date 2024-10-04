using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    [Header("Player Controller")]
    public int PlayerID = 1;

    [Tooltip("The player animator for movement and actions.")]
    public Animator PlayerAnimator;

    [Tooltip("The player's collider for collision and physics")]
    public Collider PlayerCollider;

    [Tooltip("The player Rigidbody for movement.")]
    public Rigidbody PlayerRB;

    [Tooltip("Any visual objects on this player. (These are disabled on dropout)")]
    public Renderer[] PlayerRenderers;

    [Tooltip("This player's speaker for sound effects")]
    public AudioSource Speaker;


    [Space]

    [Header("Input ---------------------------")]
    public KeyCode MoveFRWD = KeyCode.W;
    public KeyCode MoveBACKWD = KeyCode.S;
    public KeyCode MoveLEFT = KeyCode.A;
    public KeyCode MoveRIGHT = KeyCode.D;

    public KeyCode Button1 = KeyCode.BackQuote;
    public KeyCode Button2 = KeyCode.Alpha1;

    [Header("Pickup --------------------------")]
    [Tooltip("The transform/position where to hold an object (Above players head?)")]
    public Transform PickupPoint;
    

    #region Internal Variables
    // Internal variables
    [HideInInspector] public bool ActionPickup;
    [HideInInspector] public bool ActionInteract;
    [HideInInspector] public GameManage Manager;
    [HideInInspector] public PickupItem currentItem;
    [HideInInspector] public bool inHazard = false;
    [HideInInspector] public bool disableInput = false;
    [HideInInspector] public bool canMove = true;
    //[HideInInspector] public bool hazardImmune = false;
    // No need to check hazard immunity, just reference above value.
    bool active = true;
    float inactivetime = 0f;
    Transform Self;
    #endregion

    private void Start()
    {
        Self = this.gameObject.transform;
        Manager = (GameManage)FindObjectOfType(typeof(GameManage));
    }


    // Private variables
    Vector3 Movement;

    public void HandlePlayer()
    {
        if (active)
        {
            DoAction();
            GetInput();
        }
        else if (AnyInput())
        {
            // While inactive, check for any input at all from this player < if they press a button or move, become active again.
            inactivetime = 0f;
            PlayerCollider.enabled = true;
            PlayerRB.isKinematic = false;
            for (int i = 0; i < PlayerRenderers.Length; i++) { PlayerRenderers[i].enabled = true; }

            active = true;
        }

    }

    void GetInput()
    {
        PlayerAnimator.SetBool("Action1", false);
        PlayerAnimator.SetBool("Action2", false);

        Movement = Vector3.zero;
        PlayerAnimator.SetBool("Walk", false);

        if (canMove == true)
        {
            if (Input.GetKey(MoveFRWD)) { Movement += Vector3.forward; PlayerAnimator.SetBool("Walk", true); }
            if (Input.GetKey(MoveBACKWD)) { Movement -= Vector3.forward; PlayerAnimator.SetBool("Walk", true); }
            if (Input.GetKey(MoveLEFT)) { Movement -= Vector3.right; PlayerAnimator.SetBool("Walk", true); }
            if (Input.GetKey(MoveRIGHT)) { Movement += Vector3.right; PlayerAnimator.SetBool("Walk", true); }
        }

        if (Input.GetKey(Button1)) { PlayerAnimator.SetBool("Action1", true); }

        if (Input.GetKeyDown(Button2))
        {
            if (currentItem != null)
            {
                if (currentItem.CurrentlyHeld)
                {
                    currentItem.DropMe(); // Throw the item if currently held
                    currentItem = null; // Clear the current item reference
                }
                else
                {
                    currentItem.Pickup(this); // Pickup the item
                }
            }
        }

        if (!AnyInput())
        {
            // Handle inactivity logic
            if (inactivetime < Manager.idleTimeOut)
            {
                inactivetime += Time.deltaTime;
            }
            else
            {
                PlayerCollider.enabled = false;
                PlayerRB.isKinematic = true;
                for (int i = 0; i < PlayerRenderers.Length; i++) { PlayerRenderers[i].enabled = false; }
                active = false;
            }
        }
    }
    

    void DoAction()
    {
        // Handle player input/movement
        // Moving the player hazard check to this function instead. PLEASE DO NOT ADD IT BACK IN THE INPUT FUCTION 

        if (!disableInput)
        {
            PlayerRB.AddForce(Movement * Manager.PlayerSpeed, ForceMode.Impulse);
            if (PlayerRB.velocity.magnitude > Manager.MaxPlayerSpeed)
            {
                // Clamp the velocity to the max speed while keeping the direction
                PlayerRB.velocity = PlayerRB.velocity.normalized * Manager.MaxPlayerSpeed;
            }
        }
    }

    bool AnyInput() // This is a helper bool function to check if there is any input from the player
    {
        return (Input.GetKey(MoveFRWD) || Input.GetKey(MoveBACKWD) || Input.GetKey(MoveLEFT) || Input.GetKey(MoveRIGHT) ||
            Input.GetKey(Button1) || Input.GetKey(Button2) || ActionPickup || ActionInteract);
    }

    // ====================================== WARNING ============================================================================

    // This is a bad implementation of the slip hazard, as it will check for every slip object within the scene after
    // colliding with anything, this is very slow and should be replaced with a trigger or collision check via the hazard
    // directly.

    // Old Function
    /*private void OnCollisionEnter(Collision collision)
    { 
        if (inHazard)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                FindObjectOfType<SlipHazard>().ResolveCollision(this.gameObject, collision.gameObject);
            }
            else
            {
                FindObjectOfType<SlipHazard>().ResolveCollision(this.gameObject);
            }
        }
    }*/

    // New Function
    private void OnTriggerEnter(Collider other)
    {
        if (!inHazard && (Manager.HazardMask.value & (1 << other.gameObject.layer)) > 0) 
        {
            // If the player is not already in a hazard and has entered one
            Debug.Log("Player with ID: " + PlayerID + " hit the hazard: " + other.gameObject.name);

            inHazard = true;


            if (other.gameObject.GetComponent<HazardTrigger>()) // Check if the hazard has the hazard trigger script.
            {
                switch ((int)other.gameObject.GetComponent<HazardTrigger>().HazardType)
                {
                    case 0: // Slippery
                        PlayerRB.AddForce(Movement * Manager.PlayerSpeed * 5, ForceMode.Impulse); // simulate a "slip"
                        // Lower the player's friction to make them slip in the direction they were moving
                        PlayerCollider.material.dynamicFriction = 0.01f;
                        PlayerCollider.material.staticFriction = 0.01f;
                        disableInput = true;
                        StartCoroutine(DelayFunction(Manager.HazardPenalty));

                        break;
                    case 1: // Sticky
                        PlayerCollider.material.dynamicFriction = 14f;
                        PlayerCollider.material.staticFriction = 14f;
                        StartCoroutine(DelayFunction(Manager.HazardPenalty));
                        break;
                    case 2:// OutOfBounds

                        break;
                }

                // You can easily add more here by copying the case statement and adding the HazardTrigger.cs enum
                // at the position as needed.
            }
        }
    }

    IEnumerator DelayFunction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        RemoveHazardEffects();
    }



    #region Public Helper Funcs



    public void RemoveHazardEffects()
    {
        inHazard = false; // Remove status effect
        disableInput = false; // Allow the player to move again

        // Reset the player's friction.
        PlayerCollider.material.dynamicFriction = 7f;
        PlayerCollider.material.staticFriction = 7f;
    }

    public void PlaySound(AudioClip sfx)
    {
        Speaker.PlayOneShot(sfx);
    }

    public void TeleportPlayer(Transform location)
    {
        // Get just the Y rotation to ensure the teleport is a safe rotation
        Self.SetPositionAndRotation(location.position, Quaternion.Euler(0, location.rotation.y, 0));
    }

    public void RespawnPlayer()
    {
        Transform location = Manager.RespawnLocation;
        Self.SetPositionAndRotation(location.position, Quaternion.Euler(0, location.rotation.y, 0));
    }

    #endregion


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(PickupPoint.position, Vector3.one*0.2f);
    }

#endif
}
