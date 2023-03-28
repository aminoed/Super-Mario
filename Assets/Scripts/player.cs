using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Vector2 move;
    public Vector2 input;
    [Header("属性")]
    public float speed;
    public int life, bonus=0;
    public bool isHurt;
    private GameObject pickObject;
    private GameObject objectGen;
    private GameObject mario;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        objectGen = GameObject.Find("objectManager");
        mario = GetComponent<Transform>().gameObject;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        if (move.x < 0)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
        rb.velocity = input.normalized * speed;
        SwitchAnim();
         dead();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }

    void SwitchAnim()
    {
        anim.SetFloat("speed", move.magnitude);
    }

    public void dead()
    {
        if (life <= 0)
        {
            // rb.velocity = Vector2.zero;
            AudioController.instance.LoseAudio();
            objectGen.SetActive(false);
            ObjectPool.Instance.PushObject(mario);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("bonus"))
        {
            pickObject = other.collider.gameObject;
            ObjectPool.Instance.PushObject(pickObject);
            AudioController.instance.BonusAudio();
            bonus++;
        }
        else if (other.collider.CompareTag("rock"))
        {
            pickObject = other.collider.gameObject;
            AudioController.instance.HurtAudio();
            ObjectPool.Instance.PushObject(pickObject);
            life--;
        }
        objectGen.GetComponent<objectManager>().RemoveFromList(other.collider.gameObject);
    }

}


