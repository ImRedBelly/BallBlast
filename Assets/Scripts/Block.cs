using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject spawnObject;
    public Rigidbody2D rb;
    public TextMesh textMesh;

    public float health;
    public float jumpForce;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Down")
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            return;
        }


        if (collision.gameObject.tag == "Wall")
        {
            if (transform.position.x > 0)
                rb.AddForce(Vector2.left * 150f);

            else
                rb.AddForce(Vector2.right * 150f);
        }
    }

    

    public void AddForce()
    {

    }

    public void GetDamage(float damagePoint)
    {
        if (health > 1)
        {
            health -= damagePoint;
            textMesh.text = health.ToString();
        }
        else
        {
            if (spawnObject)
            {
                Instantiate(spawnObject, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                Instantiate(spawnObject, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
