using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryExtender : MonoBehaviour
{
    [Tooltip("How far to stretch boundary boxes in the vertical dimension")]
    public float multiplier = 200;
    [Tooltip("What color to set all boundary items to (for debugging)")]
    public Color color = new Color(0.5f, 1f, 0.5f);
    public bool setColor = true;

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

            if (setColor)
            {
                Renderer rend = b.GetComponent<Renderer>();
                rend.material.color = color;
            }
        }
    }
}