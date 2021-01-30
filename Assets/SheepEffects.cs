using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepEffects : MonoBehaviour
{
    public float electric_radius = 0.015f;
    public float spark_lifetime = 0.3f;
    public float spark_scale = 0.01f;
    public float spark_shaky_degrees = 2.0f;
    public float spark_frequency = 20.0f;

    [SerializeField] private GameObject[] spark_prefabs = new GameObject[0];
    [SerializeField] private SkinnedMeshRenderer sheep_body = null;

    private Coroutine sparker = null;

    public void TurnOnElectricity()
    {
        TurnOffElectricity();

        sheep_body.material.SetFloat("_Metallic", 0.7f);
        sheep_body.material.SetColor("_EmissionColor", new Color(0.1f, 0.1f, 0.1f));

        sparker = StartCoroutine(SPARK());
    }

    public void TurnOffElectricity()
    {
        sheep_body.material.SetFloat("_Metallic", 0.1f);
        sheep_body.material.SetColor("_EmissionColor", new Color(0.42f, 0.42f, 0.42f));

        if (sparker != null)
            StopCoroutine(sparker);

        sparker = null;
    }

    private IEnumerator SPARK()
    {
        while (true)
        {
            sparklet spark = Instantiate(spark_prefabs[Random.Range(0, spark_prefabs.Length)], transform).GetComponent<sparklet>();

            spark.go(electric_radius, spark_lifetime, spark_scale, spark_shaky_degrees);

            yield return new WaitForSeconds(1/spark_frequency);
        }
    }
}
