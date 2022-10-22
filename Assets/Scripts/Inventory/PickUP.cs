using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PickUP : MonoBehaviour
{



<<<<<<< Updated upstream
  

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
=======
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Collectible")
        {
            
            Item.ItemType type = Item.fromName(collision.gameObject.name);
            //PUSTI ANIMACIJU ANDJELA PLS
            Destroy(collision.gameObject);
            Inventory.addItem(new Item(type, 1));

            //Debug.Log(Inventory.content);


        }
            
    }
}
>>>>>>> Stashed changes
