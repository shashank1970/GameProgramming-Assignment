using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{

    public SpherePlace object2;
    
    public GameObject door;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if ( object2.objectPlaced )
        {
            Animator anim = door.GetComponent<Animator>();

            anim.SetTrigger("Open");

        }

    }

 

  





}
