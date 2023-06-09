using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditEnding : MonoBehaviour
{
    private float timer = 30f;
    
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ScenesManager.Instance.LoadMainMenu();
        }
    }
}
