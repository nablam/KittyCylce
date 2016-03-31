using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class playerKittyForce : MonoBehaviour {

    private Rigidbody mybody;
    private GameObject foundBoost;
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
                    mybody.velocity = new Vector3(0, jumpPressure, 0);
                    jumpPressure = 0;
                    onGround = false;
                }
            }
            foundBoost.transform.localScale = new Vector3(0.5f, jumpPressure, 0.5f);
        } 
    }
    void OnCollisionEnter(Collision theCollision)
    {

        if ( theCollision.gameObject.CompareTag("groundTag")) {
            onGround = true;
        
        }

        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wallTag")
        {              
                mybody.useGravity = false;
                mybody.AddTorque(new Vector3(50, 50, -500));
                mybody.velocity = new Vector3(-10, 10, 0);
            
        }
    }

    public Vector3 myposition() {
        return this.transform.position;
    }
}
