using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController controller;
    private float horizontal, vertical;
    [SerializeField]
    public float speed = 3f;
    [SerializeField]
    public AudioSource punch;
    private Vector3 movement;
    [SerializeField]
    private Animator anima;
    private bool isAttack;
    int pos;
    public enum CharacterState
    {
        Normal, Attack
    }

    public CharacterState currentstate;

    public DameZone dameZone;
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        if (!isAttack)
        {
            isAttack = Input.GetMouseButtonDown(0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anima.SetFloat("run", 1);
            speed = 10f;
            
        }
        else
        {
            anima.SetFloat ("run", 0);
            speed = 3f;
        }
    }
    void FixedUpdate()
    {
        switch (currentstate)
        {
            case CharacterState.Normal:
                Caculalte();
                controller.Move(movement);
                break;
            case CharacterState.Attack:
                break;

             
        }
        void Caculalte()
        {
            if (isAttack)
            {
                ChangeState(CharacterState.Attack);
                anima.SetFloat("walk", 0);
                return;
            }
            movement.Set(horizontal, 0, vertical);
            movement.Normalize();
            movement = Quaternion.Euler(0, -45, 0) * movement;
            movement *= speed * Time.deltaTime;
            anima.SetFloat("walk", movement.magnitude);
            
            if (movement != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }
        }
    }

        private void ChangeState(CharacterState newState)
        {
            isAttack = false;
            switch (currentstate)
            {
                case CharacterState.Normal:
                    break;
                case CharacterState.Attack:
                    break;
            }
            switch (newState)
            {
                case CharacterState.Normal:
                    break;
                case CharacterState.Attack:
                    anima.SetTrigger("attack");
                    punch.Play();
                    break;
            }
            currentstate = newState;
        }
        public void EndAttack()
        {
            ChangeState(CharacterState.Normal);
        }
        public void beginDame()
        {
            dameZone.beginDame();
        }
        public void endDame()
        {
            dameZone.endDame();
        }
        private void OnDisable()
        {
            horizontal = 0;
            vertical = 0;
            isAttack = false;
        }
        
    }
