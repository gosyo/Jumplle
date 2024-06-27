using UnityEngine;
using UnityEngine.UI;

public class PointRecord : MonoBehaviour
{
    GameObject target;
    GameObject m_DistanceText;
    Text distance;
    float StartPos;
    public float Distance; //�ƄӾ��x




    void Start()
    {
        target = GameObject.Find("wb");
        m_DistanceText = GameObject.Find("DistanceText");
        distance = m_DistanceText.GetComponent<Text>();
        StartPos = target.transform.position.y;//ʼ�k��

    }


    void Update()
    {
        Distance = target.transform.position.y - StartPos;
        Debug.Log(Distance);
        if (Distance >= 0)
        {
            distance.text = Distance.ToString("F") + "m";//�����ˤ���;������p�餵�ʤ����㤷�A����;
        }
    }
}
