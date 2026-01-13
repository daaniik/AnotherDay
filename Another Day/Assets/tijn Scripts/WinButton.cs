using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinButton : MonoBehaviour
{
    [SerializeField] Button winButton;
    [SerializeField] Image buttonImage; // Drag Button's Image here
    [SerializeField] TaskFailedScript winUI;

    void Start()
    {
        winButton.interactable = false;
        buttonImage.color = Color.red;
    }

    void Update()
    {
        bool complete = TaskManager.Instance.AllTasksComplete;
        winButton.interactable = complete;
        buttonImage.color = complete ? Color.green : Color.red;
    }

    public void OnWinButtonPressed()
    {
        StartCoroutine(WinSequence());
    }

    IEnumerator WinSequence()
    {
        yield return new WaitForSeconds(10f);
        winUI.showUI();
        Time.timeScale = 0f;
    }
}