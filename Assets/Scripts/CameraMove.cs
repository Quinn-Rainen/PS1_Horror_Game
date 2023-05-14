using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Range(0.001f, 1f)]
    public float Amount = 0.002f;
    [Range(1f, 30f)]
    public float frequency = 10.0f;
    [Range(1f, 100f)]
    public float Smooth = 1f;

    Vector3 StartPos;
    private bool isMoving;

    void Start()
    {
        StartPos = transform.localPosition;
    }

    void Update()
    {
        CheckForHeadbobTrigger();
        StopHeadbob();
    }

    private void CheckForHeadbobTrigger()
    {
        float inputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        if (inputMagnitude > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector3 pos = Vector3.zero;
            pos.y += Mathf.Lerp(pos.y, Mathf.Sin(Time.time * frequency) * Amount * 1.4f, Smooth * Time.deltaTime);
            pos.x += Mathf.Lerp(pos.x, Mathf.Cos(Time.time * frequency / 2f) * Amount * 1.6f, Smooth * Time.deltaTime);
            transform.localPosition += pos;
        }
    }

    private void StopHeadbob()
    {
        if (transform.localPosition == StartPos) return;
        transform.localPosition = Vector3.Lerp(transform.localPosition, StartPos, Smooth * Time.deltaTime);
    }
}