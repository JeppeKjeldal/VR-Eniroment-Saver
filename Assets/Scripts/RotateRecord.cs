using UnityEngine;

public class RotateRecord : MonoBehaviour
{
    public float rotationSpeed = 25f;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
