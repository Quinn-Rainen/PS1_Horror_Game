using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLimit = 10f; 
    private float currentTime;
    public Lever lever; 
    private bool isRunning = false;
    private List<Lever> activatedLevers = new List<Lever>();

    private AudioSource tt_source;

    private void Start()
    {
        currentTime = timeLimit;
        tt_source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            Debug.Log(currentTime);
            if (currentTime <= 0f)
            {
                ResetTimer();
                Debug.Log("Puzzle failed!");

                // Reset every lever
                Lever[] levers = FindObjectsOfType<Lever>();
                foreach (Lever lever in levers)
                {
                    lever.ResetLever();
                }
            }
            
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
            tt_source.Play();

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
        tt_source.Stop();
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
