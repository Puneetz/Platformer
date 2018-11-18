namespace Scripts.Enemies
{
    using UnityEngine;

    public class EnemyCollision : MonoBehaviour
    {
        private Animator _animator;

        private Rigidbody2D _rigidBody;

        private CapsuleCollider2D _capsuleCollider;

        private EnemyMovement _movement;

        public void OnDeathAnimationFinished()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
            _movement = gameObject.GetComponent<EnemyMovement>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.relativeVelocity.y < 0.0f && collision.gameObject.CompareTag("Player"))
            {
                Destroy(_rigidBody);
                Destroy(_capsuleCollider);
                Destroy(_movement);

                _animator.SetBool("IsDead", true);
            }
        }
    }
}