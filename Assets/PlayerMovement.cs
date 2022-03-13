using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jump_speed;
    [SerializeField] private float speed;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask SpikeLayer;
    [SerializeField] LayerMask finishLine;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private bool grounded;
    private bool Touching;
    private int rotation;

    // Run when start running
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        body.velocity = new Vector2(speed, body.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jump_speed);
        }
        if (!isGrounded())
        {
            rotation++;
            //transform.rotation = Quaternion.Euler(new Vector3(0,0,-rotation));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.velocity = new Vector2(body.velocity.x, -jump_speed);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (body.velocity.x == 0)
        { 
            SceneManager.LoadScene(0);

        }
        if (isSpike())
        {
            SceneManager.LoadScene(0);
        }
        if (isTouching() && !isGrounded())
        {
            SceneManager.LoadScene(0);
        }
        if (hasWon())
        {
            SceneManager.LoadScene(3);
        }


    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool hasWon()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, finishLine);
        return raycastHit.collider != null;
    }
    private bool isSpike()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, SpikeLayer);
        return raycastHit.collider != null;
    }
    private bool isTouching()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
