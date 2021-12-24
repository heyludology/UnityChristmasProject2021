using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GiftBrain : MonoBehaviour
{
    [SerializeField] Sprite[] giftImages; //["image-08","image-09","image-10"]
    [SerializeField] private float destroyTime;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, 3);
        sr.sprite = giftImages[index];
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject, destroyTime);
        }   
    }
}
