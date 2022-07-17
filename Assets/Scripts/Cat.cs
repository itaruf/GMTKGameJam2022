using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;


public class Cat : MonoBehaviour
{
    [SerializeField] private bool _isNearPlayer;

    [SerializeField] float _kickSpeed =2.0f;
    [SerializeField] private float _xPositionLowerBound;
    [SerializeField] private float _xPositionUpperBound;
    [SerializeField] private float _yPosition;

    private Rigidbody2D _rb;

    private bool _isKicked;
    // Start is called before the first frame update
    void Start()
    {
        Event.current._onKick += CheckForKick;
        
        transform.position = new Vector3(Random.Range(_xPositionLowerBound, _xPositionUpperBound), _yPosition,0);
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isKicked)
        {
            transform.Translate(Vector3.up* _kickSpeed * Time.deltaTime);
        }
    }

    private void CheckForKick()
    {
        if (_isNearPlayer)
        {
            // Debug.Log("kicked");
            _isKicked = true;
            Event.current.CatKicked();
            StartCoroutine(KillCat());
        }
    }

    IEnumerator KillCat()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isNearPlayer = true;
        }
        
    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isNearPlayer = false;
        }
    }
}
