using System;
using System.Collections.Generic;
using UnityEngine;
using UsableItems;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private int maxStackCount;
    [SerializeField] private GameObject mainInventory;
    [SerializeField] private List<InventorySlot> inventorySlots;

    private int selectedSlot = -1;
    private UsableItemBase selectedItem;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if(isNumber && number > 0 && number < 10)
                ChangeSelectedSlot(number - 1);
            
            if(isNumber && number == 0)
                ChangeSelectedSlot(9);
        }
    }

    private void ChangeSelectedSlot(int slotIndex)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[slotIndex].Select();
        selectedSlot = slotIndex;

        var item = GetSelectedItem();
        if (item != null)
        {
            if (selectedItem != null)
            {
                Destroy(selectedItem.gameObject);
                selectedItem = null;
            }

            selectedItem = Instantiate(item.gameItemPrefab, GameReferences.I.GetPlayer.GetItemAttachPoint);
        }
    }

    public bool AddItem(Item item)
    {
        foreach (var slot in inventorySlots)
        {
            if (slot.transform.childCount == 0)
            {
                SpawnNewItem(item, slot);
                return true;
            }

            if ( slot.transform.childCount > 0 && slot.transform.GetChild(0).TryGetComponent(out InventoryItem slotItem))
            {
                if (item.inventoryItemPrefab == slotItem && item.isStackable && slotItem.CurrentItemCount < maxStackCount)
                {
                    slotItem.CurrentItemCount++;
                    slotItem.RefreshCount();

                    return true;
                }
            }
        }

        return false;
    }

    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        InventoryItem newItem = Instantiate(item.inventoryItemPrefab, slot.transform);
        newItem.RefreshCount();
        //newItem.InitializeItem(item);
    }

    public Item GetSelectedItem(bool useItem = false)
    {
        if (selectedSlot < 0)
            return null;

        InventorySlot slot = inventorySlots[selectedSlot];
        if (slot.transform.childCount > 0 && slot.transform.GetChild(0).TryGetComponent(out InventoryItem itemInSlot))
        {
            if (useItem)
            {
                itemInSlot.CurrentItemCount--;
                if (itemInSlot.CurrentItemCount <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefreshCount();
                }
            }

            return itemInSlot.Item;
        }

        return null;
    }

    public void Switch()
    {
        mainInventory.SetActive(!mainInventory.activeSelf);

        Cursor.visible = mainInventory.activeSelf;
        Cursor.lockState = mainInventory.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
    }
}