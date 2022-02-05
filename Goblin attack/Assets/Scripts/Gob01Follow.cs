using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gob01Follow : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Animator animator;
    private int state;

    private void Start()
    {    
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        state = ChangeState();
        State();
    }

    /// <summary>
    /// метод изменения состояний действий
    /// </summary>
    /// <returns></returns>
    private int ChangeState()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 1f)
            {
                return 2;
            }
            if (distance < 15f)
            {
                return 1;
            }
        }
        return 0;
    }

    /// <summary>
    /// метод действия при определонном состоянии
    /// </summary>
    private void State()
    {
        switch (state)
        {
            case 0:
                animator.SetBool("Run", false);
                speed = 0;
                break;
            case 1:
                PlayerPursuit();
                break;
            case 2:
                Attack();
                break;
        }
    }

    /// <summary>
    /// метод преследование 
    /// </summary>
    private void PlayerPursuit()
    {
        AudioStart();
        speed = 4;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.LookAt(player);
        animator.SetBool("Run", true);
    }

    /// <summary>
    /// метод атаки
    /// </summary>
    private void Attack()
    {
        speed = 0;
        transform.LookAt(player);
        animator.SetBool("Run", false);
        animator.SetTrigger("Attack");
    }

    private void AudioStart()
    {
        if (gameObject.TryGetComponent<AudioSource>(out var audioSource))
        {
            audioSource.Play();
        }
    }
}
