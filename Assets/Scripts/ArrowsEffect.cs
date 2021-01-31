using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsEffect : MonoBehaviour
{
    [SerializeField] private GameObject arrow = null;

    private Coroutine co = null;

    // Start is called before the first frame update
    void Awake()
    {
        if (co == null)
            co = StartCoroutine(GO());
    }

    // Update is called once per frame
    private IEnumerator GO()
    {
        while (true)
        {
            Vector3 range = (transform.right * transform.lossyScale.x) + (transform.forward * transform.lossyScale.z);

            ArrowParticle ap = Instantiate(arrow, transform).GetComponent<ArrowParticle>();

            ap.go(transform.lossyScale);

            yield return new WaitForSeconds(0.08f);
        }
    }
}
