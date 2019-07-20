using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    public ReferenceController rc;
    Camera camera;

    bool exploded = false;

    private void Start()
    {
        rc = FindObjectOfType<ReferenceController>();
        camera = FindObjectOfType<Camera>();
    }

    public void Shot(float power, Vector3 cannonAlignment)
    {
        this.GetComponent<Rigidbody>().velocity = cannonAlignment.normalized * power;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (exploded == false)
        {
            Debug.Log("Bang");
            camera.ShotLanded();
            rc.MakeExplosionAt(this.transform.position);
            exploded = true;
            Destroy(this.gameObject);
        }
    }
}
