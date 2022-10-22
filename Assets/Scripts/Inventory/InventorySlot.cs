using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public int index;
    private Button btn;


    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => { OnClickAction(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClickAction()
    {

    }
    public void refresh()
     {
        if (index >= Inventory.Instance.itemList.list.Count)
            return;
        item = Inventory.Instance.itemList.list[index];

        Image pic = transform.GetChild(0).GetComponent<Image>();
        TextMeshProUGUI txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        txt.text = item.amount.ToString();
        //TextMeshPro txt = transform.GetChild(1).GetComponent<TextMeshPro>();
        //txt.text = item.amount.ToString();
        pic.sprite = item.sprite;
    }

    public void tidy()
    {
        TextMeshProUGUI txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        txt.text = "";
            //item.amount.ToString();
    }
}
