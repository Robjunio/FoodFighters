using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public delegate void Action();
    public static event Action Attack;

    public LifeController LifeController;

    public Animator animator;
    public Rigidbody2D rb;
    private Vector2 inputMovement;
    public float playerSpeed;

    public float baseComboDiffTimmer;
    private int baseComboCount;
    private float baseComboTimmer;

    public float rollCooldown;
    private float rollCooldownCount;

    private bool WaitForEndCombo;
    private bool canRoll = true;

    private void OnAttack()
    {
        Attack?.Invoke();
    }

    private void ReadInput()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        inputMovement = new Vector2(x,y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!canRoll)
            {
                return;
            }
            animator.SetTrigger("Roll");
            canRoll = false;
            rollCooldownCount = 0;
            ResetCombo();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if (WaitForEndCombo) return;
            baseComboCount++;
            animator.SetTrigger("Punch" + baseComboCount.ToString());
            baseComboTimmer = 0;
            OnAttack();
            if (baseComboCount > 2) {
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
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        } 
        else if (inputMovement.x < 0)
        {
            transform.localScale = new Vector3(-1.3f, 1.3f, 1.3f);
        }

        animator.SetFloat("Magnitude", inputMovement.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance != null)
        {
            if (!GameManager.instance.GameStarted)
            {
                return;
            }
        }

        if (LifeController.isDead) return;

        if (rollCooldownCount > rollCooldown)
        {
            canRoll = true;
        }
        else
        {
            rollCooldownCount += Time.deltaTime;
        }

        if(baseComboDiffTimmer < baseComboTimmer)
        {
            ResetCombo();
        }
        else
        {
            baseComboTimmer += Time.deltaTime;
        }
        ReadInput();

        Animate();
    }

    private void ResetCombo()
    {
        baseComboCount = 0;

        animator.ResetTrigger("Punch1");
        animator.ResetTrigger("Punch2");
        animator.ResetTrigger("Punch3");
        animator.ResetTrigger("HeavyPunch");

        WaitForEndCombo = false;
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
