using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetosphereBehavior : MonoBehaviour
{
    CoinBehavior _parentParams;
    Vector3 _coinOffsetFromOrigin;

    // Start is called before the first frame update
    void Start()
    {
        _parentParams = GetComponentInParent<CoinBehavior>();
        // Get the vertical thrust offset to remove, from the coin body cylinder's offset relative to the parent.
        _coinOffsetFromOrigin = transform.parent.GetComponentInChildren<CoinBodyBehavior>().transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // magnetic trigger, not coin-collect trigger
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // We don't accelerate the coin toward the sheep,
            // we steadily move it. So that's a velocity adjustment, not force.
            Rigidbody coinRigidBody = GetComponentInParent<Rigidbody>();
            Vector3 move = other.transform.position - coinRigidBody.transform.position - _coinOffsetFromOrigin;
            move = move * (_parentParams.magnetSpeed / move.magnitude);
            coinRigidBody.velocity = move;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // We don't accelerate the coin toward the sheep,
            // we steadily move it. So that's a velocity adjustment, not force.
            Rigidbody coinRigidBody = GetComponentInParent<Rigidbody>();
            coinRigidBody.velocity = new Vector3(0, 0, 0);
        }
    }
}
