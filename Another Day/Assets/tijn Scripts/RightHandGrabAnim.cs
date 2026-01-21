using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RightHandGrabAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;          // ← drag your right hand Animator here

    XRBaseInteractor interactor;

    void Awake()
    {
        interactor = GetComponent<XRBaseInteractor>();
        if (animator == null)
            animator = GetComponent<Animator>();     // fallback if not assigned
    }

    void OnEnable()
    {
        if (interactor == null || animator == null) return;

        interactor.selectEntered.AddListener(OnGrab);
        interactor.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        if (interactor == null) return;

        interactor.selectEntered.RemoveListener(OnGrab);
        interactor.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        string tag = args.interactableObject.transform.tag.ToLower();
        string trigger = tag switch
        {
            "Gieters" => "GrabGieters",
            "Afwasborstel" => "GrabAfwasborstel",
            "Papier" => "GrabPapierProp",
            "Bord" => "GrabBord",
            "Boek" => "GrabBoek",
            "Kleren" => "GrabKleren",
            "Plant" => "GrabPlant",
            "Prullen" => "GrabPrullen",
            _ => "GrabGeneric"
        };

        animator.SetTrigger(trigger);
        animator.SetBool("isGrabbing", true);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        animator.SetBool("isGrabbing", false);
    }
}