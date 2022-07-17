using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float _movingSpeed;

    [SerializeField] private float _xPositionLowerBound;
    [SerializeField] private float _xPositionUpperBound;
    [SerializeField] private float _yPosition;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(_xPositionLowerBound, _xPositionUpperBound), _yPosition,0);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _movingSpeed *Time.deltaTime);
        CheckIfOutOfBounds();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bucket"))
        {
            Debug.Log("Collided with bucket");
        }
        else if (other.CompareTag("Ground"))
        {
            Debug.Log("Collided with Ground");
            
        }
        Destroy(gameObject);
    }

    private void CheckIfOutOfBounds()
    {
        
        if (transform.position.y < -6.0)
        {
            Destroy(gameObject);
        }
    }
}
