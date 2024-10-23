using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public int speed;

    private bool isMoving;

    float jumpDis = 10;

    public float stoppingDistance = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //Distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        isMoving = false;
        StartCoroutine(Stop(1));
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Distance = Vector3.Distance(enemy.transform.position, player.transform.position);


        Vector3 pos = player.transform.position - enemy.transform.position; 
        pos = pos.normalized;
        while (isMoving == true )
        {
            enemy.transform.Translate(pos.x * Time.deltaTime * speed, pos.y * Time.deltaTime * speed, pos.z * Time.deltaTime * speed);
        }
        */
   
    }

    IEnumerator Stop(float duration)
    {
        while (true)
        {
            if (!isMoving)
            {
                isMoving = true;
                Vector3 directionToPlayer = (player.transform.position - transform.position).normalized;
                Vector3 targetPosition = transform.position + directionToPlayer * stoppingDistance;

                // Move the object to the target position
                while (Vector3.Distance(transform.position, targetPosition) > 0.01f && (Vector3.Distance(transform.position, player.transform.position) > stoppingDistance))
                {
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                    yield return null;
                }

                // Pause for a specified duration
                yield return new WaitForSeconds(duration);

                // Reset position to initial after moving
                

                isMoving = false;
            }

            // Ensure a small wait in the loop to avoid spamming movement checks
            yield return null;
        }
    }
}


