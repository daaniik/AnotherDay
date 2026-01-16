using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RightHandGrabAnimator : MonoBehaviour
{
    [SerializeField] Animator animator;

    XRBaseInteractor interactor;

    void Awake() => interactor = GetComponent<XRBaseInteractor>();

    void OnEnable()
    {
        interactor.selectEntered.AddListener(OnGrab);
        interactor.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        interactor.selectEntered.RemoveListener(OnGrab);
        interactor.selectExited.RemoveListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        string tag = args.interactableObject.transform.tag;

        animator.SetTrigger(GetTriggerFromTag(tag));
        animator.SetBool("isGrabbing", true);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        animator.SetBool("isGrabbing", false);
    }

    string GetTriggerFromTag(string tag)
    {
        tag = tag.ToLower();
        return tag switch
        {
            "Afwasborstel" => "GrabAfwasborstel",
            "Gieters" => "GrabGieters",
            "Papier" => "GrabPapierProp",
            "Bord" => "GrabBord",
            "Boek" => "GrabBoek",
            "Kleren" => "GrabKleren",
            "Prullen" => "GrabPrullen",
            _ => "GrabGeneric" // fallback
        };
    }
}