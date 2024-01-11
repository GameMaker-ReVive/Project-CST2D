using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public static Card instance;
    public CardData card;

    
    Image img;
    void Awake(){
        instance = this;
       
        img = GetComponent<Image>();
        //Debug.Log(card.cardType);
        
        CardDraw();
    }

    public void CardDraw(){
        img.sprite= card.cardSprite;
        
    }
    public void BlackCard(){

        img.color = new Color(0,0,0);
        GetComponent<Button>().interactable = false;
    }
  
    public void SkillUsing(){
        string type = card.cardType.ToString();
        switch(type){
            case "rangeAttack":
                
                Skill.instance.skillRange = true;
                Debug.Log("RANGE SKILL ATTACK");
                GameManager.instance.ReDraw();
                break;
            case "AttackDamage":
                Debug.Log("AttackDamage");
                GameManager.instance.ReDraw();
                break;
            case "AttackSpeed":
                Debug.Log("AttackSpeed");
                GameManager.instance.ReDraw();
                break;
            case "UnitSpeed":
                Debug.Log("UnitSpeed");
                GameManager.instance.ReDraw();
                break;
            case "Defense":
                Debug.Log("Defense");
                GameManager.instance.ReDraw();
                break;
            case "Critical":
                Debug.Log("Critical");
                GameManager.instance.ReDraw();
                break;
            case "BossAttack":
                Debug.Log("BossAttack");
                GameManager.instance.ReDraw();
                break;
            case "UnitMaxHealth":
                Debug.Log("UnitMaxHealth");
                GameManager.instance.ReDraw();
                break;

            case "Heal":   
                Debug.Log("Heal");
                GameManager.instance.ReDraw();
                break;
        }

    }


}
