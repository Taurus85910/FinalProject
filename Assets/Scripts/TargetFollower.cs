using UnityEngine;

public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;
        [SerializeField] private float _speed;
        [SerializeField] private float _padding;

        private void Update()
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,
                _targetTransform.position + new Vector3(0, _padding, 0), _speed * Time.deltaTime);
        }
    }
