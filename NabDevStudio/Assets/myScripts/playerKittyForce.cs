using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class playerKittyForce : MonoBehaviour {

    private Rigidbody mybody;
    // public float speed = 6.0F;
    private float jumpPowerBuildCoefficient = 8.0f;
    private float maxJumpSpeed = 500.0F;
    //private float jumpSpeed = 300.0F;
    private float dynamicJumpSpeed = 10f;
    private float gravity = 300.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    private GameObject foundBoost;


    public GameObject jumpBoostGO;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;

    private bool onGround;

    void Start()
    {
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;

        mybody = GetComponent<Rigidbody>();
        foundBoost = GameObject.Find("JumpPower");
    }

    public Vector3 FrameVelocity { get; set; }
    public Vector3 PrevPosition { get; set; }
    void Update()
    { 
        if (this.transform.position.x < -100)
        {
            Destroy(this.gameObject);
        }


        if (onGround) {
            if (CrossPlatformInputManager.GetButton("Jump"))
            {
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }
                //print(jumpPressure);
            }
            else
            {
                if (jumpPressure > 0) {
                    jumpPressure = jumpPressure + minJump;
                    mybody.velocity = new Vector3(jumpPressure/10f, jumpPressure, 0);
                    jumpPressure = 0;
                    onGround = false;

                }
            }
        }
 
          // 
        
       //     if (CrossPlatformInputManager.GetButtonUp("Jump"))
           
 
    }

    void OnTriggerEnter(Collider theCollision)
    {

        if (theCollision.tag == "groundTag") {
            onGround = true;
            print("on ground");
        }



            if (theCollision.tag == "wallTag")
        {
            // Debug.Log("hit a wall");

            // CharacterController cc = GetComponent<CharacterController>();
          //  controller.enabled = false;
            //Rigidbody gameObjectsRigidBody = GetComponent<Rigidbody>(); // Add the rigidbody.
            //gameObjectsRigidBody.mass = 5;
            mybody.mass = 1;
            mybody.AddTorque(new Vector3(50, 50, 50));
            mybody.AddForce(new Vector3(-1000, 1000, 0));

        }



    }
}
