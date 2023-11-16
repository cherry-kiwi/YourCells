using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class ImPanel : MonoBehaviour
{
    Vector2 boxSize = new Vector2(2f, 0.5f);
    Vector2 boxSize2 = new Vector2(0.5f, 2f);
    Vector2 boxCenter;
    Collider2D[] H_colliders;
    Collider2D[] V_colliders;

    Collider2D self;
    


    private void Start()
    {
        self = GetComponent<Collider2D>(); //�� �ڽ� �˱�

        #region �� �����¿� �ڽ� ã��
        boxCenter = transform.position;
        H_colliders = Physics2D.OverlapBoxAll(boxCenter, boxSize, 0.0f);
        V_colliders = Physics2D.OverlapBoxAll(boxCenter, boxSize2, 0.0f);
        #endregion
    }


    public List<Transform> Fidn_Route()
    {
        List<Transform> _All = new List<Transform>(); //������� ����Ʈ ����

        #region ã�� �����¿� �ڽ��� ���� ������ / self�� ã�� �� �ڽ��� ����
        for (int l = 0; l < H_colliders.Length; l++)
        {
            if (H_colliders[l].gameObject != gameObject
                && H_colliders[l].gameObject.tag == "Square"
                || H_colliders[l].gameObject.tag == "EndPoint")
            {
                _All.Add(H_colliders[l].transform); 
            }
        }

        for (int l = 0; l < V_colliders.Length; l++)
        {
            if (V_colliders[l].gameObject != gameObject
                && V_colliders[l].gameObject.tag == "Square"
                || V_colliders[l].gameObject.tag == "EndPoint")
            {
                _All.Add(V_colliders[l].transform);
            }
        }
        #endregion

        if (gameObject.tag == "Square")
        {
            self.tag = "selected"; //�� �ڽ��� ���� �� �� �ǵ��ư��°� ����
        }
        return _All;
    }
}
