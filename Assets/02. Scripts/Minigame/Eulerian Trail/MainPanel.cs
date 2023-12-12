using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainPanel : MonoBehaviour
{
    private RaycastHit hit;
    private Camera cam;

    [SerializeField] private Transform[] Row;

    [SerializeField]
    private List<Transform> _Spuare = new List<Transform>();

    [SerializeField] private List<Transform> _Able = new List<Transform>();
    [SerializeField] private Stack<GameObject> Fail_Reset = new Stack<GameObject>();



    private void Start()
    {
        cam = GetComponent<Camera>();

        #region Receive all tiles except walls in : Transfrom _Square
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
        if (Input.touchCount > 0 && GameStart.GamePlaying == true) 
        {
            Touch toto = Input.GetTouch(0);

            #region Currently Clicked Obj in : Collider2D clickCol
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
                    _Able = wall.Fidn_Route(); //Import up R,L,U,D based on currently clicked obj in _Able
                    Fail_Reset.Push(clickCol.gameObject);
                } else
                {
                    Debug.Log("Start Somewhere else");
                }
            }

            if (toto.phase== TouchPhase.Moved && clickCol != null) 
            {
                if (_Able.Contains(clickCol.transform))
                {
                    _Able.Clear();
                    clickCol.gameObject.GetComponent<SpriteRenderer>().material.color = Color.red;
                    
                    clickCol.TryGetComponent(out ImPanel wall);
                    _Able = wall.Fidn_Route(); //Import up R,L,U,D based on currently clicked obj in _Able

                    Fail_Reset.Push(clickCol.gameObject);
                    Debug.Log(clickCol.tag);
                }
            }

            if(toto.phase == TouchPhase.Ended && clickCol != null) 
            {
                if(Fail_Reset.Count == _Spuare.Count)
                {
                    Debug.Log("Clear");
                }else
                {
                    StartCoroutine( _Reset());
                }
            }
        }
    }


    public IEnumerator _Reset()
    {
        GameObject _mesh;

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
