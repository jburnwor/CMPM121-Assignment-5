using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OpenDoor()
    {
        anim.SetBool("isOpen", true);
    }
}
