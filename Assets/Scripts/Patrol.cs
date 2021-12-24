using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Animator anim;

    private GameObject[] moveSpots;
    private SpriteRenderer sp;
    private float timeToNextMovement;
    private int randomSpot;

    int direction = 1;

    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        moveSpots = GameObject.FindGameObjectsWithTag("PatrolPoint");
        randomSpot = Random.Range(0, moveSpots.Length);
        var initialPosition = moveSpots[randomSpot].transform.position;
        transform.position = new Vector2(initialPosition.x, initialPosition.y);
        timeToNextMovement = 2;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    
    private void HandleMovement()
    {
        Transform targetPosition = moveSpots[randomSpot].transform;
        transform.position = Vector2.MoveTowards(transform.position, 
            targetPosition.position, 
            speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition.position) < 0.2f)
        {
            if (timeToNextMovement <= 0)
            {
                int randomSpotIndex = Random.Range(0, moveSpots.Length);
                while(randomSpot == randomSpotIndex)
                {
                    randomSpotIndex = Random.Range(0, moveSpots.Length);
                }
                randomSpot = randomSpotIndex;
                timeToNextMovement = Random.Range(0.5f, 2f);

                Transform nextPosition = moveSpots[randomSpot].transform;
                if(transform.position.x > nextPosition.position.x) //I will move to the left
                {
                    direction = -1;
                } else //I will move to the right
                {
                    direction = 1;
                }

                if(direction == 1)
                {
                    sp.flipX = false;
                }
                else
                {
                    sp.flipX = true;
                }
                anim.SetBool("isWalking", true);
            }
            else  //2-1/60-1/60-1/60 = 0
            {
                timeToNextMovement -= Time.deltaTime; // 1/60 60fps = 1sec: 1/60  1-1-1-1-1-111111111
                anim.SetBool("isWalking", false);
            }
        }
    }
}
