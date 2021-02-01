using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject prefab;
    private static bool instantiated = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!instantiated)
        {
            instantiated = true;
            Object instance = Instantiate(prefab);
            Object.DontDestroyOnLoad(instance);
        }
    }
}
