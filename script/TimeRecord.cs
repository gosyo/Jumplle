using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeRecord : MonoBehaviour
{
    public float Timerecord;//������ӛ�h
    public float TimeGone;//�U�^����������
    GameObject TimeRe;
    Text m_Timere;
    public static TimeRecord TimeRecordinstance;
    bool is_gameOver = false;
    GameObject wb;
    GameObject gameoverText;
    Text GameoverText;
    GameObject Point;
    Text DisPoint;//����
    GameObject target;
    GameObject m_DistanceText;
    Text distance;
    GameObject RestartG;
    Text RestartRe;
    float StartPos;
    public float Distance;��//�ƄӾ��x
    public Text HighestDistanceText;

    GameObject Jumpcount;
    Text JumpText;

    public AudioSource N_audio;
    public AudioSource W_audio;
    public AudioSource J_audio;

    public float TimePoint;
        
    private void Awake()
    {
        TimeRecordinstance = this;

    }
    void Start()
    {
        
        
        wb = GameObject.Find("wb");
        TimeRe = GameObject.Find("TimeText");
        m_Timere = TimeRe.GetComponent<Text>();
        gameoverText = GameObject.Find("GameoverText");
        GameoverText = gameoverText.GetComponent<Text>();
        Point = GameObject.Find("DistanceTextBIG");
        DisPoint = Point.GetComponent<Text>();
        RestartG = GameObject.Find("Restart");
        RestartRe = RestartG.GetComponent<Text>();
        target = GameObject.Find("wb");
        m_DistanceText = GameObject.Find("DistanceText");
        distance = m_DistanceText.GetComponent<Text>();
        StartPos = target.transform.position.y;//ʼ�k��

        Jumpcount = GameObject.Find("JumpCon");

        float highestDistance = PlayerPrefs.GetFloat("HighestDistance");
        HighestDistanceText.text = "���ӛ�h:" + Mathf.CeilToInt(highestDistance) + "m";
    }

    // Update is called once per frame
    void Update()
    {
        TimeREC();
        is_GameOver();

        if (is_gameOver)
        {
            
            wb.SetActive(false);
            GameoverText.text = "TIME IS UP!";
            DisPoint.text = distance.text + "�Ǥ�ޤ��� ";
            RestartRe.text = "SPACE�ǥ��`�����_";
            TimeRe.SetActive(false);
            m_DistanceText.SetActive(false);
            

            Jumpcount.SetActive(false); //ui���^�Ϥ��Ƥ�

            if(Input.GetButtonDown("Jump"))
                {
                ReLoadScene();
            }

            
        }

        Distance = target.transform.position.y - StartPos;
        Debug.Log(Distance);
        if (Distance >= 0)
        {
            distance.text = Mathf.CeilToInt(Distance) + "m";//�����ˤ���;������p�餵�ʤ����㤷�A����;
        }
    }

    public void TimeREC()
    {
        TimeGone = Time.deltaTime;
        Timerecord = Timerecord -  TimeGone;//�r�g
        m_Timere.text = Timerecord.ToString("F2") + "S";
    }

    public void is_GameOver()
    {

        if (Timerecord <= 0)
        {
            Timerecord = 0;
            is_gameOver = true;
           
        }
    }

    public void ReLoadScene()
    {
        float highestDistance = PlayerPrefs.GetFloat("HighestDistance");
        if (highestDistance < Distance) 
        {
            PlayerPrefs.SetFloat("HighestDistance", Distance);
        }
        SceneManager.LoadScene("main");
        
    }

    public void TimeMore()
    {
        Timerecord += TimePoint;
    }
}
