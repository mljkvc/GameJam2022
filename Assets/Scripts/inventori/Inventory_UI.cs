using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventori;

    private void Start()
    {
        inventori.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            otvoriInventori();
        }
    }

    public void otvoriInventori()
    {
        if (!inventori.activeSelf)
        {
            inventori.SetActive(true);
        }
        else
        {
            inventori.SetActive(false);
        }
    }

}
