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

        // Avoid physics collision with coins
        Physics.IgnoreLayerCollision(LayerMask.NameToLayer("sheepball"), LayerMask.NameToLayer("Coin"));
    }

    // Update is called once per frame
    void Update()
    {
        // Detect mouse down on/near sheep (including through obstructions)
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Collider myCollider = GetComponent<SphereCollider>();
            
            foreach (RaycastHit hit in Physics.RaycastAll(ray))
            {
                if (hit.collider == myCollider)
                {
                    pointy.gameObject.SetActive(true);
                }
            }
        }
        
    }

    public void Kick(Vector3 kick)
    {
        GetComponent<Rigidbody>().velocity = kick * kickStrength;
    }

    public void StartHopping()
    {

    }
}
