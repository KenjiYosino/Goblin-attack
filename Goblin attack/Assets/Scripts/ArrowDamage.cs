using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            transform.LookAt(other.transform);
            if (other.TryGetComponent<Gob01Health>(out var enemyHealth))
            {
                enemyHealth.TakingDamageGoblin();
            }
        }
    }
}
