using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Dictionary<string, (Item, int)> _stock;

    public void AddItem(string name, Item item, int amount)
    {
        amount += _stock[name].Item2;
        _stock.Add(name, (item, amount));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class Item
{
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private Sprite image;
    [SerializeField] private GameObject gameObject;
    public int ID { get => id; private set => id = value; }
    public string Name { get => name; private set => name = value; }
    public Sprite Image { get => image; private set => image = value; }
    public GameObject GameObject { get => gameObject; private set => gameObject = value; }

    public Item(int id, string name, Sprite image, GameObject gameObject)
    {
        ID = id;
        Name = name;
        Image = image;
        GameObject = gameObject;
    }
}

/*public class Weapon : Item
{
    public int BaseDMG { get; private set; }

    public Weapon(int id, string name, int baseDmg) : base(id, name)
    {
        BaseDMG = baseDmg;
    }
}*/

