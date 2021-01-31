using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SheepUtils;

public class WinAreaBehavior : MonoBehaviour
{
    [Tooltip("How long to wait (sheep a-hopping) before loading next level")]
    public float nextLevelWait = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            theSheepProxy.GetComponent<SheepScript>().StartHopping();
            StartCoroutine("DelayedNextScene");
        }
    }

    void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator DelayedNextScene()
    {
        yield return new WaitForSeconds(nextLevelWait);
        PlayNextScene();
    }
}
