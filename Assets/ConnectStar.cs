using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectStar : MonoBehaviour
{
    public GameObject otherStar = null;
    private GameObject shine;
    private GameObject currentShine = null;
    private bool shined = false;

    // Start is called before the first frame update
    void Start()
    {
        shine = GameObject.Find("shine origin");
    }

    // Update is called once per frame
    void Update()
    {
        if(otherStar != null && !shined)
        {
            shined = true;
            currentShine = Instantiate(shine);
            var point = currentShine.GetComponent<ShinePointAt>();
            point.star = gameObject;
            currentShine.transform.parent = otherStar.transform;
            currentShine.transform.position = otherStar.transform.position;
        }
    }
}