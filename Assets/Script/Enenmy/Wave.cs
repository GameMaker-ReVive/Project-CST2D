using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject elfEnemy;
    float timeWave = 0f;
    void Update(){
        Summons();
    }

    public void Summons(){
        timeWave += Time.deltaTime;

        if(timeWave >= 10f ){
            int ran = Random.Range(5,11);
            for(int i=0; i<ran; i++){
                PoolManager.instance.Get(1);
                Debug.Log("SummonsEnemy");
            }

            timeWave =0f;

        }
    }

}
