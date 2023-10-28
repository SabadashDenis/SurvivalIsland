using System;
using PickUpItems;
using UnityEngine;
using UsableItems;

[CreateAssetMenu(menuName = "SurvivalIsland/Item")]
[Serializable]
public class Item : ScriptableObject
{
    [Header("Gameplay Only")] 
    public PickUpItem pickUpPrefab;
    public InventoryItem inventoryItemPrefab;
    public UsableItemBase gameItemPrefab;

    [Header("UI Only")]
    public Sprite image;
    public bool isStackable;
}

public enum ItemType
{
}

public enum ActionType
{
}