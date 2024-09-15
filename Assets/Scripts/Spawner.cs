using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //References
    private GameController gameController;
    public GameObject spawnedPrefab;
    private Transform cube;

    //State Info
    public float spawnRate;
    public bool active;
    private bool becomeActive;

    void Start()
    {
        gameController = GameObject.Find("Game Controller").GetComponent<GameController>();
        cube = GameObject.Find("Cube").transform;
    }

    void Update()
    {
        if (active && becomeActive)
        {
            StartCoroutine(Spawn(spawnRate));
            becomeActive = false;
        }

        if (!active)
            becomeActive = true;
    }

    private IEnumerator Spawn(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        if (active)
        {
            Instantiate(spawnedPrefab, transform.position, Quaternion.identity, cube);
            StartCoroutine(Spawn(spawnRate));
        }
    }
}
