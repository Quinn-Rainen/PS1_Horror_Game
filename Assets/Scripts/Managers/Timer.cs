using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 10f; // Time limit in seconds
    private float currentTime;
    public Lever lever; // Reference to the Lever script
    private bool isRunning = false;
    private List<Lever> activatedLevers = new List<Lever>();
    //private bool isPuzzleSolved = false;
    private void Start()
    {
        currentTime = timeLimit;

    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);
            if (currentTime <= 0f)
            {
                // Time's up, handle the puzzle failure or time expiration
                ResetTimer();
                Debug.Log("Puzzle failed!");

                // Reset all levers to their deactivated state
                Lever[] levers = FindObjectsOfType<Lever>();
                foreach (Lever lever in levers)
                {
                    lever.ResetLever();
                }
            }
            // Check if all levers are activated and start the timer
            if (IsAllLeversActivated())
            {
                StopTimer();
                Debug.Log("Puzzle Won");
            }
        }


    }


    public void StartTimer(Lever lever)
    {
         if (!isRunning)
        {
            isRunning = true;
            //Debug.Log("Timer Started");
        }

        // Add the lever to the list of activated levers
        if (!activatedLevers.Contains(lever))
        {
            activatedLevers.Add(lever);
        }
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        StopTimer();
        currentTime = timeLimit;
    }

    public bool IsAllLeversActivated()
    {
        Lever[] levers = FindObjectsOfType<Lever>();

        foreach (Lever lever in levers)
        {
            if (!lever.isActivated)
            {
                return false;
            }
        }

        return true;
    }
}
