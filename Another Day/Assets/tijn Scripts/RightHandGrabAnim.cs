using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RightHandGrabAnim : MonoBehaviour
{
    [SerializeField] Animator handAnimator;
    XRBaseInteractor interactor;

    void Awake() => interactor = GetComponent<XRBaseInteractor>();

    void OnEnable()
    {
        interactor.hoverEntered.AddListener(Hover);
        interactor.hoverExited.AddListener(Unhover);
        interactor.selectEntered.AddListener(Grab);
        interactor.selectExited.AddListener(Ungrab);
    }

    void OnDisable()
    {
        interactor.hoverEntered.RemoveListener(Hover);
        interactor.hoverExited.RemoveListener(Unhover);
        interactor.selectEntered.RemoveListener(Grab);
        interactor.selectExited.RemoveListener(Ungrab);
    }

    void Hover(HoverEnterEventArgs e) => handAnimator.SetBool("isHoveringHilt", true);
    void Unhover(HoverExitEventArgs e) => handAnimator.SetBool("isHoveringHilt", false);
    void Grab(SelectEnterEventArgs e) => handAnimator.SetBool("isGrabbing", true);
    void Ungrab(SelectExitEventArgs e) => handAnimator.SetBool("isGrabbing", false);
}