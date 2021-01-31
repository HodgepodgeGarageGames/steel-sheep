using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour
{
    [Tooltip("The velocity, in units/sec, from a kick of magnitude one")]
    public float kickStrength = 5;

    [Header("Hopping (at level win)")]
    [Tooltip("How many seconds to wait between sheep hops")]
    public float hopWait = 2;
    [Tooltip("Maximum vertical sheep velocity magnitude to allow a hop (should be low, indicating sheep is at ground)")]
    public float hopRestMagnitude = 0.01f;
    [Tooltip("Upward hop thrust")]
    public float hopStrength = 8;
    
    private Transform pointy;

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
        //Debug.Log("StartHopping");
        StartCoroutine("DoHop");
    }

    public void Hop()
    {
        //Debug.Log("Hop");
        Rigidbody body = GetComponent<Rigidbody>();

        if (Mathf.Abs(body.velocity.y) < hopRestMagnitude)
        {
            //Debug.Log("HopYes");
            Vector3 newVeloc = body.velocity;
            newVeloc.y = hopStrength;
            body.velocity = newVeloc;
        }
    }

    IEnumerator DoHop()
    {
        for (;;) // ever
        {
            yield return new WaitForSeconds(hopWait);
            Hop();
        }
    }
}
