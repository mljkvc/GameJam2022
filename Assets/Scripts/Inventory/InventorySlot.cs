using System.Collections;
using System.Collections.Generic;
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
        pic.sprite = item.sprite;
    }
}
