using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimerControl : MonoBehaviour
{
    [SerializeField] private double timeLeft;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private UnityEvent onTimerEnd;

    private Timer timer;

    void Start()
    {
        timer = new Timer(timeLeft);
    }

    void Update()
    {
        timer.Tick(Time.deltaTime);
        timerText.SetText(timer.GetText());
        if (timer.Done())
        {
            onTimerEnd.Invoke();
            Destroy(gameObject);
        }
    }
}
