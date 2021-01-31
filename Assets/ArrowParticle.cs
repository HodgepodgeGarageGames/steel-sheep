using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowParticle : MonoBehaviour
{
    private Coroutine co = null;
    private SpriteRenderer rend = null;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    public void go(Vector3 s)
    {
        if (co == null)
            co = StartCoroutine(GO(s));
    }

    private IEnumerator GO(Vector3 s)
    {
        transform.localPosition = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 5.0f), 0.1f);
        transform.localScale = new Vector3(1.0f / (s.y * 10.0f), 1.0f / (s.x * 10.0f), -0.1f);

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -0.1f - t);

            rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1.0f - (t*t));

            yield return null;
        }

        Destroy(gameObject);
    }
}
