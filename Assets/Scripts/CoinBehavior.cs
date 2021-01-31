using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public Transform coinBody;
    [Tooltip("rotation speed in degrees per second")]
    public float rotationSpeed = 45;
    [Tooltip("how quickly the coin moves toward a magnetized sheep")]
    public float magnetSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float rotationAmount = rotationSpeed * Time.fixedDeltaTime;
        coinBody.Rotate(new Vector3(rotationAmount, 0, 0));
    }

    public void Collected()
    {
        gameObject.SetActive(false);
    }
}
