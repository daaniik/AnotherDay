using UnityEngine;

public class WashingmachineSpin : MonoBehaviour
{
    public float rotationSpeed;
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
