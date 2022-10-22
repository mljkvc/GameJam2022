using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Item
{

    public enum ItemType
    {
        
        Potion,
        Axe,
        Gun
    }

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
            case ItemType.Potion:
                return true;
            case ItemType.Axe:
            case ItemType.Gun:
                return false;
            default: return false;
        }
    }

}