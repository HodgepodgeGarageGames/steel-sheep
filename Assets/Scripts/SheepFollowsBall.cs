using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepFollowsBall : MonoBehaviour
{
    public Vector3 offset = Vector3.zero;
    public float hpower = 100.0f;
    public float vpower = 10.0f;
    [SerializeField] private Rigidbody ball = null;
    [SerializeField] private Rigidbody[] all_bones = new Rigidbody[0];
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Teleport to ball if too far away
        Vector3 d = ball.position - rb.position;

        if (d.magnitude > 2.0f)
        {
            rb.position += d;
            rb.velocity = ball.velocity;

            foreach (Rigidbody bone in all_bones)
            {
                bone.position += d;
                rb.velocity = ball.velocity;
            }
        }

        //Inch toward ball
        rb.velocity = new Vector3(
            ((ball.position.x + offset.x) - rb.position.x) * hpower,
            (rb.position.y < ball.position.y + offset.y) ? ((ball.position.y + offset.y) - rb.position.y) * vpower : rb.velocity.y,
            ((ball.position.z + offset.z) - rb.position.z) * hpower);
        rb.angularVelocity = ball.angularVelocity;
    }
}
