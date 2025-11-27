using UnityEngine;

public abstract class ContainerBehavior : MonoBehaviour
{
    protected AudioSource audioSource;

    [SerializeField] protected AudioClip correctSound;
    [SerializeField] protected AudioClip wrongSound;

    // Hvilket tag er korrekt for denne container?
    protected abstract string AcceptedTag { get; }

    protected virtual void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        bool isCorrect = other.gameObject.CompareTag(AcceptedTag);

        if (isCorrect)
        {
            HandleCorrectObject(other);
        }
        else
        {
            HandleWrongObject();
        }
    }

    protected virtual void HandleCorrectObject(Collision collision)
    {
        Destroy(collision.gameObject);
        PlayClip(correctSound);
        EnviromentProgress.Instance.AddTrashCollectedToTotalAmount(1);
    }

    protected virtual void HandleWrongObject()
    {
        PlayClip(wrongSound);
    }

    protected void PlayClip(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        if (audioSource.isPlaying)
            audioSource.Stop();

        audioSource.clip = clip;
        audioSource.Play();
    }
}
