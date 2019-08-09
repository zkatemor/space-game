using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody ship;
    public float speed;
    public float tilt;

    public float xMin, xMax, zMin, zMax;

    public GameObject lazerShot, leftLazerShot, rightLazerShot;
    public Transform gunPosition, leftGunPosition, rightGunPosition;

    public float shotDelay, smallShotDelay;
    private float nextShotTime, nextSmallShotTime;

    private GameScript gameScript;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
        gameScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameScript.isStartedAlready())
        {
            return;
        }

        LazerSettings();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, ship.velocity.x * -tilt);

        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(xPosition, 0, zPosition);
    }

    private void LazerSettings()
    {
        if (nextShotTime < Time.time && Input.GetButton("Fire1"))
        {
            Instantiate(lazerShot, gunPosition.position, Quaternion.identity);
            nextShotTime = shotDelay + Time.time;
        }

        if (nextSmallShotTime < Time.time && Input.GetButton("Fire2"))
        {
            Instantiate(leftLazerShot, leftGunPosition.position, Quaternion.identity);
            Instantiate(rightLazerShot, rightGunPosition.position, Quaternion.identity);
            nextSmallShotTime = smallShotDelay + Time.time;
        }
    }
}
