using System;
using UnityEngine;

    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject mainInventory;

        public void Switch()
        {
            mainInventory.SetActive(!mainInventory.activeSelf);

            Cursor.visible = mainInventory.activeSelf;
            Cursor.lockState = mainInventory.activeSelf ? CursorLockMode.Confined : CursorLockMode.Locked;
        }
    }
