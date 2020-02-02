using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<Item> _items = new List<Item>();

    private static GameManager s_Instance = null;

    void Awake()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);

            //Initialization code goes here[/INDENT]
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public void Remove(string itemName)
    {
        foreach (var item in _items)
        {
            if (item.name.Equals(itemName)) _items.Remove(item);
        }
    }

    public bool checkIfContains(string name)
    {
        foreach (var item in _items)
        {
            if (item.name.Equals(name)) return true;
        }
        return false;
    }
}
