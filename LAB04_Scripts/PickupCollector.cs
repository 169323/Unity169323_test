using UnityEngine;


public class PickupCollector : MonoBehaviour
{
    public int collectedCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            collectedCount++;
            Debug.Log("Zebrano przedmiot! Aktualna liczba: " + collectedCount);

            Destroy(other.gameObject);
        }
    }
}