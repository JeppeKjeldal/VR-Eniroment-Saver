using UnityEngine;

public class WaterFloat : MonoBehaviour
{
    #region PROPERTIES

    [Tooltip("How far you want the object to float on each axis")]
    public Vector3 amplitude = new Vector3(0, 0.5f, 0);
    [Tooltip("How fast you want the object to float on each axis")]
    public Vector3 frequency = new Vector3(1, 1, 1);

    [Tooltip("How far you want the object to rotate on each axis")]
    public Vector3 rotationAmplitude = new Vector3(15, 30, 45);
    [Tooltip("How fast you want the object to rotate on each axis")]
    public Vector3 rotationFrequency = new Vector3(1, 1, 1);

    #endregion

    #region SYSTEM VARIABLES

    Vector3 startPosition;
    Vector3 startRotation;

    #endregion

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.eulerAngles;
    }

    void Update()
    {
        // position float
        float newX = startPosition.x + Mathf.Sin(Time.time * frequency.x) * amplitude.x;
        float newY = startPosition.y + Mathf.Sin(Time.time * frequency.y) * amplitude.y;
        float newZ = startPosition.z + Mathf.Sin(Time.time * frequency.z) * amplitude.z;
        transform.position = new Vector3(newX, newY, newZ);

        // rotation
        float rotX = startRotation.x + Mathf.Sin(Time.time * rotationFrequency.x) * rotationAmplitude.x;
        float rotY = startRotation.y + Mathf.Sin(Time.time * rotationFrequency.y) * rotationAmplitude.y;
        float rotZ = startRotation.z + Mathf.Sin(Time.time * rotationFrequency.z) * rotationAmplitude.z;
        transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }
}