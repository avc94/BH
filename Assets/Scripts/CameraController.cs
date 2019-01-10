using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 offset = new Vector3(0, 0, -20);
    Vector3 velocity = Vector3.zero;
    float smoothTime = 0.15f;

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + offset, ref velocity, smoothTime);
        }
    }

    public void SetTarget(GameObject player)
    {
        this.player = player;
        transform.position = player.transform.position;
    }
}
