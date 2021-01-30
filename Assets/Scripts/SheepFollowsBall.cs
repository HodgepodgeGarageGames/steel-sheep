using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepFollowsBall : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float hpower = 100.0f;
    public float vpower = 10.0f;
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

        rb.velocity = new Vector3(
            ((ball.position.x + offset.x) - rb.position.x) * hpower,
            (rb.position.y < ball.position.y + offset.y) ? ((ball.position.y + offset.y) - rb.position.y) * vpower : rb.velocity.y,
            ((ball.position.z + offset.z) - rb.position.z) * hpower);
        rb.angularVelocity = ball.angularVelocity;
    }
}
