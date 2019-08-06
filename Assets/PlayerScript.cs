using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody ship;
    public float speed;
    public float tilt;

    public float xMin, xMax, zMin, zMax;

    public GameObject lazerShot;
    public Transform gunPosition;

    public float shotDelay;
    private float nextShotTime;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nextShotTime < Time.time)
        {
            Instantiate(lazerShot, gunPosition.position, Quaternion.identity);
            nextShotTime = shotDelay + Time.time;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, ship.velocity.x * -tilt);

        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(xPosition, 0, zPosition);
    }
}
