using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public class Item
{

    public enum ItemType
    {
        Potion,
        Axe,
        Gun,
        SpeedPotion
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

    public static ItemType fromName(String s)
    {
        switch (s)
        {
            case "Axe": return ItemType.Axe;
            case "Gun": return ItemType.Gun;
            case "Potion": return ItemType.Potion;
            case "SpeedPotion": return ItemType.SpeedPotion;
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
            case Item.ItemType.SpeedPotion: return "SpeedPotion";
            default: return "";
        }
    }

    public bool IsStackable()
    {
        switch (itemType)
        {
            case ItemType.Potion:
            case Item.ItemType.SpeedPotion:
                return true;
            case ItemType.Axe:
            case ItemType.Gun:
                return false;
            default: return false;
        }
    }

    public void inventoryAction()
    {
        switch (this.itemType)
        {
            case Item.ItemType.Potion: heal();break;
            case Item.ItemType.SpeedPotion:speedUP();break;
        }
    }

    private void heal()
    {
        Player player = Transform.FindObjectOfType<Player>();

        player.health = Math.Min(100, player.health + 25);
    }
    
    private void speedUP()
    {
        Player player = Transform.FindObjectOfType<Player>();
        player.moveForce += 20;
    }
}
