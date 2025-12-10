using UnityEngine;

public class TipClick : MonoBehaviour
{
    public Transform leftTip;
    public Transform rightTip;

    public float closedAngle = 20f;
    public float openAngle = 0f;
    public float animationDuration = 0.2f;

    private bool isClosed = false;

    public void OnGrab()
    {
        isClosed = true;

        leftTip.localRotation = Quaternion.Euler(0, 0, isClosed ? openAngle : closedAngle);
        rightTip.localRotation = Quaternion.Euler(0, 0, isClosed ? -openAngle : -closedAngle);

        Debug.Log(leftTip.localRotation.eulerAngles);
        Debug.Log(rightTip.localRotation.eulerAngles);

        Debug.Log("Left local: " + leftTip.localRotation);
        Debug.Log("Right local: " + rightTip.localRotation);
    }

    public void OnRelease()
    {
        isClosed = false;

        leftTip.localRotation = Quaternion.Euler(0, 0, isClosed ? openAngle : closedAngle);
        leftTip.localRotation = Quaternion.Euler(0, 0, isClosed ? -openAngle : -closedAngle);
    }
}
