using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] private MeshRenderer leaves = null;

    private void Awake()
    {
        

        if (Random.Range(0, 2) == 0)
        {
            leaves.material.color = Color.Lerp(Color.red, Color.green, Random.Range(0.0f, 1.0f));
        }
        else
        {
            leaves.material.color = Color.Lerp(Color.green, Color.cyan, Random.Range(0.0f, 1.0f));
        }

    }
}
