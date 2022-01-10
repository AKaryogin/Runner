using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _stepSize;
    [SerializeField] private float _borderLeft;
    [SerializeField] private float _borderRight;

    private Vector3 _targetPosition;    

    private void Start()
    {
        _targetPosition = transform.position;        
    }

    private void Update()
    {
        if(transform.position != _targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    public void MoveLeft()
    {
        if(_targetPosition.x > _borderLeft)
            Move(-_stepSize);
    }

    public void MoveRight()
    {
        if(_targetPosition.x < _borderRight)
            Move(_stepSize);
    }

    private void Move(float stepSize)
    {        
        _targetPosition = new Vector3(_targetPosition.x + stepSize, _targetPosition.y, _targetPosition.z);
    }
}
