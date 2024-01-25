using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardManager1 : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Skill.instance.SkillStay();
        Debug.Log("Stay");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(Skill.instance.mouseType==1){
            Skill.instance.SkillGo();
        }else if(Skill.instance.mouseType==2){
            Skill.instance.UnitSkillGo();
        }
        
    
        Debug.Log("Exit");
    }

    public void SelectCancel(){
        Skill.instance.SkillCancel();
    }

  

    public void GameContunue(){
        if(Skill.instance.mouseType==1){
            Skill.instance.SkillGo();
        }
        else if(Skill.instance.mouseType==2){
            Skill.instance.UnitSkillGo();
        }
        Debug.Log("GameReStart");
    }
    

    
   
}
