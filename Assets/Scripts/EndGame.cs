using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public float waitTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitThenEnd");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitThenEnd()
    {
        yield return new WaitForSeconds(waitTime);
        SheepUtils.NextLevel();
    }
}
