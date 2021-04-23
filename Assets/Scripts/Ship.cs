using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public GameObject bullet;
    public float positionX;

    private readonly float _speed = 12f;
    private Vector2 _startPos;

    void Update()
    {
        if (GameManager.instance.IsPlay)
        {
            MoveMouse();
            //MoveTouch();
        }
    }


    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(bullet, transform.position, Quaternion.identity);
        StopAllCoroutines();
    }



    private void MoveMouse()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -positionX, positionX);
        transform.position = new Vector2(mouseWorldPosition.x, transform.position.y);

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(Fire());
        }
    }
    private void MoveTouch()
    {
        if (Input.touchCount > 0)
        {
            StartCoroutine(Fire());
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _startPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    var dir = Camera.main.ScreenToWorldPoint(touch.position);
                    var pos = new Vector2(dir.x, transform.position.y);
                    transform.position = Vector2.Lerp(transform.position, pos, Time.deltaTime * _speed);
                    break;

                case TouchPhase.Ended:
                    StopAllCoroutines();
                    break;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
            GameManager.instance.GameOver();

    }
}


