using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{   Text myText;

    private void Awake() {
        myText = GetComponent<Text>();
    }
    void LateUpdate(){

        float remainTime = GameManager.instance.maxGameTime - GameManager.instance.gameTime;
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        myText.text = string.Format("{0:D2}:{1:D2}", min, sec);
    
    }

}
