using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public Item item; 

    // Start is called before the first frame update
    void Start()
    {
        item.sprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
