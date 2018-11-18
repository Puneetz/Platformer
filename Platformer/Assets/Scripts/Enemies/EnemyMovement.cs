namespace Scripts.Enemies
{
    using System;
    using System.Linq;

    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5.0f;

        private Transform _patrolEndpoint;

        private Rigidbody2D _rigidBody;

        private Vector2 _startPosition;

        private Vector2 _endPosition;

        private float _startTime;

        private float _journeyLength;

        private void Awake()
        {
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _patrolEndpoint = gameObject.GetComponentsInChildren<Transform>().Single(childTransform => childTransform.name == "PatrolEndpoint");

            _startPosition = new Vector2(_rigidBody.position.x, 0.0f);
            _endPosition = new Vector2(_patrolEndpoint.position.x, 0.0f);
        }

        private void Start()
        {
            BeginMovement();
        }

        private void Update()
        {
            {
                float distanceCovered = _speed * (Time.time - _startTime);
                float journeyFraction = distanceCovered / _journeyLength;

                _rigidBody.position = new Vector2(Vector2.Lerp(_startPosition, _endPosition, journeyFraction).x, _rigidBody.position.y);
            }

            if (Math.Abs(_rigidBody.position.x - _endPosition.x) < 0.01)
            {
                transform.Rotate(0.0f, 180.0f, 0.0f);

                Vector2 newStart = _endPosition;
                _endPosition = _startPosition;
                _startPosition = newStart;

                BeginMovement();
            }
        }

        private void BeginMovement()
        {
            _startTime = Time.time;
            _journeyLength = Vector3.Distance(_startPosition, _endPosition);
        }
    }
}