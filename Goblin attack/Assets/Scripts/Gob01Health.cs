using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gob01Health : MonoBehaviour
{
    [SerializeField] private int numberOfLives;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
  
    public void TakingDamageGoblin()
    {
        if (numberOfLives <= 4)
        {
            numberOfLives -= 1; 
        }
        if (numberOfLives <= 0)
        {
            animator.SetTrigger("DeathGoblin");
            ScoreManager.score += 1;
            Gob01Follow enemyFollow = GetComponent<Gob01Follow>();
            if (enemyFollow != null)
            {
                enemyFollow.speed = 0;
            }
        }
    }
}
