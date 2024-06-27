using UnityEngine;
using UnityEngine.UI;

public class ChangeSide : MonoBehaviour
{
    /// <summary>
    /// ¥¸¥ã¥ó¥×µãÊý
    /// </summary>
    static int Jumpcount;
    float supercold = 3f;
    GameObject jumpCount;
    Text m_jumpCount;

    void Start()
    {

        jumpCount = GameObject.Find("JumpCon");
        m_jumpCount = jumpCount.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        supercold += Time.deltaTime;¡¡//¥¯©`¥ë¥À¥¦¥ó
        //Debug.Log(supercold);
        if (Jumpcount > 0 && Input.GetButtonDown("Jump"))
        {
            WB.wbinstance.superJump();
            Jumpcount = 0;
            supercold = 0;
            TimeRecord.TimeRecordinstance.J_audio.Play();
        }

        if (Jumpcount > 0)
        {
            m_jumpCount.text = "SPACEÑº¤·¤Æ£¡";
        }

        if (Jumpcount == 0)
        {
            m_jumpCount.text = "";
        }





    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Transform t = collision.gameObject.transform;
        t.position = new Vector3((-t.position.x) / 0.95f, t.position.y, 0f);
        if (supercold >= 3f)
        {
            Jumpcount = 1;
        }

        //Debug.Log(Jumpcount);

    }


}

