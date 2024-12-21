using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotebookManager : MonoBehaviour
{
    public GameObject Codex;
    private bool codexActivated;
    //public ItemSlot[] itemSlot;
    //public ItemSO[] itemSOs;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && codexActivated)
        {
            Time.timeScale = 1;
            Codex.SetActive(false);
            codexActivated = false;
        }

        else if (Input.GetKeyDown(KeyCode.C) && !codexActivated)
        {
            Time.timeScale = 0;
            Codex.SetActive(true);
            codexActivated = true;
        }
    }

/*
    public void UseItem(string itemName)
    {
        for (int i = 0; i < itemSOs.Length; i++)
        {
            if (itemSOs[i].itemName == itemName)
            {
                itemSOs[i].UseItem();
            }
        }
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                    
                return leftOverItems;
            }
            
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    
*/
}
