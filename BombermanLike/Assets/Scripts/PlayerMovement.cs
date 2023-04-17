using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private KeyCode _left, _right, _up, _down;
    [SerializeField]
    private float _speed;

    private Rigidbody2D rgbd;

    private void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetKey(_left))
        {
            transform.position += Vector3.left * _speed * Time.deltaTime;
        }
        if (Input.GetKey(_right))
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
        if (Input.GetKey(_up))
        {
            transform.position += Vector3.up * _speed * Time.deltaTime;
        }
        if (Input.GetKey(_down))
        {
            transform.position += Vector3.down * _speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rgbd.velocity = Vector2.zero;
    }
}
