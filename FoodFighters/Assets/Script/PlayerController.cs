using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 inputMovement;
    public float playerSpeed;

    private void ReadInput()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        inputMovement = new Vector2(x,y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Roll");
            rb.AddForce(inputMovement.normalized * playerSpeed * 100, ForceMode2D.Impulse);
        }
    }

    private void Move()
    {
        rb.velocity = inputMovement.normalized * playerSpeed;
    }

    private void Animate()
    {
        animator.SetFloat("Magnitude", inputMovement.magnitude);

        animator.SetFloat("DirX", inputMovement.x);
        animator.SetFloat("DirY", inputMovement.y);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();

        Animate();
    }

    private void FixedUpdate()
    {
        Move();
    }
}
