using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Laser : MonoBehaviour
{
    [SerializeField] private static float _movingSpeed = 2.0f;
    [SerializeField] float _speedBonus = 0.1f;
    [SerializeField] private float _xPositionLowerBound;
    [SerializeField] private float _xPositionUpperBound;
    [SerializeField] private float _yPosition;

    [SerializeField] GameObject circle = null;
    GameObject groundMark = null;
    [SerializeField] Vector3 groundMarkOffset = new Vector3(0, -2.8f);

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        var random = Random.Range(_xPositionLowerBound, _xPositionUpperBound);
        transform.position = new Vector3(random, _yPosition, 0);

        groundMark = Instantiate(circle);
        groundMark.transform.position = new Vector3(random, groundMarkOffset.y, 0);

       TryGetComponent(out _rb);

        Event.current._onHalfWayMinGame += SpeedUp;
    }
    private void SpeedUp()
    {
        _movingSpeed += _speedBonus;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _movingSpeed * Time.deltaTime);
        CheckIfOutOfBounds();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Event.current.OnGameLost();
            Debug.Log("Collided with player");
        }

        /* else if (other.CompareTag("Ground"))
             Event.current.OnGameLost();*/

        Destroy(groundMark);
        Destroy(gameObject);

        SpeedUp();
    }

    private void CheckIfOutOfBounds()
    {

        if (transform.position.y < -6.0)
        {
            Destroy(gameObject);
        }
    }
}
