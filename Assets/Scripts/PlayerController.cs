using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Animator anim;
    public GameObject enlargeParticle;

    [Header("Scale")]
    public Vector3 shrinkScale;
    public Vector3 enlargeScale;
    public Vector3 baseScale;

    [Header("Timers")]
    public float shrinkTimer;
    public Image shrinkTimerUI;
    public float enlargeTimer;
    public Image enlargeTimerUI;
    public float enlargeCountdown;
    public bool isShrinking;
    public bool isEnlarged;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = false;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;

        PlayerScale();
        Timers();
    }
    void FixedUpdate()
    {
        PlayerMovement();
    }

    public void PlayerMovement()
    {
        //WASD Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * verticalInput + transform.right * horizontalInput;
        transform.Translate(move * Time.deltaTime * moveSpeed);
    }


    public void PlayerScale()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !isEnlarged && shrinkTimer >= 0)
        {
            Debug.Log("Shrink");
            anim.Play("player_shrink");
            //transform.localScale = shrinkScale;
            isEnlarged = false;
            isShrinking = true;
        }
        else if (Input.GetKey(KeyCode.Mouse1) && !isShrinking && enlargeTimer >= 3)
        {
            Debug.Log("Enlarge");
            //transform.localScale = enlargeScale;
            enlargeParticle.SetActive(false);
            enlargeParticle.SetActive(true);
            anim.Play("player_enlarge");
            isShrinking = false;
            isEnlarged = true;
        }
        else
        {
            //transform.localScale = baseScale;
            //anim.Play("Empty");
            enlargeCountdown = 1.5f;
            isShrinking = false;
            isEnlarged = false;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isShrinking = false;
            anim.Play("player_shrinkReverse");
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            //anim.Play("player_enlargeReverse");
            enlargeCountdown = 1.5f;
            isEnlarged = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1) && enlargeTimer >= 3)
        {
            enlargeTimer = 0;
            anim.Play("player_enlargeReverse");
            isEnlarged = false;
        }
    }

    public void Timers()
    {
        //UI
        shrinkTimerUI.fillAmount = shrinkTimer / 5;
        enlargeTimerUI.fillAmount = enlargeTimer / 3;

        //Shrink Timer
        if (isShrinking)
        {
            shrinkTimer = shrinkTimer - Time.deltaTime;
            if (shrinkTimer <= 0)
            {
                isShrinking = false;
                shrinkTimer = 0;
                anim.Play("player_shrinkReverse");
                //transform.localScale = baseScale;
            }
        }
        else
        {
            shrinkTimer = shrinkTimer + Time.deltaTime;
            if (shrinkTimer >= 5)
            {
                shrinkTimer = 5;
            }
        }

        //Enlarge Timer
        if (enlargeTimer <= 3)
        {
            enlargeTimer = enlargeTimer + Time.deltaTime;
            if(enlargeTimer >= 3)
            {
                enlargeTimer = 3;
            }
        }

        if (isEnlarged)
        {
            enlargeCountdown = enlargeCountdown - Time.deltaTime;
            if (enlargeCountdown <= 0)
            {
                //enlargeCountdown = 1.5f;
                //transform.localScale = baseScale;
                anim.Play("player_enlargeReverse");
                enlargeParticle.SetActive(false);
                enlargeTimer = 0;
                enlargeCountdown = 1.5f;
                isEnlarged = false;
            }
        }
    }
}
