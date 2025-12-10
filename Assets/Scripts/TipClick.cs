using UnityEngine;

public class TipClick : MonoBehaviour
{
    public Transform leftTip;
    public Transform rightTip;

    public float closedAngle = 20f;
    public float openAngle = 0f;

    private bool isClosed = false;

    public void OnGrab()
    {
        isClosed = true;
    }

    public void OnRelease()
    {
        isClosed = false;
    }

    private void Update()
    {
        float angle = isClosed ? closedAngle : openAngle;

        // Flip the directions
        leftTip.localRotation = Quaternion.Euler(0, 0, -angle);
        rightTip.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
