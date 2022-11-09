using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Inventory inventory;
    public Item item;
    private bool canCollect = false;

    public Animator playerAnimator;

    void Update()
    {
        if(canCollect && Input.GetKeyUp(KeyCode.E) && !playerAnimator.GetBool("IsWalking"))
        {
            inventory.CollectItem(item);
            Destroy(gameObject);
            playerAnimator.SetTrigger("GrabItem");
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
