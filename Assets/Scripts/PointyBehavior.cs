using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointyBehavior : MonoBehaviour
{
    [Tooltip("The maximum line length, in units")]
    public float maximumLength = 5;

    private Transform _sheep;
    private SheepScript _sheepBehav;

    // Start is called before the first frame update
    void Start()
    {
        _sheep = transform.parent;
        _sheepBehav = _sheep.GetComponent<SheepScript>();
    }

    // "kick" is the difference between where the mouse-pulled point of the line is,
    // and the sheep's origin.
    void Release(Vector3 kick)
    {
        gameObject.SetActive(false);
        // remove any y component of the kick (kick should be flat).
        kick.y = 0;
        // kick is reversed direction (pointing toward mouse): fix it
        kick = -kick;
        // scale kick by maximumDistance: guarantees a magnitude between zero and one.
        kick /= maximumLength;

        _sheepBehav.Kick(kick);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = new Vector3(0, 0, 0);
        // We want to find the point where the ray hits y = 0 (or not 0, but same y as sheep);
        float runOverRiseX = ray.direction.y / ray.direction.x;
        float runOverRiseZ = ray.direction.y / ray.direction.z;
        Vector3 sheepPos = _sheep.transform.position;
        float rise = ray.origin.y - sheepPos.y;
        point.x = ray.origin.x - rise / runOverRiseX;
        point.z = ray.origin.z - rise / runOverRiseZ;
        point.y = sheepPos.y;

        // Okay, we have it! But, we don't want to let the user drag _too_ far away from the sheep.
        // Find the distance between our point and the sheep, and clamp it so we're never too far.
        Vector3 diff = point - sheepPos;
        float magnitude = diff.magnitude;
        if (magnitude > maximumLength)
        {
            diff *= maximumLength / magnitude;
            point = sheepPos + diff;
        }

        // Set up the line renderer's vertices.
        LineRenderer rend = GetComponent<LineRenderer>();
        rend.SetPositions(new Vector3[]{ sheepPos, point });

        if (Input.GetMouseButtonUp(0))
        {
            Release(diff);
        }
    }
}
