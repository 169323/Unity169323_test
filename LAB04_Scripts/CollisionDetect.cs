using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected");
        Debug.Log(collision.gameObject.name);
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("Collision Detected");
        Debug.Log(collision.gameObject.name);
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision Detected");
        Debug.Log(collision.gameObject.name);
    }

}