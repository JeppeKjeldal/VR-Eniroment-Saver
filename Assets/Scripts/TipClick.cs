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
        float leftTarget = isClosed ? closedAngle : openAngle;
        float rightTarget = isClosed ? -closedAngle : -openAngle;

        leftTip.localRotation = Quaternion.Euler(0, 0, leftTarget);
        rightTip.localRotation = Quaternion.Euler(0, 0, rightTarget);
    }
}
