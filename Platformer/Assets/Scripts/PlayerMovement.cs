using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Player;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Player.AddForce(new Vector2(0.0f, 50.0f));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Player.AddForce(new Vector2(0.0f, -50.0f));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Player.AddForce(new Vector2(-50.0f, 0.0f));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            Player.AddForce(new Vector2(50.0f, 0.0f));
        }
    }
}