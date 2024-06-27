using System.Threading;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public PlatFormType platformType;
    public float bounceSpeed = 4f;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    GameObject shadow;
    Transform m_shadow;
    

    private void Start()
    {
        shadow = GameObject.Find("shadow");
        m_shadow = shadow.transform;
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        //接触点に衝突した時、そのオブジェクトの進行方向が下への時
        if (collision.contacts[0].normal == Vector2.down)
        {

            
            rb = collision.gameObject.GetComponent<Rigidbody2D>();
            sprite = collision.gameObject.GetComponent<SpriteRenderer>();

            if (rb != null)
            {

                gameObject.SetActive(false);
            }

            //Weak Platform
            if (platformType == PlatFormType.normal)
            {
                rb.velocity = Vector2.up * bounceSpeed;
                TimeRecord.TimeRecordinstance.N_audio.Play();
            }

            if (platformType == PlatFormType.weak)
            {
                TimeRecord.TimeRecordinstance.W_audio.Play();
                TimeRecord.TimeRecordinstance.TimeMore();
            }

            if (platformType == PlatFormType.strong)
            {
                rb.velocity = Vector2.up * bounceSpeed * 1.5f;
                TimeRecord.TimeRecordinstance.N_audio.Play();
            }

            if (platformType == PlatFormType.poison)
            {
                WB.wbinstance.MoveSpeed = 2.0f;
                rb.velocity = Vector2.up * bounceSpeed;
                rb.gravityScale = 4.2f;
                sprite.color = Color.green;
                Invoke("ReState1", 3.0f);
                TimeRecord.TimeRecordinstance.N_audio.Play();
            }

            if (platformType == PlatFormType.blind)
            {
                rb.velocity = Vector2.up * bounceSpeed * 3f;
                m_shadow.localPosition = new Vector3(0, 1f, 10f);
                Invoke("NoShadow", 5f);
                TimeRecord.TimeRecordinstance.N_audio.Play();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("hell"))
        {
            gameObject.SetActive(false);
        }
    }

    public void ReState1()
    {
        WB.wbinstance.MoveSpeed = 6.0f;
        sprite.color = Color.white;
        rb.gravityScale =3.2f;
    }

    public void NoShadow() 
    {
        m_shadow.localPosition = new Vector3(-8f, 2.5f, 10f);
    }
}
public enum PlatFormType
{
    normal, weak, strong, poison, blind
}

