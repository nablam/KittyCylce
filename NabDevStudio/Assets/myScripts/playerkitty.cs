using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class playerkitty : MonoBehaviour {

    private Rigidbody mybody;
    // public float speed = 6.0F;
    private float jumpPowerBuildCoefficient = 8.0f;
    private float maxJumpSpeed = 500.0F;
    //private float jumpSpeed = 300.0F;
    private float dynamicJumpSpeed =10f;
    private float gravity = 300.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private GameObject foundBoost;

    
    public GameObject jumpBoostGO;

    void Start () {
        controller = GetComponent<CharacterController>();
        mybody = GetComponent<Rigidbody>();
        foundBoost = GameObject.Find("JumpPower");
    }

    public Vector3 FrameVelocity { get; set; }
    public Vector3 PrevPosition { get; set; }
    void Update () {
        Vector3 currFrameVelocity = (transform.position - PrevPosition) / Time.deltaTime;
        FrameVelocity = Vector3.Lerp(FrameVelocity, currFrameVelocity, 0.8f);
        PrevPosition = transform.position;

      //  Debug.Log(FrameVelocity);
       // if (FrameVelocity.y < -10) {Debug.Log("Falling"); }
       // if (FrameVelocity.y > -9 && FrameVelocity.y < 10) { Debug.Log("nothing"); }
       // if (FrameVelocity.y > 10) Debug.Log("JUMPING");

      


        if (controller.isGrounded)
        {
            if (CrossPlatformInputManager.GetButton("Jump")) {
                dynamicJumpSpeed += jumpPowerBuildCoefficient;
                if (dynamicJumpSpeed >= maxJumpSpeed) dynamicJumpSpeed = maxJumpSpeed;
               // Debug.Log(dynamicJumpSpeed);
                
            }
            else
            if (CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                moveDirection.y = dynamicJumpSpeed;
                dynamicJumpSpeed = 10f;
            }
            foundBoost.transform.localScale = new Vector3(25, dynamicJumpSpeed, 10);
        }
        moveDirection.y -= gravity * Time.deltaTime* 1.5f;
        if (controller.enabled)
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnTriggerEnter(Collider theCollision)
    {

        if (theCollision.tag == "wallTag")
        {
           // Debug.Log("hit a wall");

           // CharacterController cc = GetComponent<CharacterController>();
            controller.enabled = false;
            //Rigidbody gameObjectsRigidBody = GetComponent<Rigidbody>(); // Add the rigidbody.
            //gameObjectsRigidBody.mass = 5;
            mybody.mass = 1;
            mybody.AddTorque(new Vector3(50, 50, 50));
            mybody.AddForce(new Vector3(-1000, 1000, 0));

        }



    }

}
