using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickThru : MonoBehaviour
{
    public Text textComponent;
    public float textCycleLength = 3;

    private float cycle = 0;
    private static bool alreadyClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        if (alreadyClicked)
            SheepUtils.NextLevel();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float opacity = Mathf.Abs(Mathf.Cos(cycle * 2 * Mathf.PI / textCycleLength));
        Color color = textComponent.color;
        color.a = opacity;
        textComponent.color = color;
        cycle += Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            alreadyClicked = true;
            SheepUtils.NextLevel();
        }
    }
}
