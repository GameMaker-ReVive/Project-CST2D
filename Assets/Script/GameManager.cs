using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private string[] state = {"red","yellow","blue","green"};
    public GameObject bullet;
    public GameObject mob;
    public float xpoint = 3f;
    public void AttackBtn(){
        int color =  Random.Range(0, state.Length);
        string colorbullet = state[color];
        Attack(colorbullet);
    }

    private void Attack(string color){

        Vector3 point = mob.transform.position + mob.transform.right * xpoint;
        GameObject fire = Instantiate(bullet, point ,mob.transform.rotation);
        SpriteRenderer bulletRenderer = fire.GetComponent<SpriteRenderer>();

        if (bulletRenderer != null)
        {
            switch (color)
            {
                case "red":
                    bulletRenderer.color = Color.red;
                    break;
                case "yellow":
                    bulletRenderer.color = Color.yellow;
                    break;
                case "blue":
                    bulletRenderer.color = Color.blue;
                    break;
                case "green":
                    bulletRenderer.color = Color.green;
                    break;
                
            }
        }
        Rigidbody2D rigid = fire.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.right*10, ForceMode2D.Impulse);

    }



}
