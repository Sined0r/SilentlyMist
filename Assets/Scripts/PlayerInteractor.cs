using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _hand;

    private void Update()
    {
        Vector3 origin = _camera.transform.position;
        Vector3 direction = _camera.transform.forward;
        Debug.DrawRay(origin, direction * 1000);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(origin, direction, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Takable takable))
                {
                    TakeInHand(takable);
                }
            }
        }
    }

    private void TakeInHand(Takable tackable)
    {
        tackable.gameObject.transform.parent = _hand;
        tackable.transform.localPosition = Vector3.zero;
        tackable.transform.localRotation = Quaternion.identity;
    }
}
