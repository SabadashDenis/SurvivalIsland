using System;
using GameModel;
using Items;
using UnityEngine;

namespace PickUpItems
{
    public class PickUpItem : MonoBehaviour
    {
        public Item Item;
        public Rigidbody rb;
        
        private PlayerInstance nearbyPlayer;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(nearbyPlayer != null)
                    TryPickUp(nearbyPlayer);
            }
        }

        private void TryPickUp(PlayerInstance player)
        {
            if (player.GetInventoryManager.AddItem(Item))
                Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInstance player))
            {
                nearbyPlayer = player;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerInstance player))
            {
                nearbyPlayer = null;
            }
        }
    }
}