using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite topDownSprite;
    public Sprite collectedSprite;

    public int pickedUpIconX = 30;
    public int pickedUpIconY = 20;
}
