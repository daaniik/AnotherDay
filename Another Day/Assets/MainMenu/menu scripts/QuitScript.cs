using UnityEngine;

public class QuitScript : MonoBehaviour
{
    public void quit()
    {
        Application.Quit();
        Debug.Log("speler heeft het spel verlaten");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
