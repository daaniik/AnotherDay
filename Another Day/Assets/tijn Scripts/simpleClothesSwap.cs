using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SimpleClothesSwap : MonoBehaviour
{
    public GameObject cleanVersion; 

    void OnSelectEntered(SelectEnterEventArgs args)
    {
        Instantiate(cleanVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}