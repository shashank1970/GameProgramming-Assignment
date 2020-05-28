using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlace : MonoBehaviour
{
    public bool objectPlaced = false;
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Object")
        {
            objectPlaced = true;

            // Animator anim = other.GetComponentInChildren<Animator>();
            //anim.SetTrigger("OpenClose");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectPlaced = false;
    }

}
