using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class SheepUtils
{
    public static Transform theSheepProxy
    {
        get
        {
            GameObject[] rootObjs = SceneManager.GetActiveScene().GetRootGameObjects();
            foreach (GameObject obj in rootObjs)
            {
                if (obj.CompareTag("Player"))
                {
                    return obj.transform.GetChild(1);
                }
            }

            return null;
        }
    }
}
