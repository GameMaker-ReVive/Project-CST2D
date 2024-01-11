using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public static Skill instance;
    public bool skillRange = false;
    public GameObject cusor;
    void Awake(){
        instance=this;

    }

}
