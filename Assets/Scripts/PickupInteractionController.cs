using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupInteractionController : MonoBehaviour, IInteractable
{
    private float _size = 3f;

    public Item _item;
    private Vector3 _sizeVector;

    public void Start()
    {
        _sizeVector = new Vector3(_size, _size);
    }

    public void Interact()
    {
        GameObject go = new GameObject();
        SpriteRenderer sr = go.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        sr.sprite = _item.collectedSprite;

        //go.transform position = new Vector2(_item.pickedUpIconX, _item.pickedUpIconY);
        Vector2 point = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width * 0.9f, Screen.height * 0.8f));
        go.transform.position = point;
        go.transform.localScale = _sizeVector;
        go.layer = 13;  //HUD
        Destroy(gameObject);
    }
}