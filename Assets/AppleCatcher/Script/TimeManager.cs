using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    TextMeshPro ref_timeleft;
    private float timeLeft = 180f;

    private bool gameStarted = false;
    protected float timeBeforeStart = 3.4f;
    // Start is called before the first frame update
    void Start()
    {
        ref_timeleft.SetText("Time left : " +Mathf.Round(timeLeft)+ " s");
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted) {
            timeBeforeStart -= Time.deltaTime;
        }

        
        if (timeBeforeStart <= 0) { // If the starting time is over then
            gameStarted = true; // The game start
        }


        if (gameStarted) {
            timeLeft -= Time.deltaTime;
            ref_timeleft.SetText("Time left : " +Mathf.Round(timeLeft)+ " s");
        }
        
    }

    public float getTimeLeft() {
        return timeLeft;
    }
}
