using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private Player _player;
    private Rocket _rocket;

    private float _speed;
    private float _distance;
    private float _distanceToExplode;
    private int _damage;
    private bool _gameOver;
    private void Start()
    {
        _player = (Player)FindObjectOfType(typeof(Player));
        _rocket = (Rocket) FindObjectOfType(typeof(Rocket));
        _speed = GetComponent<Rocket>().FlySpeed;
        _distanceToExplode = GetComponent<Rocket>().DistanceToExplode;
        _damage = GetComponent<Rocket>().Damage;
        _player.onDestroyed.AddListener(StopMoving);
        Destroy(gameObject, 8f);//Destroys rocket 8 seconds after it spawns in order to make game more interesting
    }
    private void Move()
    {
        transform.LookAt(_player.transform);
        transform.position += transform.forward * _speed * Time.deltaTime;
        transform.Rotate(90f ,0f ,0f);
    }

    private void StopMoving()
    { 
        _gameOver = true;
        Destroy(gameObject);
    }
    private void Update()
    {
        if(!_gameOver)
        {
            Move();
            _distance = Vector3.Distance(_player.transform.position, transform.position);
            if (_distance < _distanceToExplode)
            {
                Debug.Log("BOOM!");
                _rocket.DealDamage(_damage, _player);
                Destroy(gameObject);
            }
        }
    }
}
