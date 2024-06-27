using UnityEngine;
using UnityEngine.UI;

public class PointRecord : MonoBehaviour
{
    GameObject target;
    GameObject m_DistanceText;
    Text distance;
    float StartPos;
    public float Distance; //移動距離




    void Start()
    {
        target = GameObject.Find("wb");
        m_DistanceText = GameObject.Find("DistanceText");
        distance = m_DistanceText.GetComponent<Text>();
        StartPos = target.transform.position.y;//始発点

    }


    void Update()
    {
        Distance = target.transform.position.y - StartPos;
        Debug.Log(Distance);
        if (Distance >= 0)
        {
            distance.text = Distance.ToString("F") + "m";//整数にする;数値を減らさないで足し続ける;
        }
    }
}
