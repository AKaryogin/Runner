using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedProps : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _boostSpeed;
    [SerializeField] private float _secondsForUpSpeed;

    private float _elapsedTime = 0;
    private MovementProps[] _movementProps;

    public float Speed => _speed;


    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _secondsForUpSpeed)
        {
            _elapsedTime = 0;

            _speed += _boostSpeed;

            AlignSpeed();
        }
                
    }

    private void AlignSpeed()
    {
        _movementProps = GetComponentsInChildren<MovementProps>();

        for(int i = 0; i < _movementProps.Length; i++)
        {
            if(_movementProps[i].enabled == true)
                _movementProps[i].Speed = _speed;
        }
    }
}
