using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementInput : MonoBehaviour
{
    [SerializeField] private MovementPlayer _movementPlayer;

    private Vector3 _startSwipe;    

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _startSwipe = Input.mousePosition;        

        if(Input.GetMouseButtonUp(0))
        {            
            if(_startSwipe.x < Input.mousePosition.x)
                _movementPlayer.MoveRight();
            else
                _movementPlayer.MoveLeft();
        }

    }
}
