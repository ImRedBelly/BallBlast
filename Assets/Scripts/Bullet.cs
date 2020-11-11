using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;


    private void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        Vector2 force = new Vector2(0, 7);
        rb.velocity = force;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
