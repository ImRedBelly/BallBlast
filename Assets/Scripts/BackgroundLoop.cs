using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject background;
    public Material material;
    float speed = 0.1f;

    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        material.mainTextureOffset = offset;
    }
}
