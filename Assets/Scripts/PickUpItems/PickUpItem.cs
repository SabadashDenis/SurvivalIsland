using System;
using GameModel;
using Items;
using UnityEngine;

namespace PickUpItems
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private int storageIndex = -1;
        public Item GetItem => GameReferences.I.GetReferences.GetItemsStorage.GetItem(storageIndex);
        

        public void TryPickUp(PlayerInstance player)
        {
            if (player.GetInventoryManager.AddItem(GetItem))
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInstance player))
            {
                if (player.GetInventoryManager.AddItem(GetItem))
                    Destroy(gameObject);
            }
        }
    }
}