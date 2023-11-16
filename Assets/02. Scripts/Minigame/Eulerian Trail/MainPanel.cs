using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class MainPanel : MonoBehaviour
{
    private RaycastHit hit;
    private Camera cam;

    [SerializeField] private Transform[] Row;

    private List<Transform> _Spuare = new List<Transform>();

    [SerializeField] private List<Transform> _Able = new List<Transform>();
    [SerializeField] private Stack<GameObject> Fail_Reset = new Stack<GameObject>();



    private void Start()
    {
        cam = GetComponent<Camera>();

        #region 벽 제외 모든 타일값 받아오기 in : Transfrom _Square
        foreach (Transform rowTransform in Row)
        {
            int childCount = rowTransform.childCount;

            for (int i = 0; i < childCount; i++)
            {
                Transform child = rowTransform.GetChild(i);

                if (child.tag == "Square")
                {
                    _Spuare.Add(child);
                }
            }
        }
        #endregion
    }

    private void Update()
    {
        if (Input.touchCount > 0) 
        {
            Touch toto = Input.GetTouch(0);

            #region 현재 클릭된 오브젝트 in : Collider2D clickCol
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 clickPos = new Vector2(worldPos.x, worldPos.y);
            Collider2D clickCol = Physics2D.OverlapPoint(clickPos);
            #endregion

            if (toto.phase == TouchPhase.Began && clickCol != null)
            {
                if (clickCol.tag == "Square")
                {
                    clickCol.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
                    
                    clickCol.TryGetComponent(out ImPanel wall);
                    _Able = wall.Fidn_Route(); //_able에 현재 클릭된 녀석 기준 상하좌우 가져오기
                    Fail_Reset.Push(clickCol.gameObject);
                } else
                {
                    Debug.Log("다른 곳에서 시작");
                }
            }

            if (toto.phase== TouchPhase.Moved && clickCol != null) 
            {
                if (_Able.Contains(clickCol.transform))
                {
                    _Able.Clear();
                    clickCol.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
                    
                    clickCol.TryGetComponent(out ImPanel wall);
                    _Able = wall.Fidn_Route(); //_able에 현재 클릭된 녀석 기준 상하좌우 가져오기

                    Fail_Reset.Push(clickCol.gameObject);
                    Debug.Log(clickCol.tag);
                }
            }

            if(toto.phase == TouchPhase.Ended && clickCol != null) 
            {
                if(clickCol.tag == "EndPoint")
                {
                    Debug.Log("Clear");
                }else
                {
                    Debug.Log("Fail");
                    StartCoroutine( _Reset());
                }
            }
        }
    }


    public IEnumerator _Reset()
    {
        GameObject _mesh;
        //foreach(Transform sq in _Spuare)
        //{
        //    sq.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;

        //    if(sq.TryGetComponent<Collider2D>(out Collider2D col))
        //    {
        //        col.enabled = true;
        //    }
        //}clickCol.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
        while (Fail_Reset.Count > 0)
        {
            _Able.Clear();
            _mesh = Fail_Reset.Pop();
            _mesh.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
            _mesh.gameObject.tag = "Square";
            yield return new WaitForSeconds(0.2f);
        }
    }

}
