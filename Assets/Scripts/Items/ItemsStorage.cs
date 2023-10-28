using System.Collections.Generic;
using System.Linq;
using PickUpItems;
using UnityEditor;
using UnityEngine;
using UsableItems;

namespace Items
{
    [CreateAssetMenu(menuName = "SurvivalIsland/ItemsStorage")]
    public class ItemsStorage : ScriptableObject
    {
        [SerializeField] private List<Item> allItems;

        public Item GetItem(int index)
        {
            if (allItems.Count > index)
                return allItems[index];

            return null;
        }
    }
}