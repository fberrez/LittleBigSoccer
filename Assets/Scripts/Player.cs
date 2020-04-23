using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
            Vector3 targetVelocity = new Vector2(horizontalMovement, verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
    }

}
