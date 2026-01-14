using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ObjectGrabAnimator : MonoBehaviour
{
    Animator animator;
    XRBaseInteractor interactor;

    void Awake()
    {
        animator = GetComponent<Animator>();
        interactor = GetComponent<XRBaseInteractor>();
    }

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
        string itemName = args.interactableObject.transform.name.Replace("(Clone)", "");
        string triggerName = GetTriggerName(itemName);
        animator.SetTrigger(triggerName);
        animator.SetBool("isGrabbing", true);
    }

    void OnRelease(SelectExitEventArgs args)
    {
        animator.SetBool("isGrabbing", false);
    }

    string GetTriggerName(string item)
    {
        item = item.ToLower();
        if (item.Contains("afwasborstel")) return "GrabAfwasborstel";
        if (item.Contains("gieters")) return "GrabGieters";
        if (item.Contains("papierprop") || item.Contains("papier")) return "GrabPapierProp";
        if (item.Contains("bordvies") || item.Contains("bord")) return "GrabBordVies";
        if (item.Contains("boek")) return "GrabBoek";
        // Add more items as needed
        return "GrabGeneric"; // Fallback - add this state too
    }
}