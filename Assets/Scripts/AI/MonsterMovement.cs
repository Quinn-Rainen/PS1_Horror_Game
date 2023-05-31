using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public GameObject jumpscareObject;
    public Transform playerTransform;
    public float moveSpeed = 20f;

    void Start()
    {
        jumpscareObject.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.CompareTag("Player"))
        {
            jumpscareObject.SetActive(true);
            StartCoroutine(MoveTowardsPlayer());
        }
    }

    IEnumerator MoveTowardsPlayer()
    {
        float elapsedTime = 0f;
        float maxDuration = 3.5f; 

        // No matter if the player is moving or if the monster is close enough it deletes it self after moving towards the player
        while (elapsedTime < maxDuration && Vector3.Distance(jumpscareObject.transform.position, playerTransform.position) > 0.1f)
        {
            jumpscareObject.transform.position = Vector3.Lerp(jumpscareObject.transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }


        Destroy(jumpscareObject);
        Destroy(gameObject);
    }
}