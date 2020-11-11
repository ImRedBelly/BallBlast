using UnityEngine;

public class Gun : MonoBehaviour
{
    public Rigidbody2D rb;

    public float maxX;

    
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, -maxX, maxX);
        transform.position = new Vector2(mousePosition.x, transform.position.y);

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Fire()
    {
        Instantiate(rb, transform.position, Quaternion.identity);
    }
}
