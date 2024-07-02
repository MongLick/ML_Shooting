using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] CharacterController controller;
    [SerializeField] Animator animator;

    [Header("Spec")]
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpSpeed;

    private Vector3 moveDir;
    private float ySpeed;

	private void Update()
	{
		Move();
        JumpMove();
	}

	private void OnMove(InputValue value)
    {
        Vector2 inputDir = value.Get<Vector2>();
        moveDir.x = inputDir.x;
        moveDir.z = inputDir.y;
    }

    private void OnJump(InputValue value)
    {
        if(controller.isGrounded)
        {
			ySpeed = jumpSpeed;
		}
    }

    private void Move()
    {
        // 이건 보고 있는 방향이 아님
        // controller.Move(moveDir * moveSpeed * Time.deltaTime);

        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
		controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", moveDir.magnitude * moveSpeed);
	}

    private void JumpMove()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if(controller.isGrounded)
        {
            ySpeed = 0;
        }

        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }
}
