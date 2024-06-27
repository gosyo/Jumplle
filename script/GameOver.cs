using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public bool is_gameOver = false;
    GameObject gameoverText;
    Text GameOverText;
    GameObject TimeRe;

    GameObject target;
    GameObject m_DistanceText;
    Text distance;
    float StartPos;
    public float Distance; //移动距离

    GameObject Point;
    Text DisPoint;

    GameObject RestartG;
    Text RestartRe;

    GameObject Jumpcount;

    
    void Start()
    {
        gameoverText = GameObject.Find("GameoverText");
        GameOverText = gameoverText.GetComponent<Text>();
        TimeRe = GameObject.Find("TimeText");

        target = GameObject.Find("wb");
        m_DistanceText = GameObject.Find("DistanceText");
        distance = m_DistanceText.GetComponent<Text>();
        StartPos = target.transform.position.y;

        Point = GameObject.Find("DistanceTextBIG");
        DisPoint = Point.GetComponent<Text>();

        RestartG = GameObject.Find("Restart");
        RestartRe = RestartG.GetComponent<Text>();


        Jumpcount = GameObject.Find("JumpCon");

        
    }

    // Update is called once per frame
    void Update()
    {

        TimeRecord.TimeRecordinstance.TimeREC();


        if (is_gameOver)
        {
            
            GameOverText.text = "GAME OVER!";
            TimeRe.SetActive(false);
            m_DistanceText.SetActive(false);
            DisPoint.text = distance.text　+　"登りました" ;
            Jumpcount.SetActive(false);
            RestartRe.text = "SPACEでゲーム再開";
            

            if(Input.GetButtonDown("Jump"))
            {
                TimeRecord.TimeRecordinstance.ReLoadScene();
            }

           
        }

        

        Distance = target.transform.position.y - StartPos;
        Debug.Log(Distance);
        if (Distance >= 0)
        {
            distance.text = Mathf.CeilToInt(Distance)+ "m";//整数にする;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            is_gameOver = true;
            Debug.Log("gameover");
            
        }
    }

  
}
