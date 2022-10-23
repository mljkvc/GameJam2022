using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Item item;
    public int index;
    private Button btn;
    private Sprite img;


    // Start is called before the first frame update


    void Start()
    {
        img = transform.GetChild(0).GetComponent<Image>().sprite;
        btn = GetComponent<Button>();
        btn.onClick.AddListener(() => {
            Debug.Log("STISNUTO");
            OnClickAction(); });   
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnClickAction()
    {
        
        switch (this.item.itemType)
        {
            case Item.ItemType.Potion: heal(); break;
            case Item.ItemType.SpeedPotion: speedUP();break;
        }
    }
    public void refresh()
     {
        if (index >= Inventory.Instance.itemList.list.Count)
            return;
        item = Inventory.Instance.itemList.list[index];

        Image pic = transform.GetChild(0).GetComponent<Image>();
        TextMeshProUGUI txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        if (item.amount > 0)
        {
            txt.text = item.amount.ToString();
            pic.sprite = item.sprite;
        }
        else
        {
            txt.text = "";
            pic.sprite = img;
        }
    }

    public void tidy()
    {
        TextMeshProUGUI txt = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        txt.text = "";
            //item.amount.ToString();
    }
    private void heal()
    {
        Player player = Transform.FindObjectOfType<Player>();
        //Debug.Log(player.gameObject.name);
        if (item.amount > 0 && player.health!=100)
        {
            player.health = Math.Min(100, player.health + 25);
            item.amount--;
        }
        else if(item.amount<=0) this.zeroed();
        this.refresh();
        Debug.Log(player.health);
    }

    private void speedUP()
    {
        Debug.Log("BRZOBRZO");
        Player player = Transform.FindObjectOfType<Player>();

        if (item.amount > 0)
        {
            player.moveForce += 20;
            item.amount--;
        }
        else if (item.amount <= 0) this.zeroed();
        
        this.refresh();
        Debug.Log(player.health);
    }

    private void zeroed()
    {
        int i = Inventory.Instance.itemList.list.Count - 1;
        Inventory.Instance.itemList.list.RemoveAt(i);
    }

    





}
