using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour
{
    private Transform pointy;

    // Start is called before the first frame update
    void Start()
    {
        pointy = transform.GetChild(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        pointy.gameObject.SetActive(true);
    }
}
