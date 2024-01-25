using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public static Skill instance;
    public bool skillRange = false;
    public int skillCnt = 0;
    public bool skillStop1 = false;
    public bool uiMenu = false;

    [Header("# Mouse Cursor")]
    public Image mouse;
    public Sprite normal;
    public Sprite range;
    public Sprite unitPointer;
    public int mouseType = 0;


    void Awake(){
        instance=this;
        

    }
    void Update(){

        if(Input.GetMouseButtonDown(0) && skillRange==true && mouseType != 0){
            mouse.sprite = normal;
            mouse.color = new Color(1,1,1,1f);
            mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            Debug.Log("Range Skill Acivated");
            UiManager.instance.cardShop.SetActive(true);
            UiManager.instance.ReDraw();
            skillRange = false;
            skillStop1 = false;
            mouseType = 0;

        }
        if(Input.GetMouseButtonDown(0) && GameManager.instance.summonAtker == 1 && mouseType != 0){
            mouse.sprite = normal;
            mouse.color = new Color(1,1,1,1f);
            mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            GameManager.instance.SummonUnit();
            UiManager.instance.cardShop.SetActive(true);
        }

        if(Input.GetMouseButtonDown(1) && skillRange==true ){
            SkillCancel();
        }
        if(Input.GetKeyDown(KeyCode.Escape) && skillRange==true ){
            SkillCancel();
        }
    }

    public void OnRange(){
        if(skillRange == true && skillStop1 == true){
            Debug.Log("Skill Go2");
            mouse.sprite = range;
            mouse.transform.localScale = new Vector3(6.0f, 6.0f, 1.0f);
            mouse.color = new Color(1,1,1,0.5f);
            mouseType = 1;
        }
       
        
       
    }

    public void SummonSkill(){
        if(GameManager.instance.summonAtker == 1 && skillStop1 == true){
            UiManager.instance.cardShop.SetActive(false);
            Debug.Log("SommonUnit Stay");
            mouse.sprite = unitPointer;
            mouse.transform.localScale = new Vector3(3.0f, 3.0f, 1.0f);
            mouse.color = new Color(1,1,1,0.5f);
            
            mouseType = 2;
        }
        
        

    }

    public void SkillStay(){
         mouse.sprite = normal;
         mouse.color = new Color(1,1,1,1f);
         mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
         Debug.Log("Skill Stay");
         skillRange = false;
         GameManager.instance.summonAtker = 0;
        
     }

    public void SkillGo(){
        if(uiMenu)
            return;
        Debug.Log("Skill Go");
        skillRange = true;
        OnRange();
     }
    public void UnitSkillGo(){
        if(uiMenu)
            return;
        GameManager.instance.summonAtker = 1;
        SummonSkill();
    }

    public void SkillCancel(){
        mouse.sprite = normal;
        mouse.color = new Color(1,1,1,1f);
        mouse.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log("Skill Cancel");
        UiManager.instance.cardShop.SetActive(true);
        skillRange = false;
        skillCnt = 0;
        skillStop1 = false;
        GameManager.instance.summonAtker = 0;
        mouseType = 0;
    }
}
