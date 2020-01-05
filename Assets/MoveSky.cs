using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSky : MonoBehaviour
{
    public float xSpeed = 0f;
    public float ySpeed = 0f;
    public float speed = 0.4f;
    private Controller Controller;
    private Vector3 startpos;
    private Vector3 startrot;
    private bool reset = false;
    public bool editing = false;
    private float time;
    private Vector3 currentPos;
    private Vector3 currentrot;

    // Start is called before the first frame update
    void Start()
    {
        Controller = FindObjectOfType<Controller>();

        startpos = transform.position;
        startrot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (editing)
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
                var x = Time.deltaTime * xSpeed;
                var y = Time.deltaTime * ySpeed;
                var position = transform.position;
                position.x += x;
                position.y += y;
                transform.position = position;

                if (Controller.goLeft)
                {
                    xSpeed = speed;
                }
                else if (Controller.goRight)
                {
                    xSpeed = -speed;
                }
                else
                {
                    xSpeed = 0;
                }

                if (Controller.goUp)
                {
                    ySpeed = -speed;
                }
                else if (Controller.goDown)
                {
                    ySpeed = speed;
                }
                else
                {
                    ySpeed = 0;
                }

                if (Controller.action2)
                {
                    reset = false;
                    time = 1f;
                    currentPos = transform.position;
                    editing = !editing;
                }
            }
        }
        else
        {
            if (!reset)
            {
                time = Mathf.Max(time - Time.deltaTime, 0);
                transform.position = Vector3.Lerp(startpos, currentPos, time);

                if (transform.position == startpos)
                {
                    reset = true;
                }
            }
            else
            {
                transform.Rotate(0, 0, 5 * Time.deltaTime);
            }

            if (Controller.action2)
            {
                reset = false;
                time = 1f;
                currentrot = transform.eulerAngles;
                editing = !editing;
            }
        }
    }
}
