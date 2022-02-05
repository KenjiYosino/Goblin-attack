using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerMove : MonoBehaviour
{
    public bool examination = true;
    public float speedMove = 7f; //скорость персонажа
    [SerializeField] private Camera mainCamera;  
    //лук 
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float arrowForce = 25f;
    
    private AudioSource audioSource;
    private Vector3 moveVector3;
    private float gravityForce = 1.0f;//гравитация персонажа

    //ссылки на компоненты
    private CharacterController characterController;
    private Animator animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        LookAtMousePointer();
        CharacterMove();
        GamingGravity();
        MouseButtonDow();
    } 

    /// <summary>
    /// метод проверки и нажатия левой кнопки мыши
    /// </summary>
    private void MouseButtonDow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (examination == true)
            {                
                Attack();
            }
        }
    }
  
    /// <summary>
    /// метод слежение персонажа по направлению курсора
    /// </summary>
    private void LookAtMousePointer()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            if (examination == true)
            {
                var target = hitInfo.point;
                target.y = transform.position.y;
                transform.LookAt(target);
            }
        }   
    }
     
    /// <summary>
    /// метод премещение персонажа
    /// </summary>
    private void CharacterMove()
    {
        //перемещение по поверхности
        moveVector3 = Vector3.zero;
        moveVector3.x = Input.GetAxis("Vertical");
        moveVector3.z = Input.GetAxis("Horizontal");
        var forward = Vector3.Dot(transform.forward, moveVector3);
        var right = Vector3.Dot(transform.right, moveVector3);
        animator.SetFloat("Forward", forward);
        animator.SetFloat("Right", -right);

        moveVector3.x = moveVector3.x * speedMove;
        moveVector3.z = moveVector3.z * -speedMove;
        moveVector3.y = gravityForce;
        characterController.Move(moveVector3 * Time.deltaTime);
    }

    /// <summary>
    /// метод выстрела из лука
    /// </summary>
    private void Attack()
    {
        if(ArrowPlusText.ArrowPlus > 0)
        {
            animator.SetTrigger("Shooting");
            GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rigidbody = arrow.GetComponent<Rigidbody>();
            rigidbody.AddForce(firePoint.forward * arrowForce, ForceMode.Impulse);
            ArrowPlusText.ArrowPlus -= 1;
            audioSource.Play();
            Destroy(arrow, 2);
        }       
    }

    /// <summary>
    /// метод гравитации
    /// </summary>
    private void GamingGravity()
    {
        if (!characterController.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
    }

}
