using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioScript : MonoBehaviour
{
    public Animator anim;
    CharacterController controller;
    public float speedInc = .01f;
    Vector3 velocity = Vector3.zero;
    float gravity = 20.0f;
    float xval;

    public float jumpSpeed = 12;
    public AudioClip soundJump;
    private Vector3 checkpoint;
    private float groundedVal;

    // Use this for initialization
    void Start()
    {
        groundedVal = 0;
        xval = 0;
        anim = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        checkpoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)
        {
            //makes sure that player is on an object.
            float val = Input.GetAxis("Horizontal");
            if (val == 0)
                xval = 0;
            else if (val > 0)
                xval += speedInc;
            else
                xval += -speedInc;
            velocity = new Vector3(val + xval, 0, 0);

            if (Input.GetAxis("Jump") > 0)
            {
                velocity.y = jumpSpeed;
                anim.SetBool("Jump", true);
                PlaySound(soundJump);
            }
            else
            {
                anim.SetBool("Jump", false);
            }
            groundedVal = .1f;
        }
        else
        {
            groundedVal-=Time.deltaTime;
            if (groundedVal < 0)
                transform.parent = null;
        }

        velocity.y -= gravity * Time.deltaTime;   //apply gravity
        controller.enabled = true;
        controller.Move(velocity * Time.deltaTime);  //move the controller
        controller.enabled = false;
        anim.SetFloat("Speed", velocity.x);
    }
    void PlaySound(AudioClip soundName)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (!audio.isPlaying || audio.clip != soundName)
        {
            audio.clip = soundName;
            audio.Play();
        }
    }

    public void ResetPos()
    {
        controller.enabled = false;
        transform.position = checkpoint;
        controller.enabled = true;
    }
    public void SetCheckpoint(Vector3 position)
    {
        checkpoint = position;
    }

    public void OnMover(Transform mover)
    {
        transform.parent = mover;
    }

}
