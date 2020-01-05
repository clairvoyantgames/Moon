using UnityEngine;

public class ShinePointAt : MonoBehaviour
{
    public GameObject star = null;

    private void Update()
    {
        if (star != null)
        {
            transform.LookAt(star.transform, Vector3.forward);
        }
    }
}