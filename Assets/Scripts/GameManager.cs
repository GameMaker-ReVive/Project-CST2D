using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PoolManager pool;

    public Transform[] unitSpawnPoint;

    public Vector3 point;

    [Header("# Unit Setting")]
    public int summonAtker = 0;

    void Awake()
    {
        instance = this;
    }

    
    void Update()
    {
       
    }

    public void SummonUnit(){
        
       
        if (summonAtker == 1)
        {
            
            point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                Input.mousePosition.y, -Camera.main.transform.position.z));

            pool.Get(0);
            UiManager.instance.ReDraw();
            Skill.instance.mouseType = 0;
            summonAtker = 0;
        }

       
        if (Input.GetMouseButtonDown(0) && summonAtker == 5)
        {
            pool.Get(0);
            
        }
    }
}
