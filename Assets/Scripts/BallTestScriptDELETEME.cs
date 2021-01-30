using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTestScriptDELETEME : MonoBehaviour
{
    [SerializeField] private Camera cam = null;
    private Rigidbody rb = null;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            rb.AddForce(new Vector3(cam.transform.right.normalized.x, 0.0f, cam.transform.right.normalized.z) * 10.0f);
    }
}
