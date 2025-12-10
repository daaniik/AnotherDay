using UnityEngine;
using TMPro;

public class WristTaskUI : MonoBehaviour
{
    [SerializeField] Transform leftWrist;        //  Drag Left Hand Controller here
    [SerializeField] Canvas wristCanvas;         //  Drag your UI Canvas here
    [SerializeField] float showAngle = 45f;
    [SerializeField] float hideDelay = 0.5f;

    Transform head;
    float hideTimer;

    void Start()
    {
        head = Camera.main.transform;
        wristCanvas.gameObject.SetActive(false);   //  fixed: wristCanvas instead of wrist
    }

    void Update()
    {
        Vector3 toWrist = leftWrist.position - head.position;
        float angle = Vector3.Angle(head.forward, toWrist);

        if (angle < showAngle)
        {
            wristCanvas.gameObject.SetActive(true);
            hideTimer = 0f;
        }
        else
        {
            hideTimer += Time.deltaTime;
            if (hideTimer >= hideDelay)
                wristCanvas.gameObject.SetActive(false);
        }
    }
}