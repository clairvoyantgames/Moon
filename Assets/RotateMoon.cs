using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMoon : MonoBehaviour
{
    public readonly float speed = 10f;
    public float xRotation = 0f;
    public float yRotation = 0f;
    public bool editing = false;
    private Controller Controller;
    private Vector3 startrot;
    private bool reset;
    private float time;
    private Vector3 currentrot;

    // Start is called before the first frame update
    void Start()
    {
        Controller = FindObjectOfType<Controller>();
        startrot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (editing)
        {
            var xRot = Vector3.up * xRotation * Time.deltaTime;
            var yRot = Vector3.left * yRotation * Time.deltaTime;
            transform.Rotate(xRot + yRot);

            if (Controller.goLeft)
            {
                xRotation = speed;
            }
            else if (Controller.goRight)
            {
                xRotation = -speed;
            }
            else
            {
                xRotation = 0;
            }

            if (Controller.goUp)
            {
                yRotation = -speed;
            }
            else if (Controller.goDown)
            {
                yRotation = speed;
            }
            else
            {
                yRotation = 0;
            }

            if (Controller.action2)
            {
                reset = false;
                time = 1f;
                currentrot = transform.eulerAngles;
                editing = !editing;
            }
        }
        else
        {
            if (!reset)
            {
                time = Mathf.Max(time - Time.deltaTime, 0);
                transform.eulerAngles = Vector3.Lerp(startrot, currentrot, time);

                if (transform.eulerAngles == startrot)
                {
                    reset = true;
                }
            }
            else
            {
                var xRot = Vector3.up * speed * Time.deltaTime;
                transform.Rotate(xRot);
            }

            if (Controller.action2)
            {
                editing = !editing;
            }
        }
    }
}
