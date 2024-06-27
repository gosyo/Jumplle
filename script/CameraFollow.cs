using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothspeed = 1.0f;
    Vector3 speed;

    private void LateUpdate()
    {
        if (target.position.y > transform.position.y)
        {
            Vector3 targetPos = new Vector3(0f, target.position.y, -10f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothspeed * Time.deltaTime);
        }
    }

}
