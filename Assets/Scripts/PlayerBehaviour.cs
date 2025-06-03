using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting.APIUpdating;

public class PlayerBehaviour : MonoBehaviour
{
    public float speedmove = 1f;
    public float jumpForce = 2f;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        Map1();
        Map2();
        Map3();
    }

    public void Map1()
    {
        if (SceneManager.GetActiveScene().name == "Map 1")
        {
            rb.linearVelocity = new Vector2(speedmove, rb.linearVelocity.y);
            if (Input.GetMouseButtonDown(0) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }
    }

    public void Map2()
    {
        if (SceneManager.GetActiveScene().name == "Map 2")
        {
            float x = Input.GetAxis("Horizontal");
            rb.linearVelocity = new Vector2(x * speedmove, rb.linearVelocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }
    }

    //Map 3:
    public void Map3()
    {
        if (SceneManager.GetActiveScene().name == "Map 3")
        {
            Move3();
        }
    }

    public void Move3()
    {
        float speed = 5f;
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * Time.deltaTime;
        this.transform.position += movement;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                break;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
