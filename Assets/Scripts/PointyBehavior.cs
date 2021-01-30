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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = new Vector3(0, 0, 0);
        // We want to find the point where the ray hits y = 0;
        float runOverRiseX = ray.direction.y / ray.direction.x;
        float runOverRiseZ = ray.direction.y / ray.direction.z;
        point.x = ray.origin.x - ray.origin.y / runOverRiseX;
        point.z = ray.origin.z - ray.origin.y / runOverRiseZ;
        transform.position = point;
    }
}
