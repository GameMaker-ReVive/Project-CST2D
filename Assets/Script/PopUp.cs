using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    public GameObject pop;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Show()
    {
        pop.gameObject.SetActive(true);
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        pop.gameObject.SetActive(false);
        GameManager.instance.Resume();
    }
}
