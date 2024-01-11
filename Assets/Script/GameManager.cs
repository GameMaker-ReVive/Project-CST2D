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
    public Transform cardPar;
    public GameObject speedUp;
    public GameObject speedReset;
    public bool isLive;
    public bool onCard = false;//카드 해금

    void Awake(){
        instance =this;
        StartCard();
        
    }

    void Start()
    {
        
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
}
