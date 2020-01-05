using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStar : MonoBehaviour
{
    public bool editing = false;
    private GameObject sky;
    private GameObject star;
    private Controller Controller;
    public Material mat;
    public List<List<GameObject>> constellations = new List<List<GameObject>>();
    public List<GameObject> currentConstellation = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        Controller = FindObjectOfType<Controller>();

        sky = GameObject.Find("sky origin");
        star = GameObject.Find("star");
    }

    // Update is called once per frame
    void Update()
    {
        if (editing)
        {
            if (Controller.action1)
            {
                var newStar = Instantiate(star, transform);
                newStar.GetComponentInChildren<MeshRenderer>().material = mat;
                newStar.transform.parent = sky.transform;
                currentConstellation.Add(newStar);                
            }

            if (Controller.action2)
            {
                constellations.Add(currentConstellation);
                currentConstellation = new List<GameObject>();
                editing = !editing;
            }
        }
        else
        {
            foreach (var cons in constellations)
            {
                GameObject lastStar = null;
                foreach (var con in cons)
                {
                    if(lastStar == null)
                    {
                        lastStar = con;
                    }
                    else
                    {
                        con.GetComponent<ConnectStar>().otherStar = lastStar;
                        lastStar = con;
                    }
                }
            }

            if (Controller.action2)
            {
                editing = !editing;
            }
        }

       
    }
}
