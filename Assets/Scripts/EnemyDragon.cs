using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDragon : MonoBehaviour
{
    [Header("Set in Inspector")]

    public GameObject DragonEggPrefab;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _timeBetweenEggDrops = 1.0f;
    [SerializeField] private float _leftRightDistance = 10.0f;
    [SerializeField] private float _chanseDiraction = 0.01f;

    private void Start()
    {
        Invoke("dropEgg", 2f);
    }



    private void Update()
    {
        leftRightTranslate();

    }
    private void FixedUpdate()
    {
        randomDiraction();
    }
    private void leftRightTranslate()
    {
        Vector3 _position = transform.position;
        _position.x += _speed * Time.deltaTime;
        transform.position = _position;

        if (_position.x < -_leftRightDistance)
        {
            _speed = Mathf.Abs(_speed);
        }
        else if (_position.x > _leftRightDistance)
        {
            _speed = -Mathf.Abs(_speed);
        }
    }
    private void randomDiraction()
    {
        if (Random.value < _chanseDiraction)
        {
            _speed *= -1;
        }
    }
    private void dropEgg()
    {
        Vector3 myVector = new Vector3(0.0f, 5.0f, 0.0f);
        GameObject egg = Instantiate<GameObject>(DragonEggPrefab);
        egg.transform.position = transform.position + myVector;
        Invoke("dropEgg", _timeBetweenEggDrops);
    }
}
