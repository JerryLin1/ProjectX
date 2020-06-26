using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BulletControl : MonoBehaviourPun, IPunObservable
{
    public Rigidbody2D rb;
    void Update()
    {
        
    }

    
    void OnCollisionEnter2D(Collision2D collisionObject) {
       
        Destroy(gameObject);
        
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
