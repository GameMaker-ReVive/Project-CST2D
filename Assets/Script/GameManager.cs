using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject spawn_Point;
    public GameObject block;
    public GameObject speedUp;
    public GameObject speedReset;
    public bool isLive;
    public void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }
    void Spawn()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(block, spawn_Point.transform.position, spawn_Point.transform.rotation);
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
