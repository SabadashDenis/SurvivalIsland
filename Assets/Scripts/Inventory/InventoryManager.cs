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
        // select item
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 10)
                ChangeSelectedSlot(number - 1);

            if (isNumber && number == 0)
                ChangeSelectedSlot(9);
        }

        // drop item
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GetSelectedItem(true);
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

        SpawnGameItem();
    }

    private void SpawnGameItem()
    {
        var item = GetSelectedItem();

        if (selectedItem != null)
        {
            Destroy(selectedItem.gameObject);
            selectedItem = null;
        }

        if (item != null)
        {
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

            if (slot.transform.childCount > 0 && slot.transform.GetChild(0).TryGetComponent(out InventoryItem slotItem))
            {
                if (item.inventoryItemPrefab == slotItem && item.isStackable &&
                    slotItem.CurrentItemCount < maxStackCount)
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
        SpawnGameItem();
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
                    
                    var player = GameReferences.I.GetPlayer;
                    if (player.GetItemAttachPoint.childCount > 0)
                    {
                        Destroy(player.GetItemAttachPoint.GetChild(0).gameObject);
                        Instantiate(itemInSlot.Item.pickUpPrefab, player.GetItemAttachPoint.position, Quaternion.identity);
                    }
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