using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPlust : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectHealt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<HealtSystem>(out var healtSystem1))
            {
                healtSystem1.HealtPlusPlayer();
                Destroy(gameObjectHealt);
            }
        }
    }
}
