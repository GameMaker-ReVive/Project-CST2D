using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spawn_Point;
    public GameObject block;
    void Start()
    {
        
    }
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(block, spawn_Point.transform.position, spawn_Point.transform.rotation);
        }
    }
}
