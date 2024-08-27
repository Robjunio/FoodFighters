using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 inputMovement;
    public float playerSpeed;

    public float baseComboDiffTimmer;
    public int baseComboCount;
    public float baseComboTimmer;

    public bool WaitForEndCombo;

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

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (WaitForEndCombo) return;
            baseComboCount++;
            animator.SetTrigger("Punch" + baseComboCount.ToString());
            baseComboTimmer = 0;
            if(baseComboCount > 2) {
                WaitForEndCombo = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.K)) {
            if (WaitForEndCombo) return;
            baseComboCount++;
            animator.SetTrigger("HeavyPunch");
            baseComboTimmer = 0;
            WaitForEndCombo = true;
        }
    }

    private void Move()
    {
        rb.velocity = inputMovement.normalized * playerSpeed;
    }

    private void Animate()
    {
        if(inputMovement.x > 0)
        {
            transform.localScale = Vector3.one;
        } 
        else if (inputMovement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1,1);
        }

        animator.SetFloat("Magnitude", inputMovement.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        if(baseComboDiffTimmer < baseComboTimmer)
        {
            baseComboCount = 0;

            animator.ResetTrigger("Punch1");
            animator.ResetTrigger("Punch2");
            animator.ResetTrigger("Punch3");
            animator.ResetTrigger("HeavyPunch");

            WaitForEndCombo = false;
        }
        else
        {
            baseComboTimmer += Time.deltaTime;
        }
        ReadInput();

        Animate();
    }

    private void FixedUpdate()
    {
        if (baseComboCount > 0)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        Move();
    }
}
