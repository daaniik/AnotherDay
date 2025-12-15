using UnityEngine;
using UnityEngine.InputSystem;

public class WristTaskUI : MonoBehaviour
{
    [SerializeField] Canvas wristCanvas;
    public InputActionProperty showButton; 

    void Start() => wristCanvas.gameObject.SetActive(false);

    void OnEnable() => showButton.action.performed += ToggleUI;
    void OnDisable() => showButton.action.performed -= ToggleUI;

    void ToggleUI(InputAction.CallbackContext ctx)
    {
        wristCanvas.gameObject.SetActive(!wristCanvas.gameObject.activeSelf);
    }
}