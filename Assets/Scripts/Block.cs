using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject gO;
    public Rigidbody2D rb;
    public TextMesh textMesh;

    public int health;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * 2;
    }
    void Update()
    {
        UpdateText();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (collision.gameObject.tag == "Wall")
        {
            if (transform.position.x > 0)
            {
                rb.AddForce(Vector2.left * 150f);
            }
            else 
            {
                rb.AddForce(Vector2.right * 150f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Damage(1);
        }
    }

    void Damage(int damage)
    {
        if (health > 1)
        {
            health -= damage;
        }
        else
        {
            Dead();
            Instantiate(gO, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
            Instantiate(gO, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
        }
        UpdateText();

    }
    void Dead()
    {
        Destroy(gameObject);
    }

    void UpdateText()
    {
        textMesh.text = health.ToString();
    }

}
