using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point = Camera.main.transform.TransformVector(Input.mousePosition);
        point.z = point.y;
        point.y = 0;
        transform.position = point;
    }
}
