using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class LaundryBasket : MonoBehaviour
{
    [SerializeField] Transform[] dropPoints;
    public int currentIndex = 0;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Clothing") || currentIndex >= dropPoints.Length) return;

        GameObject clothing = other.gameObject;

        if (clothing.TryGetComponent<Collider>(out var col))
            col.enabled = false;

        if (clothing.TryGetComponent<XRGrabInteractable>(out var grab))
            grab.enabled = false;
        if (clothing.TryGetComponent<Rigidbody>(out var rb))
            rb.isKinematic = true;

        // Snap to the next point
        clothing.transform.position = dropPoints[currentIndex].position;
        clothing.transform.rotation = dropPoints[currentIndex].rotation;
        clothing.transform.SetParent(dropPoints[currentIndex]);

        TaskManager.Instance.AddCloth();

        currentIndex++;
    
    }

   
}