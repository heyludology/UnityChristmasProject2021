using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    
    private static GameLogicManager _instance;
    public static GameLogicManager Instance { get { return _instance; } }
    private int score = 0;
    public void GiftCollected()
    {
        score += 1; //score = score + 1
        scoreText.text = "Score: " + score;
        ResetAnimations();
        StartCoroutine(BounceText());
    }

    public void GiftStole()
    {
        score -= (score > 0 ? 1 : 0);
        scoreText.text = "Score: " + (score > 0 ? score : 0);
        ResetAnimations();
        StartCoroutine(FlashText());
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private void ResetAnimations()
    {
        StopAllCoroutines();
        scoreText.color = Color.white;
        scoreText.transform.localScale = Vector3.one;
    }
    
    private IEnumerator FlashText()
    {
        for (int i = 1; i <= 6; i++)
        {
            scoreText.color = i % 2 != 0 ? Color.clear : Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator BounceText()
    {
        for (int i = 1; i < 7; i++)
        {
            bool scaleUp = i % 2 != 0;
            float scale = scaleUp ? 1.1f : 1f;
            scoreText.transform.localScale = new Vector3(scale, scale, 1);
            yield return new WaitForSeconds(0.1f);
        }

    }
}
