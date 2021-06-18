using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    [SerializeField]private GameObject spawnTarget = null;
    [SerializeField]private float spawnRate = 0;
    [SerializeField]private float spawnTime = 0;
    private bool _stopSpawning;
    private Player _player;
    
    private void Start()
    {
        _player = (Player)FindObjectOfType(typeof(Player));
        _player.onDestroyed.AddListener(StopSpawning);
        InvokeRepeating("SpawnObject", spawnTime, spawnRate);
    }

    private void StopSpawning()
    {
        _stopSpawning = true;
    }
    
    private void SpawnObject()
    {
        if (_stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
        else
        {
            Instantiate(spawnTarget, transform.position, transform.rotation);
        }
    }
}
