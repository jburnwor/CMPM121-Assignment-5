using UnityEngine;
using System.Collections;

public class KnightController : MonoBehaviour 
{
	public Animator animator;
	float rotationSpeed = 30;
	Vector3 inputVec;
	Vector3 targetDirection;

    [SerializeField]
    float speed = 5;

    [SerializeField]
    float gravity = 5;

    [SerializeField]
    float jumpSpeed = 1;

    bool canMove;

    Vector3 moveDirection = Vector3.zero;

    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        canMove = true;
    }

    void Update()
	{

        //movement
        if (canMove)
        {


            //wasd movement
            if (controller.isGrounded)
            {

                moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection = moveDirection * speed;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDirection.y = jumpSpeed;
                }
            }

            //rotation
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0, -120, 0) * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.E))
            {
                transform.Rotate(new Vector3(0, 120, 0) * Time.deltaTime);
            }

            //gravity
            moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);

            //move controller
            controller.Move(moveDirection * Time.deltaTime);

            Vector3 flatMove = Vector3.Normalize(new Vector3(moveDirection.x, 0, moveDirection.z));
        }
        //Get input from controls
        float z = Input.GetAxisRaw("Horizontal");
		float x = -(Input.GetAxisRaw("Vertical"));
		inputVec = new Vector3(x, 0, z);

		//Apply inputs to animator
		animator.SetFloat("Input X", z);
		animator.SetFloat("Input Z", -(x));

		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			animator.SetBool("Moving", true);
		}
		else
		{
			//character is not moving
			animator.SetBool("Moving", false);
		}

		if (Input.GetButtonDown("Fire1"))
		{
			animator.SetTrigger("Attack1Trigger");
            canMove = false;
			StartCoroutine (COStunPause(.6f));
		}

		
	}

	public IEnumerator COStunPause(float pauseTime)
	{
		yield return new WaitForSeconds(pauseTime);
        canMove = true;
	}

	

	//Placeholder functions for Animation events
	void Hit()
	{
	}

	void FootR()
	{
	}

	void FootL()
	{
	}

}