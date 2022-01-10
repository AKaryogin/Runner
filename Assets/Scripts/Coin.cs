using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {       
        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
