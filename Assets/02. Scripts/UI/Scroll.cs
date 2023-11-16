using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Scroll : MonoBehaviour 
{
    public static Scroll instance;

    public RectTransform List;
    public int count;
    public float pos;
    private float movepos;
    private bool IsScroll = false;

    private void Awake()
    {
        instance = this;
    }

    void Start () 
    {
        pos = List.localPosition.x;
        movepos = List.rect.xMax - List.rect.xMax / count;
        Debug.Log("List.rect.xMax: " + List.rect.xMax);
        Debug.Log("List.rect.xMin: " + List.rect.xMin);
        Debug.Log("List.rect.xMax - List.rect.xMax / count: " + (List.rect.xMax - List.rect.xMax / count));
        Debug.Log("pos: " + pos);
    }

    private void Update()
    {
    }

    public void Right()
    {
        if(List.rect.xMin + List.rect.xMax/count == movepos)
        {

        }
        else
        {
            IsScroll = true;
            movepos = pos - List.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
        }
    }

    public void Left()
    {
        if(List.rect.xMax - List.rect.xMax/count == movepos)
        {

        }
        else
        {
            IsScroll = true;
            movepos = pos + List.rect.width / count;
            pos = movepos;
            StartCoroutine(scroll());
        }
    }

    IEnumerator scroll()
    {
        while (IsScroll)
        {
            List.localPosition = Vector2.Lerp(List.localPosition, new Vector2(movepos, 0), Time.deltaTime * 5);
            if (Vector2.Distance(List.localPosition, new Vector2(movepos, 0)) < 0.1f)
            {
                IsScroll = false;
            }
            yield return null;
        }
    }
}
