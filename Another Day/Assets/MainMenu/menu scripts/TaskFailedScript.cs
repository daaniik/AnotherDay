using UnityEngine;

public class TaskFailedScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup MyUIGroup;
    [SerializeField] public bool fadeIn2 = false;
    [SerializeField] private bool fadeOut = false;
   public void showUI()
    {
        fadeIn2 = true;
    }
    public void hideUI()
    {
        fadeOut = true;
    }
   
    void Update()
    {
        if (fadeIn2)
        {
            if (MyUIGroup.alpha < 1)
            {
                MyUIGroup.alpha += Time.deltaTime;
                if (MyUIGroup.alpha >= 1) fadeIn2 = false;
            }
        }
        if (fadeOut)
        {
            if (MyUIGroup.alpha > 0) 
            {
                MyUIGroup.alpha -= Time.deltaTime;
                if (MyUIGroup.alpha <= 0) fadeOut = false;
            }
        }
    }

}
