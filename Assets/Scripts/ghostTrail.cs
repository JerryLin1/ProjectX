using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostTrail : MonoBehaviour
{
    SpriteRenderer ghostLeaderSr;
    SpriteRenderer childSr;
    float timer = 0.5f;
    float opacity = 0.5f;
    float opacityDecrease;
    void Start()
    {
        childSr = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>();
        opacityDecrease = opacity/timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        opacity -= opacityDecrease*Time.deltaTime;
        if (timer <= 0) Destroy(gameObject);
        childSr.color = new Color(1f,1f,1f,opacity);
    }
    public void setGhostLeaderSr(SpriteRenderer sr) {
        childSr = gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<SpriteRenderer>();
        ghostLeaderSr = sr;
        childSr.sprite = ghostLeaderSr.sprite;
    }

}