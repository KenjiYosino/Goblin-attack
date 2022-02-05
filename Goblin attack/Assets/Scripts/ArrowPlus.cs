using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlus : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectArrow;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ArrowPlusText.ArrowPlus += 50;
            Destroy(gameObjectArrow);
        }
    }
}
