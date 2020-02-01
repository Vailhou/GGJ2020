using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{

    [SerializeField]
    private KeyCode interactionKey = KeyCode.I;

    [SerializeField]
    private float
        maxRayDistance = 2.0f;


    private void FixedUpdate()
    {
        if (Input.GetKey(interactionKey))
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

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);
        Debug.DrawRay(transform.position, rayDirection * maxRayDistance, Color.red, 0.0f);

        if (Physics2D.Raycast(rayOrigin, rayDirection, maxRayDistance))
        {
            MonoBehaviour[] targetList = hit.transform.gameObject.GetComponents<MonoBehaviour>();
            Debug.Log(hit.collider.name);
            foreach (MonoBehaviour mb in targetList)
            {
                Debug.Log("Sending interaction call to interactable target.");
                if (mb is IInteractable)
                {
                    IInteractable interactable = (IInteractable)mb;
                    interactable.Interact();
                    Debug.Log("Sending interaction call to interactable target.");
                }
            }
        }
    }
}