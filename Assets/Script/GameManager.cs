using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject spawn_Point;
    public GameObject block;
    public GameObject[] card;

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
    public void StartCard(){


        for(int index=0; index<4; index++){
            int ran = Random.Range(0,card.Length);
            while(card[ran].activeSelf){
                ran = Random.Range(0,card.Length);
                if(!card[ran].activeSelf){
                    card[ran].SetActive(true);
                    break;
                }
            }
            card[ran].SetActive(true);
        }

    }
}
