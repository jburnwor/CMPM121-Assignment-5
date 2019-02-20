using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && GameManager.keyCollected)
        {
            Debug.Log("player");
            anim.SetBool("isOpen", true);
        }
    }
}
