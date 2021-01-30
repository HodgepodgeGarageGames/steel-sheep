using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour
{
    [Tooltip("The velocity, in units/sec, from a kick of magnitude one")]
    public float kickStrength = 5;
    
    private Transform pointy;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        pointy = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kick(Vector3 kick)
    {
        GetComponent<Rigidbody>().velocity = kick * kickStrength;
    }

    void OnMouseDown()
    {
        pointy.gameObject.SetActive(true);
    }
}
