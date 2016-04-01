using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
public class playerKittyForce : MonoBehaviour {

    private Animator anim;
    private bool onGround;
    private Rigidbody mybody;
    private GameObject foundBoost;
    private float jumpPressure;
    private float minJump;
    private float maxJumpPressure;

    private Vector3 velo3;
    void Start()
    {
     
        anim = gameObject.GetComponentInChildren<Animator>();
        anim.SetBool("hitanim", false);
        onGround = true;
        jumpPressure = 0f;
        minJump = 2f;
        maxJumpPressure = 10f;
        mybody = GetComponent<Rigidbody>();
        gameObject.GetComponent<CapsuleCollider>().height = 3.4f;
        foundBoost = GameObject.Find("JumpPower");
        StartCoroutine("C1");
    }


    IEnumerator C1()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        mybody.useGravity = false;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        mybody.useGravity = true;


    }

    void FixedUpdate()
    {
        if (playerIsOutOfBound()) {
            GameManager.managerLives--;
            Destroy(this.gameObject);
            GameManager.managerMakePlayer();
        }

        velo3 = mybody.velocity;
      
        if (this.anim.GetCurrentAnimatorStateInfo(0).IsName("pashaApex"))
        {
            gameObject.GetComponent<CapsuleCollider>().height = 1.5f;
        }
        else
            gameObject.GetComponent<CapsuleCollider>().height = 3.4f;
        anim.SetFloat("apexparam", velo3.y);

 

        if (onGround)
        {
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
                if (jumpPressure > 0)
                {
                    jumpPressure = jumpPressure + minJump;
                    mybody.velocity = new Vector3(0, jumpPressure, 0);
                    jumpPressure = 0;
                    onGround = false;
                    anim.SetInteger("jumpint", 1);
                }
            }
       

                foundBoost.transform.localScale = new Vector3(0.5f, jumpPressure*1.5f, 0.5f);
        }
    }


    bool playerIsOutOfBound( )
    {

        if (transform.position.y > 12 || transform.position.y < -5) return true;
        else
        if (transform.position.x > 18 || transform.position.x < -20) return true;
        else
        if (transform.position.z > 2 || transform.position.z < -4) return true;
        else
            return false;
    }

    void OnCollisionEnter(Collision theCollision)
    {

        if (theCollision.gameObject.CompareTag("groundTag"))
        {
            onGround = true;


        }


    }

    void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == "wallTag")
        {
            anim.SetBool("hitanim", true);
            mybody.useGravity = false;
            mybody.AddTorque(new Vector3(50, 50, -500));
            mybody.velocity = new Vector3(-10, 10, 0);

        }
        else
        if (other.tag == "starTag")
        {
            GameManager.managerLives++;
            Destroy(other.gameObject);

        }
    }



    #region old

    /*


    
    enum State { Alive, Dead,  Invincible , Playing }
    private State Playerstate;

    private float blinkRate = .1f;
    private int numberOfTimeToBlink = 12;
    private int blinkCount;


    public int TotalLives;
    private SkinnedMeshRenderer pashacubeSkinMesh;
    void Start()
    {
        Playerstate = State.Playing;
        TotalLives = 3;


        pashacubeSkinMesh = this.transform.GetChild(1).GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public Vector3 FrameVelocity { get; set; }
    public Vector3 PrevPosition { get; set; }
    void Update()
    { 
   

      
    }
 

    public Vector3 myposition() {
        return this.transform.position;
    }

*/
    #endregion old
}
