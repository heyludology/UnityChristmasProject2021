using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollect : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gift"))
        {
            Destroy(collision.gameObject);
            if (CompareTag("GoodElf"))
            {
                GameLogicManager.Instance.GiftCollected();    
            }
            else
            {
                GameLogicManager.Instance.GiftStole();
            }
        }   
    }
}
