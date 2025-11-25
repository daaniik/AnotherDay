using UnityEngine;

public class FadingTaskScript : MonoBehaviour
{
    [SerializeField] private CanvasGroup MyUIGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    public void showUI()
    {
        fadeIn = true;
    }
    public void hideUI()
    {
        fadeOut = true; 
    }
    private void Update()
    {
        if (fadeIn)
        {
            if (MyUIGroup.alpha < 1)
            {
                MyUIGroup.alpha += Time.deltaTime;
                if (MyUIGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }
        if (fadeOut)
        {
            if (MyUIGroup.alpha >= 0)
            {
                MyUIGroup.alpha -= Time.deltaTime;
                if (MyUIGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

}
