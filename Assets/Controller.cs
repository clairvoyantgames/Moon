using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool goLeft;
    public bool goRight;
    public bool goUp;
    public bool goDown;
    public bool action1;
    public bool action2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        goUp = Input.GetKey(KeyCode.A);
        goDown = Input.GetKey(KeyCode.D);
        goLeft = Input.GetKey(KeyCode.LeftArrow);
        goRight = Input.GetKey(KeyCode.RightArrow);
        action1 = Input.GetKeyDown(KeyCode.Space);
        action2 = Input.GetKeyDown(KeyCode.Backspace);
    }
}
