﻿using UnityEngine;
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
    private bool isAlive;
    private Vector3 velo3;
    private float startTime;

    private GameObject pawplosion;


        
    void Start()
    {

        string path = "particles/pawplosion";

        pawplosion = Resources.Load(path) as GameObject;
        startTime = Time.time;
        isAlive = false;
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
        isAlive = true;


    }

    private float timepressed = 0f;

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

        // clicketyclick();
        oldjump();
    }

    void oldjump()
    {

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



            foundBoost.transform.localScale = new Vector3(0.5f, jumpPressure * 1.5f, 0.5f);
        }

    }
    void clicketyclick() {

        float x = timepressed;//(Time.time);
        float s = Mathf.Cos(x);
        float a = Mathf.Abs(s);
      //  Debug.Log(startTime);
        float movingtime = Time.time;
        if (onGround)
        {
            if (CrossPlatformInputManager.GetButton("Jump"))
            {

                timepressed = movingtime - startTime;
                if (jumpPressure < maxJumpPressure)
                {
                    jumpPressure += Time.deltaTime * 10f;
                }
                else
                {
                    jumpPressure = maxJumpPressure;
                }

            }
            else
            {
                if (jumpPressure > 0)
                {
                    jumpPressure = jumpPressure + minJump;
                    mybody.velocity = new Vector3(0, jumpPressure * a, 0);
                    jumpPressure = 0;
                    onGround = false;
                    anim.SetInteger("jumpint", 1);
                }
            }

        //    print("time cur=" + movingtime + "  timepress=" + timepressed);

            foundBoost.transform.localScale = new Vector3(0.5f, jumpPressure * 1.5f * a, 0.5f);
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

        
        if (other.tag == "wallTag" && isAlive)
        {
            anim.SetBool("hitanim", true);
            mybody.useGravity = false;
            mybody.AddTorque(new Vector3(50, 50, -500));
            mybody.velocity = new Vector3(-10, 10, 0);

        }
        else
        if (other.tag == "starTag" && isAlive)
        {
            GameManager.managerLives++;
            Destroy(other.gameObject);
        }
        else
        if (other.tag == "pawTag" && isAlive)
        {
            GameManager.mangerScore++;
            Instantiate(pawplosion, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }



    #region old


    #endregion old
}
