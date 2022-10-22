using System;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Item
{

    public enum ItemType
    {
<<<<<<< Updated upstream
        
=======
        Sword,
        HealthPotion,
        ManaPotion,
        Coin,
        Medkit,
>>>>>>> Stashed changes
        Potion,
        Axe,
        Gun
    }

<<<<<<< Updated upstream
    [SerializeField]
    public ItemType itemType;
    [SerializeField]
    public int amount;
    [SerializeField]
    public Sprite sprite;

    public Item(ItemType type, int amount, Sprite sprite)
    {
        this.itemType = type;
        this.amount = amount;
        this.sprite = sprite;
    }


    /*  public Sprite GetSprite()
      {
          switch (itemType)
          {
              //TODO
          }
      }*/
=======
    public ItemType itemType;
    public int amount;

    public Item(ItemType type, int amount)
    {
        this.itemType = type;
        this.amount = amount;
    }


  /*  public Sprite GetSprite()
    {
        switch (itemType)
        {
            //TODO
        }
    }*/
>>>>>>> Stashed changes
    public static ItemType fromName(String s)
    {
        switch (s)
        {
            case "Axe": return ItemType.Axe;
            case "Gun": return ItemType.Gun;
            case "Potion": return ItemType.Potion;
            default: return ItemType.Potion;
        }
    }
    public static String toString(Item.ItemType type)
    {
        switch (type)
        {
            case Item.ItemType.Potion: return "Potion";
            case Item.ItemType.Axe: return "Axe";
            case Item.ItemType.Gun: return "Gun";
            default: return "";
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
<<<<<<< Updated upstream
            case ItemType.Potion:
                return true;
            case ItemType.Axe:
            case ItemType.Gun:
                return false;
            default: return false;
        }
    }

}
=======
            default:
            case ItemType.Coin:
            case ItemType.HealthPotion:
            case ItemType.ManaPotion:
            case ItemType.Potion:
                return true;
            case ItemType.Sword:
            case ItemType.Medkit:
            case ItemType.Axe:
            case ItemType.Gun:
                return false;
        }
    }

}
>>>>>>> Stashed changes
