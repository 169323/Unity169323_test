using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;
    public float speed = 2f;

    [HideInInspector] public Vector3 delta;
    private Vector3 lastPos;

    // raycastDemo
    [HideInInspector] public Vector3 velocity;

    void Start()
    {
        lastPos = transform.position;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null) rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(Time.time * speed, 1f));
        delta = transform.position - lastPos;
        velocity = delta / Time.deltaTime;
        lastPos = transform.position;

    }
}
