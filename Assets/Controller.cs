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
        goLeft = Input.GetKey(KeyCode.A);
        goRight = Input.GetKey(KeyCode.D);
        goUp = Input.GetKey(KeyCode.LeftArrow);
        goDown = Input.GetKey(KeyCode.RightArrow);
        action1 = Input.GetKeyDown(KeyCode.Space);
        action2 = Input.GetKeyDown(KeyCode.Backspace);
    }
}
