using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBodyBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.GetComponentInParent<CoinBehavior>().Collected();
        }
    }
}
