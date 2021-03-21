using UnityEngine;

public class FollowXZ : MonoBehaviour
{
    public Transform target;
    public float y = 80f;

    void Update()
    {
        transform.localPosition = new Vector3(target.position.x, y, target.position.z);
    }
}
