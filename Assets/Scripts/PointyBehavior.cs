using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyBehavior : MonoBehaviour
{
    public float maximumDistance = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = new Vector3(0, 0, 0);
        // We want to find the point where the ray hits y = 0 (or not 0, but same y as sheep);
        float runOverRiseX = ray.direction.y / ray.direction.x;
        float runOverRiseZ = ray.direction.y / ray.direction.z;
        Vector3 sheepPos = GameObject.Find("Sheep").transform.position;
        float rise = ray.origin.y - sheepPos.y;
        point.x = ray.origin.x - rise / runOverRiseX;
        point.z = ray.origin.z - rise / runOverRiseZ;
        point.y = sheepPos.y;

        // Okay, we have it! But, we don't want to let the user drag _too_ far away from the sheep.
        // Find the distance between our point and the sheep, and clamp it so we're never too far.
        Vector3 diff = point - sheepPos;
        float magnitude = diff.magnitude;
        if (magnitude > maximumDistance)
        {
            diff *= maximumDistance / magnitude;
            point = sheepPos + diff;
        }

        transform.position = point;
    }
}
