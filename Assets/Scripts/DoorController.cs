using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour, IInteractable
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
    private string nextMapName = "EndScreen";

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
        audioSource.PlayOneShot(_unlockSound, audioVol);
        SceneManager.LoadScene(nextMapName);
    }
}