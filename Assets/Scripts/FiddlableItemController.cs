using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiddlableItemController : MonoBehaviour, IInteractable
{
    [SerializeField]
    AudioClip _fiddleSound;

    [SerializeField]
    private bool destroyItem = false;

    private float audioVol = 7f;
    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Interact()
    {
        Debug.Log("Fiddling.");
        audioSource.PlayOneShot(_fiddleSound, audioVol);
        if (destroyItem) Destroy(gameObject);
    }
}