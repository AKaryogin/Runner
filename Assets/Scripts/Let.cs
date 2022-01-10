using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Let : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter(Collider other)
    {        
        if(other.TryGetComponent<Player>(out Player player))
            player.ApplyDamage(_damage);

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
