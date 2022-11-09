using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Inventory inventory;
    public Item item;
    public AudioSource collectAudio;
    public Animator playerAnimator;

    private bool canCollect = false;

    void Update()
    {
        if(canCollect && Input.GetKeyUp(KeyCode.E) && !playerAnimator.GetBool("IsWalking"))
        {
            inventory.CollectItem(item);
            collectAudio.Play();
            playerAnimator.SetTrigger("GrabItem");
        }

        if(collectAudio.time >= collectAudio.clip.length)
        {
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
