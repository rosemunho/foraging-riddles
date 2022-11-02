using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Inventory inventory;
    public InventoryItem item;
    private bool canCollect = false;

    void Update()
    {
        if(canCollect && Input.GetMouseButtonUp(0))
        {
            inventory.AddItem(item);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canCollect = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canCollect = false;
    }
}
