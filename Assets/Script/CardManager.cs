using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardManager : MonoBehaviour
{
    

    private void OnMouseEnter() {
        Skill.instance.SkillStay();
        Debug.Log("Stay");
    }
    private void OnMouseExit() {
        Skill.instance.SkillGo();
        Debug.Log("Go");
    }

    

    
   
}
