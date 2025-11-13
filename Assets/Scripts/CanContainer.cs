using UnityEngine;

public class CanContainer : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip canSound;
    [SerializeField] private AudioClip nonCanSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isCan = collision.gameObject.CompareTag("Can");

        if (isCan)
        {
            Debug.Log("Can entered the container.");
            Destroy(collision.gameObject);
            PlayClip(canSound);
        }
        else
        {
            Debug.Log("Non-can object entered the container.");
            PlayClip(nonCanSound);
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (clip == null)
        {
            Debug.LogWarning("No AudioClip assigned for this condition!");
            return;
        }

        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = clip;
        audioSource.Play();
    }
}
