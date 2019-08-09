using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public List<GameObject> asteroids;
    public float minDelay, maxDelay;

    private float nextSpawn;

    private GameScript gameScript;

    // Start is called before the first frame update
    void Start()
    {
        gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameScript.isStartedAlready())
        {
            return;
        }

        if (Time.time > nextSpawn)
        {
            float yPosition = transform.position.y;
            float zPosition = transform.position.z;
            float xPosition = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);

            Vector3 newPosition = new Vector3(xPosition, yPosition, zPosition);
            Instantiate(asteroids[Random.Range(0, asteroids.Count)], newPosition, Quaternion.identity);
            nextSpawn = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
