using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetizerInitializer : MonoBehaviour
{
    private MeshFilter tube = null;

    void Awake()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.x);

        tube = GetComponent<MeshFilter>();
    }

    private void Start()
    {
        float lengthradiusratio = transform.lossyScale.y / transform.lossyScale.x;

        Vector2[] uv_copy = tube.mesh.uv;

        for (int i = 0; i < uv_copy.Length; ++i)
        {
            if (uv_copy[i].x < 0.5f)
                uv_copy[i].x = 0.5f - (lengthradiusratio / 6.0f);
            else
                uv_copy[i].x = 0.5f + (lengthradiusratio / 6.0f);
        }

        tube.mesh.uv = uv_copy;
    }
}
