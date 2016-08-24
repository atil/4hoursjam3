using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Stick : MonoBehaviour
{
    private Collider2D _ground;
    private float hitForce = 200f;

    void Start()
    {
        _ground = GameObject.FindWithTag("Ground").GetComponent<Collider2D>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider != null)
        {
            transform.position = hit.point;
        }

        if (Input.GetMouseButton(0))
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().AddTorque(hitForce);
        }
        if (Input.GetMouseButton(1))
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().AddTorque(-hitForce);
        }
        if (Input.GetMouseButton(2))
        {
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }
    }

}
