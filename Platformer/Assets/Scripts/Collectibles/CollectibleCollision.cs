using UnityEngine.UI;

namespace Scripts.Collectibles
{
    using UnityEngine;
    using Scripts;

    public class CollectibleCollision : MonoBehaviour
    {
        private Animator _gemAnimator;
        private ScoreScript _scoreScript;
        [SerializeField]
        private Text _text;
        

        public void OnDestroyAnimationFinished()
        {
            _scoreScript.ScoreIncrease(10);
            Destroy(gameObject);
        }

        private void Awake()
        {
            _gemAnimator = gameObject.GetComponent<Animator>();
            _scoreScript = _text.GetComponent<ScoreScript>();
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