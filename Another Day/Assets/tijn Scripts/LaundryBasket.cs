using UnityEngine;

public class LaundryBasket : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clothing"))
            Destroy(other.gameObject);
    }
}