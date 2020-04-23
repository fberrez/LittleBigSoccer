using UnityEngine;
using Mirror;

public class Ball : NetworkBehaviour
{
    private Rigidbody2D rb;

    public int speed = 30;

    public override void OnStartServer()
    {
        base.OnStartServer();

        rb = GetComponent<Rigidbody2D>();

        // only simulate ball physics on server
        rb.simulated = true;

        // Serve the ball from left player
        rb.velocity = Vector2.right * speed;
    }
}
