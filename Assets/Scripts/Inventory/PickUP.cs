using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PickUP : MonoBehaviour
{



  

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Collectible"))
        {
            ItemObject item = collision.gameObject.GetComponent<ItemObject>();
            Item itemData = item.item;
            //PUSTI ANIMACIJU ANDJELA PLS
            Inventory.Instance.addItem(new Item(itemData.itemType, itemData.amount, itemData.sprite));

            Destroy(collision.gameObject);

        }

    }
}