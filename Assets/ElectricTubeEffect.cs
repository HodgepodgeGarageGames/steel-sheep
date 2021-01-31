using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTubeEffect : MonoBehaviour
{
    public float spark_lifetime = 0.3f;
    public float spark_scale = 0.01f;
    public float spark_shaky_degrees = 2.0f;
    public float spark_frequency = 20.0f;

    [SerializeField] private GameObject[] spark_prefabs = new GameObject[0];

    private Coroutine sparker = null;

    // Start is called before the first frame update
    void Start()
    {
        if (sparker == null)
            sparker = StartCoroutine(SPARK());
    }

    private IEnumerator SPARK()
    {
        while (true)
        {
            sparklet spark = Instantiate(spark_prefabs[Random.Range(0, spark_prefabs.Length)]).GetComponent<sparklet>();

            spark.transform.position = transform.position;

            Vector3 rand_vec = Vector3.Scale(new Vector3(
                Random.Range(-1.0f, 1.0f),
                Random.Range(-1.0f, 1.0f),
                0.0f).normalized, transform.parent.lossyScale);

            spark.transform.position += transform.right * rand_vec.x;
            spark.transform.position += transform.forward * rand_vec.y;

            spark.transform.LookAt(transform);

            spark.transform.position += transform.up * (Random.Range(-1.0f, 1.0f) * transform.parent.lossyScale.z);

            Debug.Log(transform.up);

            /*spark.transform.localPosition += new Vector3(
                0.0f,
                Random.Range(-1.0f, 1.0f) * transform.lossyScale.y,
                0.0f);*/

            spark.go(spark_lifetime, spark_scale, spark_shaky_degrees);

            yield return new WaitForSeconds(1 / spark_frequency);
        }
    }
}
