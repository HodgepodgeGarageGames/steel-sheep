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

    // Summary:
    //  Load the next level (by build index from build settings).
    public static void NextLevel()
    {
        int curIndex, newIndex;
        curIndex = SceneManager.GetActiveScene().buildIndex;
        newIndex = curIndex + 1;

        if (newIndex >= SceneManager.sceneCountInBuildSettings)
            newIndex = 0;

        SceneManager.LoadScene(newIndex);
    }
}
