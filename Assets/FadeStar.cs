using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeStar : MonoBehaviour
{
    public string state = "idle";
    public bool editing = false;
    private float toColor;
    private float fromColor;
    private GameObject sky;
    private GameObject star;
    private Controller Controller;
    private GameObject starmesh;
    public float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        Controller = FindObjectOfType<Controller>();

        starmesh = GameObject.Find("starmesh");
        fromColor = 0f;
        toColor = 1f;

        sky = GameObject.Find("sky origin");
    }

    // Update is called once per frame
    void Update()
    {
        time = Mathf.Max(time - Time.deltaTime, 0);
        float alpha;
        if (editing)
        {
            alpha = Mathf.Lerp(toColor, fromColor, time);
        }
        else
        {
            alpha = Mathf.Lerp(fromColor, toColor, time);
        }
        var currentColor = starmesh.GetComponent<MeshRenderer>().material.color;
        currentColor.a = alpha;
        starmesh.GetComponent<MeshRenderer>().material.color = currentColor;


        if (Controller.action2)
        {
            time = 0.5f;

            editing = !editing;
        }
    }
}
