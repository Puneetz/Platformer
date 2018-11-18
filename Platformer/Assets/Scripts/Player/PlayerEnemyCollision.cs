namespace Scripts.Player
{
    using UnityEngine;

    public class PlayerEnemyCollision : MonoBehaviour
    {
        private PlayerController _playerController;

        private Rigidbody2D _rigidBody;

        private void Awake()
        {
            _playerController = gameObject.GetComponent<PlayerController>();
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.relativeVelocity.y > 0.0f && collision.gameObject.CompareTag("Enemy"))
            {
                _rigidBody.AddForce(new Vector2(0.0f, _playerController.JumpForce));
            }
        }
    }
}