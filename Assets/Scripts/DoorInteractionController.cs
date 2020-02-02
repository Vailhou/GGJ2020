using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractionController : MonoBehaviour, IInteractable
{
    [SerializeField]
    AudioClip
        _lockedSound,
        _unlockSound;

    AudioSource audioSource;

    GameManager gameManager;
    public Item _requiredItem;
    public Item _obtainableItem;
    private float _size = 3f;
    private Vector3 _sizeVector;
    private string keyName = "HallwayKey";
    private float audioVol = 7f;

    public void Start()
    {
        GameObject gameManagerObj = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        _sizeVector = new Vector3(_size, _size);
    }

    public void Interact()
    {
        if (!gameManager.checkIfContains(keyName))
        {
            //GetComponent<AudioSource>().Play();
            Debug.Log("Door is locked.");
            audioSource.PlayOneShot(_lockedSound, audioVol);
            return;
        }

        Debug.Log("Door unlocked.");
        gameManager.Add(_obtainableItem);
        audioSource.PlayOneShot(_unlockSound, audioVol);

        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        sr.sprite = _obtainableItem.collectedSprite;

        //go.transform position = new Vector2(_item.pickedUpIconX, _item.pickedUpIconY);
        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.9f, Screen.height * 0.8f));
        go.transform.position = point;
        go.transform.localScale = _sizeVector;
        go.layer = 13;  //HUD
        //Destroy(gameObject);
    }
}