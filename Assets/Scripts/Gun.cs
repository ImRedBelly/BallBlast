using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private readonly float _speed = 12f;
    private Vector2 _startPos;

    AudioManager audioManager;
    public AudioClip shootSound;
    public Rigidbody2D rb;
    public float maxX;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        //Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mouseWorldPosition.x = Mathf.Clamp(mouseWorldPosition.x, -maxX, maxX);
        //transform.position = new Vector2(mouseWorldPosition.x, transform.position.y);

        //if (Input.GetMouseButton(0))
        //{
        //    StartCoroutine(Fire());
        //}

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

                    //case TouchPhase.Ended:
                    //    StopAllCoroutines();
                    //    break;
            }
        }
    }

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.2f);
        Instantiate(rb, transform.position, Quaternion.identity);
        StopAllCoroutines();

    }
}

