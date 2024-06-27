using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FruitGenerator : MonoBehaviour
{
    public GameObject[] fruitList;
    
    void Start()
    {
        InvokeRepeating("FruitFrom", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //��������߳���
    public void FruitFrom()
    {
        float xPos = Random.Range(-3.0f, 3.0f); //x��λ��
        float ypos = Random.Range(-1.0f, 4.5f);
        float yPos = Camera.main.transform.position.y + ypos;//y��λ��
        var bornPosition =new Vector2 (xPos, yPos);//���߳���λ��
        int index = Random.Range(0, fruitList.Length);
        GameObject fruitObj = fruitList[index];
        Instantiate(fruitObj,bornPosition,fruitObj.transform.rotation);

    }
}
