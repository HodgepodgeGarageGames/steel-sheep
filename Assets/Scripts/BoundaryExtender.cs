using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryExtender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] bounds = GameObject.FindGameObjectsWithTag("Boundary");
        foreach (GameObject b in bounds)
        {
            BoxCollider collide = b.GetComponent<BoxCollider>();
            if (collide != null)
            {
                Vector3 newSize = collide.size;
                newSize.y = 200;
                collide.size = newSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}