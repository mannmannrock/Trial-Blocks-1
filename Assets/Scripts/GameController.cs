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
    public GameObject forceField;

    //State Info
    public float timerLength = 10;

    private void Awake()
    {
        controls = new Controls();
        timerText = GameObject.Find("Timer Text").GetComponent<TextMeshProUGUI>();
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
        forceField.SetActive(true);
        StartCoroutine(TimerWait(1));
    }

    private IEnumerator TimerWait(float waitTime)
    {
        //recursively calls each second
        timerText.text = timerLength.ToString();
        Debug.Log(timerLength);
        
        yield return new WaitForSeconds(waitTime);

        timerLength -= 1;
        if (timerLength < 0)
            OnTimerEnd();
        else
            StartCoroutine(TimerWait(1));
    }

    private void OnTimerEnd()
    {
        Debug.Log("Timer Ended");
    }
}
