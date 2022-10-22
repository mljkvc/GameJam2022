using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemList
{
    [SerializeField]
    public List<Item> list;

    public ItemList()
    {
        list = new List<Item>();
    }

    public ItemList(List<Item> list)
    {
        this.list = list;
    }
}
