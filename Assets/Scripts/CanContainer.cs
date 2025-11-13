using UnityEngine;

public class CanContainer : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Can"))
        {
            Debug.Log("Can entered the container.");
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Non-can object entered the container.");
        }
    }
}
