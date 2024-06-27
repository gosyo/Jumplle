using UnityEngine;

public class WB : MonoBehaviour
{
    public float MoveSpeed;
    Rigidbody2D rb;
    public float superSpeed;
    public static WB wbinstance;
    Animator m_anim =default;


    private void Awake()
    {
        wbinstance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();


    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * MoveSpeed, rb.velocity.y);


        if (h != 0)
        {
            transform.localScale = new Vector3(h, 1, 1);
        }

        if (rb.velocity.y > 0)
        {
            m_anim.Play("Jump1");
        }

       
    }

    public void superJump()
    {
        rb.velocity = Vector2.up * 18f;

    }

}
