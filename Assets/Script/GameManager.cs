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
    public bool onCard = false;//카드 해금

    void Awake(){
        instance =this;
        StartCard();
        
    }

    void Start()
    {
        
    }
    void Update()
    {
        Spawn();
    }
    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(block, spawn_Point.transform.position, spawn_Point.transform.rotation);
        }
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


    public void StartCard(){
        


        for(int index=0; index<5; index++){
            int ran = Random.Range(0,card.Length);
            GameObject myInstance = Instantiate(card[ran], cardPar);
            if(!onCard && index==4){
                Card.instance.BlackCard();
            }

        }

        

    }
    
}
