using UnityEngine;

    public class MouseFollower : MonoBehaviour
    {
        [SerializeField] private Vector2 _minPosition;
        [SerializeField] private Vector2 _maxPosition;
        [SerializeField] private float _zPosition;
        
        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.transform.position =
                    new Vector3(Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, _minPosition.x, _maxPosition.x),
                        Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.mousePosition).y, _minPosition.y, _maxPosition.y), _zPosition);
            }
        }
    }
