using UnityEngine;

public class RotationY : MonoBehaviour
{
	void FixedUpdate ()
    {
        transform.Rotate(0f, 1f, 0f);
    }
}
