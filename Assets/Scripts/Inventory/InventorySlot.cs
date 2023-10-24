using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Image img;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color notSelectedColor;

    private void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        img.color = selectedColor;
    }

    public void Deselect()
    {
        img.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount != 0)
            return;
        
        GameObject dropped = eventData.pointerDrag;
        if(dropped.TryGetComponent(out InventoryItem item))
            item.SetParent(transform);
    }
}
