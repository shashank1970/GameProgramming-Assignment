using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] float throwForce = 50;
    [SerializeField] private float pickupAbleDistance = 2f;

    private Vector3 objectPos;
    private float distanceToPlayer;
    private Rigidbody throwableRigidBody;
    private ObjectHolder playerObjectHolder;
    private bool isHolding = false;

    private void Start()
    {
        //will only work if you tag the player game object "Player"
        //and place a child of the player controller where you want held stuff to be and give it a script called "ObjectHolder"
        //ObjectHolder doesn't need any content, its just to identify the right child, so you could also use getchild or some such
        playerObjectHolder = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<ObjectHolder>();
        throwableRigidBody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        DetectInput();

        distanceToPlayer = Vector3.Distance(transform.position, playerObjectHolder.transform.position);

        if (distanceToPlayer >= pickupAbleDistance)
        {
            isHolding = false;
        }

        if (isHolding)
        {
            transform.SetParent(playerObjectHolder.transform);
            transform.localPosition = Vector3.zero;
            throwableRigidBody.velocity = Vector3.zero;
            throwableRigidBody.angularVelocity = Vector3.zero;
            throwableRigidBody.useGravity = false;

            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("clicked to throw");
                isHolding = false;
                throwableRigidBody.AddForce(playerObjectHolder.transform.forward * throwForce, ForceMode.Impulse);
            }
        }
        else
        {
            transform.SetParent(null);
            throwableRigidBody.useGravity = true;
        }
    }

    void DetectInput()
    {
        //this should ideally be generalized and put in player script and called OnPlayerInteract() or some such that
        // detects things close to player, and probably also within a cone of view, not just at some distance from player
        //but for tutorial sake fine to put here so all in one place
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (distanceToPlayer <= pickupAbleDistance)
            {
                isHolding = !isHolding;
                Debug.Log("pressed interact on throwable");
            }
        }
    }





}
