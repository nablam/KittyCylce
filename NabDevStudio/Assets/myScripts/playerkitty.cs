using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class playerkitty : MonoBehaviour {

    private Rigidbody mybody;
    // public float speed = 6.0F;
    private float speedUpRate = 5.0f;
    private float maxJumpSpeed = 250.0F;
    private float jumpSpeed = 300.0F;
    private float dynamicJumpSpeed =10f;
    private float gravity = 98.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    public GameObject jumpBoostGO;

    void Start () {
        controller = GetComponent<CharacterController>();
        mybody = GetComponent<Rigidbody>();
	}
	
 
	void Update () {

       

       
        if (controller.isGrounded)
        {
            if (CrossPlatformInputManager.GetButton("Jump")) {
                dynamicJumpSpeed += speedUpRate;
                if (dynamicJumpSpeed >= maxJumpSpeed) dynamicJumpSpeed = maxJumpSpeed;
                Debug.Log(dynamicJumpSpeed);
                
            }
            else
            if (CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                moveDirection.y = dynamicJumpSpeed;
                dynamicJumpSpeed = 10f;
            }
            jumpBoostGO.transform.localScale = new Vector3(25, dynamicJumpSpeed, 10);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}
