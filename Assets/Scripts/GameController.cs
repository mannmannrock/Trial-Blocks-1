using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    //References
    private TextMeshProUGUI timerText;
    private Controls controls;

    //State Info
    public float waitTime = 10;

    private void Awake()
    {
        controls = new Controls();
        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
        Physics.gravity = new Vector3(0, 0);
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Player.Start.performed += StartTimer;
    }

    private void OnDisable()
    {
        controls.Player.Start.performed -= StartTimer;
        controls.Disable();
    }

    void Update()
    {
        
    }

    private void StartTimer(InputAction.CallbackContext context)
    {
        Debug.Log("Timer Started");
        Physics.gravity = new Vector3(0, -9.81f);
        StartCoroutine(TimerWait(1));
    }

    private IEnumerator TimerWait(float wait)
    {
        //recursively calls each second
        timerText.text = waitTime.ToString();
        Debug.Log(waitTime);
        waitTime -= 1;
        
        yield return new WaitForSeconds(wait);

        if (waitTime < 0)
            OnTimerEnd();
        else
            StartCoroutine(TimerWait(1));
    }

    private void OnTimerEnd()
    {
        Debug.Log("Timer Ended");
    }
}
