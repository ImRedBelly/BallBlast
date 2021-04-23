using UnityEngine;

public class Star : MonoBehaviour
{
    int scorePoint = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ship"))
        {
            GameManager.instance.AddPoint(scorePoint);
            Destroy(gameObject);
        }
    }
}
