using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timestart = 0;
    public Text timerText;
    void Start()
    {
        timerText.text = timestart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        timestart += Time.deltaTime;
        timerText.text = timestart.ToString("F2");
    }
}
