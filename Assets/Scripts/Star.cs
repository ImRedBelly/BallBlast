using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    AudioManager audioManager;
    GameManager gameManager;

    public AudioClip sound;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ship"))
    //    {
    //        audioManager.PlaySound(sound);
    //        gameManager.AddScore(5);
    //        gameManager.AddHealth(1);
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            audioManager.PlaySound(sound);
            gameManager.AddScore(5);
            gameManager.AddHealth(1);
            Destroy(gameObject);
        }
    }
}
