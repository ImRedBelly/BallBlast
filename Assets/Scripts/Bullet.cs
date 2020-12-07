using UnityEngine;

public class Bullet : MonoBehaviour
{
    float speed = 10f;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        Vector2 force = new Vector2(0, 1);
        rb.velocity = force.normalized * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(gameObject);
        }
        
    }
}
