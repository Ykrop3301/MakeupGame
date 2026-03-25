using UnityEngine;

namespace MakeupGame.Gameplay.PlayerInteraction
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseTool : MonoBehaviour
    {
        private Camera _mainCamera;
        private Vector3 _offset;
        private float _distanceFromCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            Debug.Log("Started");
        }

        private void OnMouseDown()
        {
            Debug.Log("YOY");
            _distanceFromCamera = _mainCamera.WorldToScreenPoint(transform.position).z;

            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            _offset = transform.position - mouseWorldPosition;
        }

        private void OnMouseDrag()
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();

            transform.position = mouseWorldPosition + _offset;
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mousePoint = Input.mousePosition;
            mousePoint.z = _distanceFromCamera;
            return _mainCamera.ScreenToWorldPoint(mousePoint);
        }
    }
}
