﻿using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour
{
    private ExplosionForce _explosionForce;

    void Start()
    {
        _explosionForce = FindObjectOfType<ExplosionForce>();
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<Stick>() != null)
        {
            _explosionForce.upliftModifer = col.relativeVelocity.magnitude * 2;
            _explosionForce.hitNormal = col.contacts[0].normal;
            _explosionForce.doExplosion(col.contacts[0].point);
            GetComponent<Explodable>().generateFragments();
            GetComponent<Explodable>().explode();
        }
    }
}
