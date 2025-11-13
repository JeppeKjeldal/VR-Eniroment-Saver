using UnityEngine;

public class OrganicContainerBehavior : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip organicSound;
    [SerializeField] private AudioClip nonOrganicSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isCan = collision.gameObject.CompareTag("Organic");

        if (isCan)
        {
            Debug.Log("Organic entered the container.");
            Destroy(collision.gameObject);
            PlayClip(organicSound);
        }
        else
        {
            Debug.Log("Non-organic object entered the container.");
            PlayClip(nonOrganicSound);
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
