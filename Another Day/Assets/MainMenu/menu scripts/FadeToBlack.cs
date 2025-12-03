using System.Collections;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool FadeOnLoose;
    public float FadeDuration = 2;
    public Color FadeColor;
    private Renderer rend;
    public GameObject taskFailedScript;

    void Update()
    {
        rend = GetComponent<Renderer>();
        //if (FadeOnLoose == true)
        //{
        //    fadeOut();
        //}
        if (FadeOnLoose == true) 
        {
            fadeOut();
            taskFailedScript.GetComponent<TaskFailedScript>().fadeIn2 = true;
            FadeOnLoose = false;
           // GetComponent<TaskFailedScript>().fadeIn2 = true;
        }
            
    }
    public void fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(fadeRoutine(alphaIn, alphaOut));
    }
    public void fadeIn()
    {
        fade(1, 0);
    }
    public void fadeOut()
    {
        fade(0, 1);
    }
    public IEnumerator fadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer < FadeDuration)
        {
            Color newcolor = FadeColor;
            newcolor.a = Mathf.Lerp(alphaIn, alphaOut, timer/FadeDuration);
            rend.material.SetColor("_Color", newcolor);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
