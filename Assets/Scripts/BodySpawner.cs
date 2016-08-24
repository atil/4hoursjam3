using UnityEngine;
using System.Collections;

public class BodySpawner : MonoBehaviour
{
    public GameObject BodyPrefab;

    private float _timer;
    
    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > 2)
        {
            Instantiate(BodyPrefab, Random.insideUnitCircle * Random.Range(5f, 8f), Quaternion.identity);
            _timer = 0;
        }
    }
}
