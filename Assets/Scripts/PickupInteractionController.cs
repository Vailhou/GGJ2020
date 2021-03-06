﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractionController : MonoBehaviour, IInteractable
{
    GameManager gameManager;

    [SerializeField]
    private bool destroyItem = false;

    private bool collected = false;

    public Item _item;
    private float _size = 3f;
    private Vector3 _sizeVector;

    public void Start()
    {
        GameObject gameManagerObj = GameObject.FindWithTag("GameManager");
        gameManager = gameManagerObj.GetComponent<GameManager>();

        _sizeVector = new Vector3(_size, _size);
    }

    public void Interact()
    {
        if (collected) return;

        gameManager.Add(_item);
        GetComponent<AudioSource>().Play();

        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        sr.sprite = _item.collectedSprite;

        //go.transform position = new Vector2(_item.pickedUpIconX, _item.pickedUpIconY);
        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.9f, Screen.height * 0.8f));
        go.transform.position = point;
        go.transform.localScale = _sizeVector;
        go.layer = 13;  //HUD

        if (destroyItem) Destroy(gameObject);
        collected = true;
    }
}