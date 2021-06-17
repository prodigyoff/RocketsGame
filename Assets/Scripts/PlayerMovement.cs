using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private float _distance;

    private void Start()
    {
        _speed = GetComponent<Player>().MovementSpeed;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        transform.position += direction * _speed * Time.deltaTime;
        if ( direction.sqrMagnitude > 0 ) transform.forward = direction;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15f, 15f),
            transform.position.y, Mathf.Clamp(transform.position.z, -8f, 8f)); // Bounds should be done using colliders if we could use them
    }
}
