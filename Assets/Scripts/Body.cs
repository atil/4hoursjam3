using UnityEngine;
using System.Collections;

public class Body : MonoBehaviour
{
    private ExplosionForce _explosionForce;
    private bool _isExploded;

    void Start()
    {
        _explosionForce = FindObjectOfType<ExplosionForce>();
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.GetComponent<Stick>() != null)
        {
            var stickRigidbody = col.collider.GetComponent<Rigidbody2D>();
            _isExploded = true;
            _explosionForce.upliftModifer = stickRigidbody.angularVelocity / 50;
            _explosionForce.hitNormal = col.contacts[0].normal;
            _explosionForce.doExplosion(col.contacts[0].point);
            GetComponent<Explodable>().generateFragments();
            GetComponent<Explodable>().explode();

            stickRigidbody.angularVelocity = -stickRigidbody.angularVelocity / 2;
            FindObjectOfType<Ui>().OnScore();
            //FindObjectOfType<Ui>().Screenshake();
        }
    }

    void Update()
    {
        if (!_isExploded)
        {
            transform.Translate(-transform.position * 1 * Time.deltaTime);
        }
    }
}
