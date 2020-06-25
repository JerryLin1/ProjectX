using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerControl : MonoBehaviourPun, IPunObservable
{
    private float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public PhotonView pv;
    Vector2 movement;

    void Start()
    {
        if (pv.IsMine)
        {
            Camera.main.GetComponent<CameraFollow>().setTarget(gameObject.transform);
        }
    }
    void Update()
    {
        checkInput();
    }

    void FixedUpdate()
    {
        Move();
    }
    void checkInput()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void Move()
    {
        if (pv.IsMine)
        {
            rb.velocity = movement * movementSpeed;
            if (movement.x != 0 || movement.y != 0)
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
        if (rb.velocity.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(rb.velocity);
        }
        else if (stream.IsReading)
        {
            rb.velocity = (Vector2)stream.ReceiveNext();
        }
    }
}
