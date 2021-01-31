using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBodyBehavior : MonoBehaviour
{
    // This is the trigger for the ACTUAL coin shape. See CoinBehavior for the magnetic "influence" sphere
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<AudioSource>().Play();
            transform.GetComponentInParent<CoinBehavior>().Collected();
        }
    }
}
