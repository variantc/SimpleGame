using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public ReferenceController rc;

    public float radius;
    public float power;

    public float explosionSpeed;
    
    void Start()
    {
        rc = FindObjectOfType<ReferenceController>();
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Debug.Log(hit.transform.name);
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);
        }
    }

    void Update()
    {
        if (this.transform.localScale.x < radius / 2f)
        {
            this.transform.localScale += Vector3.one * Time.deltaTime * explosionSpeed;
        }
        else
            Destroy(this.gameObject);
    }
}
