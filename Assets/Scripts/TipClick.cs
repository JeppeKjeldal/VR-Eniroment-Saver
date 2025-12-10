using UnityEngine;

public class TipClick : MonoBehaviour
{
    [SerializeField] private Transform leftTip;
    [SerializeField] private Transform rightTip;

    [SerializeField] private float closedAngle = 20f;
    [SerializeField] private float openAngle = 0f;

    [SerializeField] private AudioClip clickSound;
    [SerializeField] private Transform soundLocation;

    private bool isClosed = false;

    public void OnGrab()
    {
        if (!isClosed)
        {
            isClosed = true;
            PlayClickSound();
        }
    }

    public void OnRelease()
    {
        isClosed = false;
    }

    private void Update()
    {
        ApplyTipRotation();
    }

    private void ApplyTipRotation()
    {
        float angle = isClosed ? closedAngle : openAngle;

        leftTip.localRotation = Quaternion.Euler(0, 0, -angle);
        rightTip.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private void PlayClickSound()
    {
        if (clickSound == null || soundLocation == null)
            return;

        AudioSource.PlayClipAtPoint(clickSound, soundLocation.position);
    }
}
