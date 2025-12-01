using UnityEngine;

public class PushBall : MonoBehaviour
{
    public float pushForce = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            Vector3 direction = transform.position - collision.transform.position;
            rb.AddForce(direction.normalized * pushForce, ForceMode.Impulse);
        }
    }
}
