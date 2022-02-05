using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gob01Attack : MonoBehaviour
{
    [SerializeField] private Transform pointAttack;
    [SerializeField] private int damage;

    public void SearchPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(pointAttack.position, 4f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent<HealtSystem>(out var healtSystemPlayer))
            {
                healtSystemPlayer.TakingDamage(damage);
                Debug.Log("Damage");
            }
        }
    }
}


