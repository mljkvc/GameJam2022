using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

<<<<<<< Updated upstream
public class Inventory : MonoBehaviour
{
    //public event EventHandler OnItemListChanged;

    [SerializeField]
    public ItemList itemList;
    public Inventory_UI inventoryUI;

    private static Inventory _instance;

    public static Inventory Instance { get { return _instance; } }


    private void Awake()
    {
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
=======
public class Inventory
{
   public struct Pair
    {
       public Item item;
       public int amount;
    }



    //public event EventHandler OnItemListChanged;

    public static List<Item> itemList;
    private Action<Item> useItemAction;
    public static Pair[] content = new Pair[10];
    public static int currInd = 0;
    

    

    public static void addItem(Item item)
    {
        if (item.IsStackable())
        {
            int index = -1;
            for (int i = 0; i < currInd; i++)
                if (content[i].item.itemType == item.itemType) index = i;
            if (index != -1)
                content[index].amount = content[index].amount+1;
            if (currInd <= 9)
            {
                content[currInd].item = item;
                content[currInd].amount = 1;
                currInd++;
            }
        }
        if (currInd <= 9)
        {
            content[currInd].item = item;
            content[currInd].amount = 1;
            currInd++;
        }
        String s = "";
        for (int i = 0; i < currInd; i++)
          s+=  Item.toString(content[i].item.itemType) + " " + content[i].amount+" ";
        Debug.Log("IMA: "+s + "  BR elemenata: " + currInd);

    }

    /* NE TREBA JOS UVEK
     public static void removeItem(Item item)
    {
        content.Remove(item);
    }*/

  /*  public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Remove(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }*/

    /*public void UseItem(Item item)
    {
        useItemAction(item);
    }*/



}
>>>>>>> Stashed changes
