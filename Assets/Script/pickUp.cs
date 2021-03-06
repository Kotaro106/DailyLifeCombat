﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickUp : MonoBehaviour
{
    public Transform theDest;
    public Transform theDest2;
    Rigidbody rb;
    public float speed;
    GameObject hpGage;
    GameObject hpGage2;
    public float damage;

    //追加
    public AudioClip holdSE;
    public AudioClip throwSE;

    AudioSource aud;

    bool touch=false;
    bool touch2 = false;

    void Start()
    {
        this.hpGage = GameObject.Find("hpgage");
        this.hpGage2 = GameObject.Find("hpgage2");

        rb = GetComponent<Rigidbody>();

        //new
        this.aud = GetComponent<AudioSource>();

    }
    void Update()
    {
      
        if (Input.GetKeyDown("r")||Input.GetKeyDown(KeyCode.Joystick2Button2))
        {
            this.rb.useGravity = true;
            this.rb.isKinematic=false;
            this.transform.parent = null;
        }


        if (this.transform.position == theDest.position)
        {
            touch = true;
            if (Input.GetMouseButtonDown(0))
            {
                this.transform.parent = null;
                this.rb.useGravity = true;
                this.rb.isKinematic = false;
                this.rb.AddForce(transform.forward * speed);

                //new
                this.aud.PlayOneShot(this.throwSE);
            }
        }

        if (this.transform.position == theDest2.position)
        {
            touch2 = true;
            if (Input.GetKeyDown(KeyCode.Joystick2Button15))
            {
                this.transform.parent = null;
                this.rb.useGravity = true;
                this.rb.isKinematic = false;
                this.rb.AddForce(transform.forward * speed);

                //new
                this.aud.PlayOneShot(this.throwSE);
            }
        }


        if (this.transform.position.y < 0)
        {
            Destroy(gameObject);
        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (touch==true)
        {
            if (collision.gameObject.name == "enemy")
            {
                //GameObject director = GameObject.Find("GameDirector");
                //director.GetComponent<GameDirector>().DecreaseHp2();
                this.hpGage2.GetComponent<Image>().fillAmount -= damage;
            }
        }

        if (touch2 == true)
        {
            if (collision.gameObject.name == "unitychan")
            {
                //GameObject director = GameObject.Find("GameDirector");
                //director.GetComponent<GameDirector>().DecreaseHp();
                this.hpGage.GetComponent<Image>().fillAmount -= damage;
            }
        }
    }


}
