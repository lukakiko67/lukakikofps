using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float LifeTime = 3f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Note: linearVelocity is available in newer Unity versions (2023+)
        rb.linearVelocity = -transform.right * speed;

        Destroy(gameObject, LifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
