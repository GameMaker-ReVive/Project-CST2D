using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject spawn_Point;
    public GameObject block;
    public GameObject[] card;
    public GameObject speedUp;
    public GameObject speedReset;
    public PoolManager pool;
    public Transform cardPar;
    public Transform[] unitSpawnPoint;
    public bool isLive;
    public bool onCard = false;//카드 해금
    public Vector3 point;

    [Header("# Coin")]
    public Text costCoin;
    public Text ugCoin;
    float timer = 0f;
    int time = 0;
    public float maxGameTime;
    public float gameTime;
    //임시
    public bool enemy = false;

    void Awake(){
        instance =this;
        StartCard();
    }



    void Update()
    {
        gameTime += Time.deltaTime;
        // 플레이어 유닛 소환
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 좌클릭 한 곳의 위치값
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));

            pool.Get(0);
        }

        // 적 유닛 소환
        if (Input.GetMouseButtonDown(1))
        {
            pool.Get(1);
        }
        Coin();
    }


    
   
    public void ReDraw(){
        Transform[] childList = cardPar.GetComponentsInChildren<Transform>();
        for (int index=1; index<childList.Length; index++){
            if(childList[index] != transform){
                Destroy(childList[index].gameObject);
            }
        }
        StartCard();
    }


    public void StartCard()
    {



        for (int index = 0; index < 5; index++)
        {
            int ran = Random.Range(0, card.Length);
            GameObject myInstance = Instantiate(card[ran], cardPar);
            if (!onCard && index == 4)
            {
                Card.instance.BlackCard();
            }

        }

    }

    public void SpeedUp()
    {
        speedUp.gameObject.SetActive(false);
        speedReset.gameObject.SetActive(true);
        Time.timeScale = 2;
    }

    public void SpeedReset()
    {
        speedReset.gameObject.SetActive(false);
        speedUp.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void Stop()
    {
        isLive = false;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        isLive = true;
        Time.timeScale = 1;
    }

    void Coin(){
        //시간이 10초 경과시 마다 1에서 10사이의 코스트 획득
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            costCoin.text = (int.Parse(costCoin.text) + Random.Range(1, 11)).ToString();
            timer = 0f;
        }
       

    }

    public void EnemyCoin(string enemType){
        //죽인 개체의 등급에 따라 랜덤으로 코스트 증가
        //에너미 코드에서 죽을 때 이 함수 실행 하면 될껄?
        
            switch(enemType){
                case "nomar":
                    ugCoin.text += Random.Range(1, 5).ToString();
                    break;
                case "middle":
                    ugCoin.text += Random.Range(5, 10).ToString();
                    break;
                case "boss":
                    ugCoin.text += Random.Range(10, 15).ToString();
                    break;
            }
            
        

    }
}
