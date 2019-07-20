using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public ReferenceController rc;

    public float rotationSpeed;
    public float power;
    public float powerRate;
    float currentPower;
    public float powerMin = 25f;
    public float powerMax = 75f;

    public Ball ballPrefab;

    bool ballShot = false;
    Camera camera;

    public Vector3 currentRot;

    // Use this for initialization
    void Start () {
        camera = FindObjectOfType<Camera>();
        currentRot = this.transform.rotation.eulerAngles;
        currentPower = power;
    }
	
	// Update is called once per frame
	void Update () {

        // PITCH CONTROLS
		if (Input.GetKey(KeyCode.W))
        {
            //// Rotate up
            currentRot -= new Vector3(rotationSpeed * Time.deltaTime, 0f, 0f);
            currentRot.x = Mathf.Clamp(currentRot.x, 1f, 89f);
            rc.UIc.SetPitch(currentRot.x);
        }
        if (Input.GetKey(KeyCode.S))
        {
            // Rotate down
            currentRot += new Vector3(rotationSpeed * Time.deltaTime, 0f, 0f);
            currentRot.x = Mathf.Clamp(currentRot.x, 1f, 89f);
            rc.UIc.SetPitch(currentRot.x);
        }

        //// YAW CONTROLS
        //if (Input.GetKey(KeyCode.A))
        //{
        //    //// Rotate left
        //    currentRot += new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        //    currentRot.z = Mathf.Clamp(currentRot.z, -45f, 45f);
        //    rc.UIc.SetYaw(currentRot.z);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    // Rotate right
        //    currentRot -= new Vector3(0f, 0f, rotationSpeed * Time.deltaTime);
        //    currentRot.z = Mathf.Clamp(currentRot.z, -45f, 45f);
        //    rc.UIc.SetYaw(currentRot.z);
        //}

        // STRAFE CONTROLS
        if (Input.GetKey(KeyCode.A))
        {
            float strafePos = rotationSpeed / 10f * Time.deltaTime;
            strafePos = Mathf.Clamp(strafePos, -50f, 50f);
            this.transform.position -= new Vector3(strafePos, 0f, 0f);
            rc.UIc.SetYaw(strafePos);
        }
        if (Input.GetKey(KeyCode.D))
        {
            float strafePos = rotationSpeed / 10f * Time.deltaTime;
            strafePos = Mathf.Clamp(strafePos, -50f, 50f);
            this.transform.position += new Vector3(strafePos, 0f, 0f);
            rc.UIc.SetYaw(strafePos);
        }

        // POWER CONTROLS
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentPower = currentPower + Time.deltaTime * powerRate;
            currentPower = Mathf.Clamp(currentPower, powerMin, powerMax);
            rc.UIc.SetPower(currentPower);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentPower = currentPower - Time.deltaTime * powerRate;
            currentPower = Mathf.Clamp(currentPower, powerMin, powerMax);
            rc.UIc.SetPower(currentPower);
        }

        // FIRE
        if (Input.GetKeyDown(KeyCode.Space)) //&& ballShot == false)
        {
            Shoot();
            ballShot = true;
        }

        power = currentPower;
        this.transform.rotation = Quaternion.Euler(currentRot);
    }

    void Shoot()
    {
        Vector3 alignment = this.transform.rotation.eulerAngles;
        alignment.x = 90 - alignment.x;

        alignment = alignment * Mathf.Deg2Rad;

        Ball ball = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);

        ball.Shot(power, new Vector3 (-Mathf.Sin(alignment.z), Mathf.Sin(alignment.x), Mathf.Cos(alignment.x)));

        camera.Shot(ball);
    }

    public void SliderChanged(Vector3 newRot)
    {
        currentRot = newRot;
        //return true;
    }
}