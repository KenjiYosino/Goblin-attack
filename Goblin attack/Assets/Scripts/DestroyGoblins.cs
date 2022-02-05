using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGoblins : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectGob;
    
    private void DestroyGoblin()
    {
        Destroy(gameObjectGob);
    }
}
