using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBodyBehavior : MonoBehaviour
{
    void OnTriggerEnter()
    {
        transform.GetComponentInParent<CoinBehavior>().Collected();
    }
}
