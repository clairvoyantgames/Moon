using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    bool front = true;
    private Vector3 End;
    private Controller Controller;
    private Vector3 StartT;
    private float TimeT;
    private string state = "idle";

    // Start is called before the first frame update
    void Start()
    {
        Controller = FindObjectOfType<Controller>();

        StartT = GameObject.Find("Position2").transform.position;
        End = GameObject.Find("Position1").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.action2 && state != "moving")
        {
            state = "moving";
            front = !front;
            TimeT = 1;            
        }

        TimeT = Mathf.Max(TimeT - Time.deltaTime, 0) ;
        if (front)
        {
            transform.position = Vector3.Lerp(StartT, End, TimeT);
        }
        else
        {
            transform.position = Vector3.Lerp(End, StartT, TimeT);
        }

        if(TimeT == 0)
        {
            state = "idle";
        }
    }
}
