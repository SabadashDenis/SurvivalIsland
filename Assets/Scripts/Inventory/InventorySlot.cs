using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount != 0)
            return;
        
        GameObject dropped = eventData.pointerDrag;
        if(dropped.TryGetComponent(out DraggableItem item))
            item.SetParent(transform);
    }
}
