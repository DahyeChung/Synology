using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraPlayerControllerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 10f;
    private float gravityValue = -9.81f;
    //private Animator animator;
    private PlayerState playerState;

    public Transform cam;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        //animator = GetComponent<Animator>();
        playerState = GetComponent<PlayerState>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (!playerState.isAlive)
        {
            /*if (animator.GetBool("IsAlive"))
            {
                animator.SetBool("IsAlive", false);
                Destroy(this.gameObject, 5f);
            }*/
            return;
        }

        float forwardMovement = Input.GetAxis("Vertical");
        //animator.SetFloat("ForwardMovement", forwardMovement);

        float sideMovement = Input.GetAxis("Horizontal");
        //animator.SetFloat("SideMovement", sideMovement);

        Vector3 camForward = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
        Vector3 moveForward = camForward * forwardMovement;
        Vector3 moveSide = cam.transform.right * sideMovement;
        Vector3 moveDir = Vector3.Normalize(moveForward + moveSide);

        if (moveDir != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
        }

        Vector3 move = moveDir * playerSpeed * Time.deltaTime;
        playerVelocity.x = move.x;
        playerVelocity.z = move.z;

        playerVelocity.y += gravityValue * Time.deltaTime;

        controller.Move(playerVelocity);
    }

}
