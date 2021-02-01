using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using static SheepUtils;

public class Bumper : MonoBehaviour
{
    public Transform bumperBlocker;
    public VideoPlayer video;

    [Tooltip("How many seconds to take fading in/out")]
    public float fadeTime = 2;
    [Tooltip("How long to display the bumper before fading back out")]
    public float displayTime = 3;

    private Material material;
    private bool mouseButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        material = bumperBlocker.GetComponent<MeshRenderer>().material;

        StartCoroutine("FadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        // GetMouseButtonDown is only reliable within Update message
        mouseButtonDown = Input.GetMouseButtonDown(0);
    }

    void SetOpacity(float opacity)
    {
        Color color = material.color;
        color.a = opacity;
        material.color = color;
        bumperBlocker.GetComponent<MeshRenderer>().material = material;
    }

    IEnumerator FadeIn()
    {
        float opacity = 1;
        float opacityDelta = -1 / (fadeTime / Time.fixedDeltaTime);
        float countDown = fadeTime;

        Debug.Log("FadeIn");
        while (countDown > 0)
        {
            SetOpacity(opacity);
            yield return new WaitForFixedUpdate();
            countDown -= Time.fixedDeltaTime;
            opacity += opacityDelta;
        }
        SetOpacity(opacity);
        Debug.Log("Display");
        yield return new WaitForSeconds(displayTime);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        float opacity = 0;
        float opacityDelta = 1 / (fadeTime / Time.fixedDeltaTime);
        float countDown = fadeTime;

        Debug.Log("FadeOut");
        while (countDown > 0)
        {
            SetOpacity(opacity);
            yield return new WaitForFixedUpdate();
            countDown -= Time.fixedDeltaTime;
            opacity += opacityDelta;
        }
        SetOpacity(opacity);

        StartCoroutine("PlayMovie");
    }

    IEnumerator PlayMovie()
    {
        Debug.Log("PlayMovie");
        video.url = Path.Combine(Application.streamingAssetsPath, "Sheep_Intro_fin.mp4");
        video.Prepare();
        video.Play();

        float waitForVideoPlay = 2;
        while (!video.isPlaying && waitForVideoPlay > 0)
        {
            yield return new WaitForFixedUpdate();
            waitForVideoPlay -= Time.fixedDeltaTime;
        }

        while (video.isPlaying)
        {
            if (mouseButtonDown)
                break;
            yield return new WaitForFixedUpdate();

        }

        SheepUtils.NextLevel();
    }
}
