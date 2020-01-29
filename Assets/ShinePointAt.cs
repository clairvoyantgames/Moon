using UnityEngine;

public class ShinePointAt : MonoBehaviour
{
    public GameObject otherStar = null;

    private void Update()
    {
        if (otherStar != null)
        {
            transform.LookAt(otherStar.transform, Vector3.forward);

            var distance = Vector3.Distance(otherStar.transform.position, transform.position);
            var length = transform.localScale;
            var child = transform.GetChild(0);
            var maxLength = child.transform.localPosition.z;
            length.z = distance == 0f ? 0f : (distance / maxLength);
            transform.localScale = length;
        }
    }
}