using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime;
    public float startingTime = 10f;

    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        // Display as int
        countdownText.text = Mathf.FloorToInt(currentTime).ToString();

        if (currentTime <= 0)
        {
            currentTime = startingTime;
        }
    }
}
