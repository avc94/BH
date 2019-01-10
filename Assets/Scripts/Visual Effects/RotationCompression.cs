using UnityEngine;

public class RotationCompression : MonoBehaviour
{
    float x;
    bool increase = true;
    int border = 5;
    
	void FixedUpdate ()
    {
        if (increase)
        {
            x++;
        }
        else
        {
            x--;
        }

        if (x > border)
        {
            increase = false;
        }
        if (x < -border)
        {
            increase = true;
        }

        transform.Rotate(new Vector3(x, 0f, 0f));
	}
}
