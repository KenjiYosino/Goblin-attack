using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtSystem : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    private int numberOfLives = 3;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
   
    public void TakingDamage(int damage)
    {
        if (numberOfLives <= 3)
        {
            Debug.Log("HP");
            numberOfLives -= damage;
            animator.SetTrigger("DamagePlayer");
            ControlSprHP controlSprHP = GetComponent<ControlSprHP>();
            if (controlSprHP != null)
            {
                controlSprHP.CallSprHP(numberOfLives);
            }
        }
        if(numberOfLives <= 0)
        {
            animator.SetBool("Die", true);
            gameOver.SetActive(true);
            ControllerPlayerMove controllerPlayerMove = GetComponent<ControllerPlayerMove>();
            controllerPlayerMove.speedMove = 0;
            controllerPlayerMove.examination = false;
            Time.timeScale = 0f;
        }          
    }
    
    public void HealtPlusPlayer()
    {
        if (numberOfLives <= 3)
        {
            numberOfLives += 1;
            if (TryGetComponent<ControlSprHP>(out var controlSprHP))
            {
                controlSprHP.CallSprHP(numberOfLives);
            }
        }
    }
}
