namespace Scripts.Collectibles
{
    using UnityEngine;

    public class GemCollision : MonoBehaviour
    {
        private Animator _gemAnimator;

        public void OnDestroyAnimationFinished()
        {
            Destroy(gameObject);
        }

        private void Awake()
        {
            _gemAnimator = gameObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _gemAnimator.SetBool("IsCollected", true);
            }
        }
    }
}