using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceController : MonoBehaviour {
    public Ball ballPrefab;
    public Explosion explosionPrefab;
    public Formation formationPrefab;

    public UIController UIc;

    public Cannon cannon;

    public void MakeExplosionAt (Vector3 explosionPos)
    {
        Instantiate(explosionPrefab, new Vector3 (explosionPos.x, explosionPos.y + 1f, explosionPos.z), Quaternion.identity);
    }
}
