using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject giftPrefab;
    [SerializeField] private float timeToNextSpawn;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private int direction = 1;
    private bool canDropGift = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int currentDirection = direction;
        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            rb.velocity = new Vector2(speed, 0);
            direction = 1;
        } 
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, 0);
            direction = -1;
        }

        if(currentDirection != direction)
        {
            sr.flipX = !sr.flipX; 
           // if(sr.flipX == true)
           // {
           //     sr.flipX = false;
           // } else
           // {
           //     sr.flipX = true;
           // }
            
            //NOT !true = false ////   !false = true
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDropGift)
        {
           SpawnGift(transform.position);
        }
    }
    
    private void SpawnGift(Vector3 position)
    {
        Instantiate(giftPrefab, position, Quaternion.identity);
        StartCoroutine(PauseGiftSpawn());
    }
    
    IEnumerator PauseGiftSpawn()
    {
        canDropGift = false;
        yield return new WaitForSeconds(timeToNextSpawn);
        canDropGift = true;
    }
}
