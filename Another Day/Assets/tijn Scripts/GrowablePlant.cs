using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrowablePlant : MonoBehaviour
{
    [SerializeField] GameObject bigPlantPrefab;
    [SerializeField] float waterTimeNeeded = 3f;

    float timer = 0f;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("WateringCan"))
        {
            timer += Time.deltaTime;
            if (timer >= waterTimeNeeded)
            {
                GameObject bigPlant = Instantiate(bigPlantPrefab, transform.position, transform.rotation);
                TaskManager.Instance.AddPlant();
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("WateringCan"))
            timer = 0f;
    }
}