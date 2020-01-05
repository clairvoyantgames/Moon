using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStar : MonoBehaviour
{
    public GameObject otherStar = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(otherStar != null)
        {
            Debug.DrawLine(transform.position, otherStar.transform.position);
        }
    }
}
