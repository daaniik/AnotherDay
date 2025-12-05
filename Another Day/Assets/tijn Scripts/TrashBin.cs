using UnityEngine;

public class TrashBin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
            Destroy(other.gameObject);
    }
}