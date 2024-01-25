using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyUnit : UnitBase
{
    Scanner scanner;
    Rigidbody2D rigid;
    Animator anim;

    public LayerMask attackLayer;
    Vector2 moveDir; //  ����
    Vector2 disVec; // �Ÿ�
    Vector2 nextVec; // ������ ������ ��ġ�� ��

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scanner = GetComponentInChildren<Scanner>();

        unitState = UnitState.Move;
        moveDir = Vector3.left;
    }

    void Update()
    {
        AttackRay();
    }

    void Scanner()
    {
        if (scanner.nearestTarget)
        {
            // ��ġ ���� = Ÿ�� ��ġ - ���� ��ġ
            disVec = (Vector2)scanner.nearestTarget.position - rigid.position;

            // ���� ���⿡ ���� Sprite ���� ����
            if (disVec.x > 0)
            {
                transform.localScale = new Vector3(-3f, 3f, 3f);
                moveDir = Vector2.right;
            }
            else if (disVec.x < 0)
            {
                transform.localScale = new Vector3(3f, 3f, 3f);
                moveDir = Vector2.left;
            }
        }
        else
        {
            transform.localScale = new Vector3(3f, 3f, 3f);
            disVec = Vector2.left;
        }

        // �̵�
        nextVec = disVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero; // ���� �ӵ��� MovePosition �̵��� ������ ���� �ʵ��� �ӵ� ����
        unitState = UnitState.Move;

        anim.SetInteger("AnimState", 2);
    }

    void AttackRay()
    {
        Collider2D attackTarget = Physics2D.OverlapBox(transform.position + new Vector3(moveDir.x * 1.5f, 0.6f, 0), new Vector2(1.5f, 1.2f), 0, attackLayer);

        if (attackTarget != null)
        {
            PlayerUnit targetLogic = attackTarget.gameObject.GetComponent<PlayerUnit>();

            unitState = UnitState.Fight;
            anim.SetInteger("AnimState", 0);

            gameObject.layer = 9;
        }
        else
        {
            gameObject.layer = 7;

            // AttackRay �� �νĵǴ� ������Ʈ�� ���� ���, �ٽ� ��ĵ ����
            Scanner();
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + new Vector3(moveDir.x * 1.5f, 0.6f, 0), new Vector2(1.5f, 1.2f));
    }

}
