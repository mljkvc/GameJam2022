using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;


public class Inventory : MonoBehaviour
{

    [SerializeField]
    public ItemList itemList;
    public Inventory_UI inventoryUI;

    private static Inventory _instance;

    public static Inventory Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(this);
        itemList = new ItemList();

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }


    public void addItem(Item item)
    {
        for (int i = 0; i < itemList.list.Count; i++) {
            if (itemList.list[i].itemType == item.itemType)
            {
                if (item.IsStackable())
                {
                    itemList.list[i].amount++;
                    Inventory_UI.Instance.refreshUI();
                    return;
                }
            }
        }

        if(itemList.list.Count < 9)
        {
            itemList.list.Add(item);
            Inventory_UI.Instance.refreshUI();
        }

         
    }
}


