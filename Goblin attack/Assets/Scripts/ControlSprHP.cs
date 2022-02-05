using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSprHP : MonoBehaviour
{
    [SerializeField] private Image[] lives;
    
    public void CallSprHP(int numberOfLives)
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < numberOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }
        }
    }
}
