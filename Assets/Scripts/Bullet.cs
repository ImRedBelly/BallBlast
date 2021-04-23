using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float damagePoint = 1f;


    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            collision.GetComponent<Block>().GetDamage(damagePoint);
            Destroy(gameObject);
        }
    }
}
