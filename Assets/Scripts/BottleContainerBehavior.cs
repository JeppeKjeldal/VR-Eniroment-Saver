using UnityEngine;

public class BottleContainerBehavior : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip bottleSound;
    [SerializeField] private AudioClip nonBottleSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isCan = collision.gameObject.CompareTag("Bottle");

        if (isCan)
        {
            Debug.Log("Bottle entered the container.");
            Destroy(collision.gameObject);
            PlayClip(bottleSound);
        }
        else
        {
            Debug.Log("Non-bottle object entered the container.");
            PlayClip(nonBottleSound);
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
