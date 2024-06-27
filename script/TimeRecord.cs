using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeRecord : MonoBehaviour
{
    public float Timerecord;//タイム記録
    public float TimeGone;//経過したタイム
    GameObject TimeRe;
    Text m_Timere;
    public static TimeRecord TimeRecordinstance;
    bool is_gameOver = false;
    GameObject wb;
    GameObject gameoverText;
    Text GameoverText;
    GameObject Point;
    Text DisPoint;//点数
    GameObject target;
    GameObject m_DistanceText;
    Text distance;
    GameObject RestartG;
    Text RestartRe;
    float StartPos;
    public float Distance;　//移動距離
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
        StartPos = target.transform.position.y;//始発点

        Jumpcount = GameObject.Find("JumpCon");

        float highestDistance = PlayerPrefs.GetFloat("HighestDistance");
        HighestDistanceText.text = "最高記録:" + Mathf.CeilToInt(highestDistance) + "m";
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
            DisPoint.text = distance.text + "登りました ";
            RestartRe.text = "SPACEでゲーム再開";
            TimeRe.SetActive(false);
            m_DistanceText.SetActive(false);
            

            Jumpcount.SetActive(false); //uiを頭上に移す

            if(Input.GetButtonDown("Jump"))
                {
                ReLoadScene();
            }

            
        }

        Distance = target.transform.position.y - StartPos;
        Debug.Log(Distance);
        if (Distance >= 0)
        {
            distance.text = Mathf.CeilToInt(Distance) + "m";//整数にする;数値を減らさないで足し続ける;
        }
    }

    public void TimeREC()
    {
        TimeGone = Time.deltaTime;
        Timerecord = Timerecord -  TimeGone;//時間
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
