using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparklet : MonoBehaviour
{
    Coroutine co = null;

    public void go(float lifetime, float scale, float shaky)
    {
        if (co == null)
            co = StartCoroutine(GO(lifetime, scale, shaky));
    }

    private IEnumerator GO(float lifetime, float scale, float shaky)
    {
        transform.localScale = new Vector3(scale, scale, 1.0f);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, Random.Range(-180.0f, 180.0f));

        for (float t = 0.0f; t < lifetime; t += Time.deltaTime)
        {
            //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + Random.Range(-shaky, shaky));

            yield return null;
        }

        Destroy(gameObject);
    }
}
