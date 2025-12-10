using UnityEngine;

public class TipClick : MonoBehaviour
{
    public Transform leftTip;
    public Transform rightTip;

    public float closedAngle = 20f;
    public float openAngle = 0f;

    private bool isClosed = false;

    [SerializeField] private AudioClip clickSound;
    [SerializeField] private Transform soundLocation;

    public void OnGrab()
    {
        isClosed = true;
        AudioSource.PlayClipAtPoint(clickSound, transform.position);
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
