using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;

    public int speed;

    private bool isMoving;

    public float stoppingDistance = 1f;

    public float duration;

    public float moveDistance;

    public float maxHeight;

    private Vector3 initialPosition;


    // Start is called before the first frame update
    void Start()
    {
        //Distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        isMoving = true;
        initialPosition = enemy.transform.position;
        StartCoroutine(Stop(duration));
    }

    private void Update()
    {

    }
    IEnumerator Stop(float duration)
    {
        while (true)
        {
            Vector3 targetPosition;

            // Determine the target position based on the direction
            if (isMoving)
            {
                // Move forward by `moveDistance` units
                targetPosition = initialPosition + Vector3.forward * moveDistance;
            }
            else
            {
                // Move back to the initial position
                targetPosition = initialPosition;
            }

            // Move in an arc toward the target position
            float hopDuration = moveDistance / speed;
            float elapsedTime = 0;
            Vector3 startPosition = enemy.transform.position;

            while (elapsedTime < hopDuration)
            {
                elapsedTime += Time.deltaTime;
                float normalizedTime = elapsedTime / hopDuration;

                // Linear interpolation for horizontal movement
                Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, normalizedTime);

                // Parabolic arc for vertical movement
                float heightFactor = 4 * maxHeight * (normalizedTime - normalizedTime * normalizedTime); // Parabolic curve
                currentPos.y = startPosition.y + heightFactor;

                enemy.transform.position = currentPos;
                yield return null;
            }

            // Ensure the final position is set exactly to the target
            enemy.transform.position = targetPosition;

            // Wait for a specified duration, then reverse direction
            yield return new WaitForSeconds(duration);
            isMoving = !isMoving;
        }
    }/*
    IEnumerator Stop(float duration)
    {
        while (true)
        {
            if (isMoving)
            {
                isMoving = false;

                while (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance)
                {

              
                    //calc distance
                    Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                    Vector3 targetPosition = transform.position + directionToPlayer * moveDistance;


                    float hopDuration = moveDistance / speed;
                    float halfHopTime = hopDuration / 2f;

                    Vector3 startPosition = enemy.transform.position;
                    float elapsedTime = 0;

                    //move enemy if distance > .01 and outside stopping point for player
                    while (elapsedTime < hopDuration)//(Vector3.Distance(transform.position, targetPosition) > .01f) && (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance))
                    {
                        elapsedTime += Time.deltaTime;
                        float normalizedTime = elapsedTime / hopDuration;

                        // Linear interpolation for horizontal movement
                        Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, normalizedTime);

                        // Parabolic arc for vertical movement
                        float heightFactor = 4 * maxHeight * (normalizedTime - normalizedTime * normalizedTime); // Parabolic curve
                        currentPos.y = startPosition.y + heightFactor;

                        transform.position = currentPos;
                        yield return null;


                    }

                    yield return new WaitForSeconds(duration);

                }

                

                isMoving = true;
            }

            
            yield return null;
        }
    }*/
}


