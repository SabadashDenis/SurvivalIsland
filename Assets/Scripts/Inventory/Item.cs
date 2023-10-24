using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SurvivalIsland/Item")]
[Serializable]
public class Item : ScriptableObject
{
    [Header("Gameplay Only")] public GameObject pickUpPrefab;
    public GameObject gameItemPrefab;

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