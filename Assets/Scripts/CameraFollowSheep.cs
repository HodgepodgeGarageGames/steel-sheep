using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SheepUtils;

public class CameraFollowSheep : MonoBehaviour
{
    [Tooltip("object to follow (horizontally only)")]
    public Transform target;

    private Vector3 difference; // the difference to maintain relative to target.
    
    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {
            // We weren't assigned a sheep. Try and find one among the root objects.
            target = theSheepProxy;
        }

        // not an else, because situation may have been changed above
        if (target != null)
        {
            difference = transform.position - target.position;
            difference.y = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x = target.position.x + difference.x;
        newPos.z = target.position.z + difference.z;
        transform.SetPositionAndRotation(newPos, transform.rotation);
    }

    public void Won()
    {
        Transform won = transform.Find("You Won");
        won.gameObject.SetActive(true);
    }
}
