using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Text itemCountText;
    private int currentItemCount = 1;
    private Transform parentAfterDrag;
    private Item item; 

    public void SetParent(Transform newParent) => parentAfterDrag = newParent;
    public int CurrentItemCount
    {
        get => currentItemCount;
        set => currentItemCount = value;
    }

    public Item GetCurrentItem => item;
    public void InitializeItem(Item newItem)
    {
        image.sprite = item.image;
        RefreshCount();
    }

    public void RefreshCount()
    {
        itemCountText.text = currentItemCount.ToString();
        itemCountText.gameObject.SetActive(currentItemCount > 1);
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}