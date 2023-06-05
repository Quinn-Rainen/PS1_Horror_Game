using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushJump : MonoBehaviour
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
        // No matter if the player is moving or if the monster is close enough it deletes it self after moving towards the player
        float elapsedTime = 0f;
        float maxDuration = 1.5f; 

        while (elapsedTime < maxDuration)
        {
            Vector3 targetPosition = playerTransform.position + Vector3.up * 10f + Vector3.left *17f + Vector3.back*12f;
            targetPosition = targetPosition - Vector3.left*10f;
            jumpscareObject.transform.position = Vector3.Lerp(jumpscareObject.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Destroy(jumpscareObject);
        Destroy(gameObject);
    }
}
