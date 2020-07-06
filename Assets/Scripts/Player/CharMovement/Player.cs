using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;
    public bool isGrounded = false;

    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;

    [Header("Attacking")]
    bool isAttacking = false;


    [SerializeField]
    GameObject AttackHitBox;




    // Start is called before the first frame update
    void Start()
    {
        AttackHitBox.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Attack();

    }

    void FixedUpdate()
    {

        moveCharacter(direction.x);
        modifyPhysics();


    }


    void moveCharacter(float horizontal)
    {

        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        }
        animator.SetFloat("horizontal", Mathf.Abs(rb.velocity.x));

    }

    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
        {

            rb.drag = linearDrag;

        }
        else
        {

            rb.drag = 0f;

        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);

    }

    void Jump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded == true)
            //{

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);

        //}

        animator.SetFloat("vertical", (rb.velocity.y));

    }


    void Attack()
    {

        if (Input.GetKeyDown("c") && !isAttacking)
        {

            isAttacking = true;
            animator.Play("attack");

            //Invoke("ResetAttack", 1f);

            StartCoroutine(DoAttack());



        }



    }

    IEnumerator DoAttack()
    {

        yield return new WaitForSeconds(.2f);
        AttackHitBox.SetActive(true);
        yield return new WaitForSeconds(.2f);
        AttackHitBox.SetActive(false);
        isAttacking = false;

    }

    //void ResetAttack()
    //{

    //    isAttacking = false;

    //}


}

