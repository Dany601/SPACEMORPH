using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    private bool InventoryEnabled;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;
    public GameObject slotHolder;
    
    // Start is called before the first frame update
    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;


            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empy = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.I))
        {
            InventoryEnabled = !InventoryEnabled;
        }

        if(InventoryEnabled == true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false); 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item") 
        {
            GameObject itemPicketUp = other.gameObject;

            Item item = itemPicketUp.GetComponent<Item>();

            AddItem(itemPicketUp, item.ID, item.type, item.descripcion,item.icon);
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType , string itemDescripcion, Sprite itemIcon) 
    {
        for (int i = 0; i < allSlots;) 
        {
            if (slot[i].GetComponent<Slot>().empy)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().ID = itemID;
                slot[i].GetComponent<Slot>().type = itemType;
                slot[i].GetComponent<Slot>().description = itemDescripcion;
                slot[i].GetComponent<Slot>().icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();

                slot[i].GetComponent<Slot>().empy = false;
            }
            return;
        }
    }
}
