using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject inventori;
    public InventorySlot[] inventorySlots;

    private static Inventory_UI _instance;

    public static Inventory_UI Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }


    private void Start()
    {
        foreach (InventorySlot slot in inventorySlots)
            slot.tidy();
        inventori.SetActive(false);
        inventorySlots= inventori.transform.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            otvoriInventori();
            refreshUI();
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

    public void refreshUI()
    {
        foreach(InventorySlot slot in inventorySlots)
        {
            slot.refresh();
        }
    }

    

}
