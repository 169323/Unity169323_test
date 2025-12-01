using UnityEngine;

// baza https://github.com/SamuelAsherRivello/physics-for-unity


public class RaycastDemo : MonoBehaviour
{
    [SerializeField]
    private bool _isDebug = true;

    [SerializeField]
    private float _rayDistance = 3;

    [SerializeField]
    private float _rayDuration = 0.1f;

    private Ray _ray;
    private Vector3 _rayPosition;
    private RaycastHit _raycastHit;

    private CharacterController playerController;

    void Start()
    {
        _ray = new Ray();
        _ray.direction = Vector3.down;

        playerController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        _ray.origin = transform.position;
        _ray.direction = Vector3.down;

        if (_isDebug == true)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _rayDistance, Color.red, _rayDuration);
        }

        Physics.Raycast(_ray, out _raycastHit, _rayDistance);

        if (_raycastHit.collider != null)
        {
            Debug.Log("Colliding with: " + _raycastHit.collider.gameObject.name);

            MovingPlatform mp = _raycastHit.collider.GetComponent<MovingPlatform>();
            if (mp != null)
            {
                Vector3 platformMove = mp.velocity * Time.deltaTime;
                playerController.Move(platformMove);
                if (_isDebug)
                    Debug.Log("Stojê na platformie: " + mp.name);
            }
        }
    }
}
