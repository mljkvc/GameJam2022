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


    // Start is called before the first frame update


    void Start()
    {
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
        
        Debug.Log("POZVANO");
        switch (this.item.itemType)
        {
            case Item.ItemType.Potion: heal(); break;
        }
        Debug.Log("POZVANO");
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
    private void heal()
    {
        Player player = Transform.FindObjectOfType<Player>();

        player.health = Math.Min(100, player.health + 25);
    }




    private int whatKey(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.Alpha1: return 1;
            case KeyCode.Alpha2: return 2;
            case KeyCode.Alpha3: return 3;
            case KeyCode.Alpha4: return 4;
            case KeyCode.Alpha5: return 5;
            case KeyCode.Alpha6: return 6;
            case KeyCode.Alpha7: return 7;
            case KeyCode.Alpha8: return 8;
            case KeyCode.Alpha9: return 9;

        }


        return -1;
    }


}
