using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public static Skill instance;
    public bool skillRange = false;
    public int skillCnt = 0;
    public bool skillStop = true;

    public Image mouse;
    public Sprite normal;
    public Sprite range;

    void Awake(){
        instance=this;
        

    }
    void Update(){

        if(Input.GetMouseButtonDown(0) && skillRange==true){
            mouse.sprite = normal;
            mouse.color = new Color(1,1,1,1f);
            mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Debug.Log("Range Skill Acivated");
            GameManager.instance.ReDraw();
            skillRange = false;
            

        }
        if(Input.GetMouseButtonDown(1) && skillRange==true ){
            mouse.sprite = normal;
            mouse.color = new Color(1,1,1,1f);
            mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Debug.Log("Range Skill Cancel");
            skillRange = false;
            skillCnt = 0;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && skillRange==true ){
            mouse.sprite = normal;
            mouse.color = new Color(1,1,1,1f);
            mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Debug.Log("Range Skill Cancel");
            skillRange = false;
            skillCnt = 0;
        }
    }

    public void OnRange(){
        if(!skillRange)
            return;
        mouse.sprite = range;
        mouse.transform.localScale += new Vector3(6.0f, 6.0f, 1.0f);
        mouse.color = new Color(1,1,1,0.5f);
        // if(skillCnt == 2){
        //     mouse.sprite = normal;
        //     mouse.color = new Color(1,1,1,1f);
        //     mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        //     Debug.Log("Range Skill Cancel");
        //     skillRange = false;
        //     skillCnt = 0;
        // }
        // else if(skillCnt == 1){
        //     mouse.sprite = range;
        //     mouse.transform.localScale += new Vector3(6.0f, 6.0f, 1.0f);
        //     mouse.color = new Color(1,1,1,0.5f);
        // }
        
       
    }

    // public void SkillStay(){
    //     mouse.sprite = normal;
    //     mouse.color = new Color(1,1,1,1f);
    //     mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //     Debug.Log("Skill Stay");
    //     skillRange = false;
    // }

    // public void SkillGo(){
    //     mouse.sprite = range;
    //     mouse.transform.localScale += new Vector3(6.0f, 6.0f, 1.0f);
    //     mouse.color = new Color(1,1,1,0.5f);
    //     Debug.Log("Skill Go");
    //     skillRange = true;
    // }

}
