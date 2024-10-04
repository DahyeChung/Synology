using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform interactionPoint;
    [SerializeField] private float interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask interactableMask;

    private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numFound;
    public PlayerController playerController;


    private void Update()
    {
        numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
        if (numFound > 0) {
            var interactable = colliders[0].GetComponent<Interactable>();
            {
                if (interactable != null && Input.GetKeyDown(KeyCode.Period)) {
                    interactable.Interact(this);
                }
                if (interactable != null && Input.GetKey(KeyCode.Period)) {
                    interactable.Interact2(this);
                }
                if (interactable != null && Input.GetKeyDown(KeyCode.Slash))
                {
                    interactable.Interact3(this);
                }
                if (interactable != null && Input.GetKey(KeyCode.Slash))
                {
                    interactable.Interact4(this);
                }
                if (interactable != null && Input.GetKey(KeyCode.UpArrow))
                {
                    interactable.Interact5(this);
                }
                if (interactable != null && Input.GetKey(KeyCode.RightArrow))
                {
                    interactable.Interact6(this);
                }
                if (interactable != null && Input.GetKey(KeyCode.DownArrow))
                {
                    interactable.Interact7(this);
                }
                if (interactable != null && Input.GetKey(KeyCode.LeftArrow))
                {
                    interactable.Interact8(this);
                }
            }
        }
    }


#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }
#endif

}
