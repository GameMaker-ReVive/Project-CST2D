using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject block;
    public GameObject[] card;
    public GameObject speedUp;
    public int gameSpeed = 1;
    public Text speedText;
    public GameObject speedReset;
    [Header("#Card")]
    public Transform cardPar;
    public bool onCard = false;//ī�� �ر�
    public GameObject cardShop;
    public GameObject shop;
    private bool shopUp = true;
    private float shopTime;
    public float duration = 1f;
    private Vector3 startPosition;
    private Vector3 targetPosition;

    [Header("# Coin")]
    public Text costCoin;
    public Text ugCoin;
    float timer = 0f;
    int time = 0;
    //�ӽ�
    public bool enemy = false;

    void Awake()
    {
        instance = this;
        StartCard();
    }



    void Update()
    {
        Coin();
        ShopDown();
    }



    public void ReDraw()
    {
        Transform[] childList = cardPar.GetComponentsInChildren<Transform>();
        for (int index = 1; index < childList.Length; index++)
        {
            if (childList[index] != transform)
            {
                Destroy(childList[index].gameObject);
            }
        }
        StartCard();
    }


    public void StartCard()
    {



        for (int index = 0; index < 3; index++)
        {
            int ran = Random.Range(0, card.Length);
            GameObject myInstance = Instantiate(card[ran], cardPar);
            // if (!onCard && index == 4)
            // {
            //     Card.instance.BlackCard();
            // }

        }

    }

    public void SpeedUp()
    {
        gameSpeed += 1;
        if (gameSpeed >= 4)
            gameSpeed = 1;
        switch (gameSpeed)
        {
            case 1:
                Time.timeScale = 1;
                speedText.text = "X1";
                Debug.Log("nomarSpeed");
                break;
            case 2:
                Time.timeScale = 2;
                speedText.text = "X2";
                Debug.Log("highSpeed");
                break;
            case 3:
                Time.timeScale = 3;
                speedText.text = "X3";
                Debug.Log("hyperSpeed");
                break;
        }

    }

    public void SpeedReset()
    {
        speedReset.gameObject.SetActive(false);
        speedUp.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void Stop()
    {
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    void Coin()
    {
        //�ð��� 10�� ����� ���� 1���� 10������ �ڽ�Ʈ ȹ��
        timer += Time.deltaTime;

        if (timer >= 10f)
        {
            costCoin.text = (int.Parse(costCoin.text) + Random.Range(1, 11)).ToString();
            timer = 0f;
        }


    }

    public void EnemyCoin(string enemType)
    {
        //���� ��ü�� ��޿� ���� �������� �ڽ�Ʈ ����
        //���ʹ� �ڵ忡�� ���� �� �� �Լ� ���� �ϸ� �ɲ�?

        switch (enemType)
        {
            case "nomar":
                ugCoin.text += Random.Range(1, 5).ToString();
                break;
            case "middle":
                ugCoin.text += Random.Range(5, 10).ToString();
                break;
            case "boss":
                ugCoin.text += Random.Range(10, 15).ToString();
                break;
        }



    }
    public void ShopDown()
    {
        if(shopUp==false) shopTime += Time.deltaTime;

        if(shopTime >= 6f && !shopUp)
        {
            startPosition = shop.transform.position;
            targetPosition = startPosition + Vector3.down * 140; // 시작 위치에서 y축으로 100만큼 이동한 위치
            StartCoroutine(MoveShop());
            shopUp = true;
            shopTime = 0;
            Debug.Log("down");
        }
    }
    public void ShopUp()
    {
        if (!shopUp)
            return;

        Debug.Log("up");
        startPosition = shop.transform.position;
        targetPosition = startPosition + Vector3.up * 140; // 시작 위치에서 y축으로 100만큼 이동한 위치
        StartCoroutine(MoveShop());
        shopUp = false;

    }
    IEnumerator MoveShop()
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            shop.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsed / duration);
            yield return null;
        }

        // 이동 완료 후 최종 위치를 보정
        shop.transform.position = targetPosition;
    }
}
