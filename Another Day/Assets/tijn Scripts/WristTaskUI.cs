using UnityEngine;
using UnityEngine.InputSystem;

public class WristTaskUI : MonoBehaviour
{
    [SerializeField] Canvas wristCanvas;

    // Change this if you use right hand or different button
    public InputActionProperty showButton; // Drag "X Button" action here

    void OnEnable() => showButton.action.performed += ToggleUI;
    void OnDisable() => showButton.action.performed -= ToggleUI;

    void ToggleUI(InputAction.CallbackContext ctx)
    {
        bool currentlyActive = wristCanvas.gameObject.activeSelf;
        wristCanvas.gameObject.SetActive(!currentlyActive);
    }
}