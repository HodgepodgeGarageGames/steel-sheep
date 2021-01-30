using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepFollowsBall : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float power = 100.0f;
    [SerializeField] private Rigidbody ball = null;
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rb.MovePosition(ball.position + (Vector3.up * vertical_offset));

        rb.velocity = new Vector3((ball.position.x - (rb.position.x - offset.x)) * power, rb.velocity.y, (ball.position.z - (rb.position.z - offset.z)) * power);
        rb.angularVelocity = ball.angularVelocity;
    }
}
