using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private KeyCode interactionKey = KeyCode.I;

    [SerializeField]
    private float
        maxRayDistance = 6.0f;


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(interactionKey))
        {
            TryInteraction();
        }
    }


    /// <summary>
    /// Creates RayCast from this GameObject, and a list of objects hit, that implement IInteractable.
    /// Calls every list member's Interact function.
    /// </summary>
    public void TryInteraction()
    {
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = -transform.up;

        RaycastHit2D[] hitList = new RaycastHit2D[5];
        ContactFilter2D cf = new ContactFilter2D() { layerMask = layerMask };
        Debug.DrawRay(transform.position, rayDirection * maxRayDistance, Color.red, 0.0f);

        if (0 < Physics2D.Raycast(rayOrigin, rayDirection, cf, hitList, maxRayDistance))
        {
            //MonoBehaviour[] targetList = hit.transform.gameObject.GetComponents<MonoBehaviour>();
            foreach (RaycastHit2D hit in hitList)
            {

                if (!hit)
                {
                    Debug.Log("Hit null.");
                    return;
                }

                MonoBehaviour mb = hit.collider.gameObject.GetComponent<MonoBehaviour>();

                if (mb is IInteractable)
                {
                    IInteractable interactable = (IInteractable)mb;
                    interactable.Interact();
                    Debug.Log("Sending interaction call " + mb.name);
                }
            }
        }
    }
}