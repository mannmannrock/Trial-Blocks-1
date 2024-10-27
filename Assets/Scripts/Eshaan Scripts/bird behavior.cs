using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdbehavior : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public int speed;

    private bool isMoving;

    public float stoppingDistance = 1f;

    float duration = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        //Distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        isMoving = true;
        StartCoroutine(Stop(duration));
    }

    IEnumerator Stop(float duration)
    {
        while (true)
        {
            if (isMoving)
            {
                isMoving = false;
                Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                Vector3 targetPosition = transform.position + directionToPlayer * stoppingDistance;

                //move enemy if distance > .01 and outside stopping point for player
                while ((Vector3.Distance(transform.position, targetPosition) > .01f) && (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance))
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    yield return null;
                }

                // Pause for a specified duration
                yield return new WaitForSeconds(duration);

                // Reset position to initial after moving


                isMoving = true;
            }

            // Ensure a small wait in the loop to avoid spamming movement checks
            yield return null;
        }
    }
}
