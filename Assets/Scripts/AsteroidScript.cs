using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    private Rigidbody asteroid;
    public float rotationSpeed;

    public float minSpeed, maxSpeed;

    public GameObject asteroidExplosion, playerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = Vector3.back * Random.Range(minSpeed, maxSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary" || other.tag == "Asteroid")
        {
            return;
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

        if (other.tag == "StarShip")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
