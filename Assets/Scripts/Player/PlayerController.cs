using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;  // Disable gravity
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * moveInput * moveSpeed * Time.deltaTime);
        float clampedX = Mathf.Clamp(transform.position.x, -2.5f, 2.5f); // Adjust the values based on your screen boundaries
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}