using UnityEngine;

public class SimpleDishCleaner : MonoBehaviour
{
    [SerializeField] GameObject cleanDishPrefab;
    [SerializeField] float scrubTimeNeeded = 3f;

    float scrubTimer = 0f;
    bool isScrubbing = false;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Brush")) // tag your brush
        {
            isScrubbing = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Brush"))
            isScrubbing = false;
    }

    void Update()
    {
        if (isScrubbing)
        {
            scrubTimer += Time.deltaTime;
            if (scrubTimer >= scrubTimeNeeded)
            {
                Instantiate(cleanDishPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            scrubTimer = 0f;
        }
    }
}