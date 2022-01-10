using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementProps : MonoBehaviour
{
    public float Speed { get; set; }

    private void OnEnable()
    {
        Speed = GetComponentInParent<SpeedProps>().Speed;
    }


    private void Update()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }

}
