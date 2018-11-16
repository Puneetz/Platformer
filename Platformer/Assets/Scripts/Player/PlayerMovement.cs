namespace Scripts.Player
{
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        public PlayerController PlayerController;

        public Animator PlayerAnimator;

        public float Speed = 40.0f;

        private float _horizontalMovement;

        private bool _jump;

        private bool _crouch;

        public void OnLand()
        {
            PlayerAnimator.SetBool("IsJumping", false);
        }

        public void OnCrouchChanged(bool isCrouching)
        {
            PlayerAnimator.SetBool("IsCrouching", isCrouching);
        }

        private void Update()
        {
            _horizontalMovement = Input.GetAxisRaw("Horizontal") * Speed;

            PlayerAnimator.SetFloat("Speed", Mathf.Abs(_horizontalMovement));

            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
                PlayerAnimator.SetBool("IsJumping", true);
            }

            if (Input.GetButtonDown("Crouch"))
            {
                _crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                _crouch = false;
            }
        }

        private void FixedUpdate()
        {
            PlayerController.Move(_horizontalMovement * Time.fixedDeltaTime, _crouch, _jump);
            _jump = false;
        }
    }
}