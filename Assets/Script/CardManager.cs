using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardManager : MonoBehaviour
{
    Vector3 pos;
    void Awake(){
        pos = this.transform.position;
    }
    void Update(){
        //CusorY();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Skill.instance.SkillStay();
        Debug.Log("Stay");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Skill.instance.SkillGo();
        Debug.Log("Go");
    }

    void CusorY(){
        if(Skill.instance.skillCnt == 0)
            return;

        if(pos.y >=450 || pos.y <= -370){
            //Skill.instance.SkillStay();
            Skill.instance.skillStop = false;
            Debug.Log("Stay");
        }
        else if(pos.y <450 || pos.y > -370){
            //Skill.instance.SkillGo();   
            Skill.instance.skillStop = true;
            Debug.Log("Go");
        }
    }
   
}
