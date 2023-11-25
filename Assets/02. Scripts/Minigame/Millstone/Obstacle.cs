using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update

    public kindd Whatisthis;
    public GameObject Mill_;
    public Spawner Spawn_;

    Vector2 To_;

    float speed_FatMan;
    float Force_Bomb;
    float Speed_Bomb;

    public float m_HeightArc = 30;
    private Vector2 m_StartPosition;

    public enum kindd
    {
        FatMan,
        Bomb
    }

    void Start()
    {
        To_ = Mill_.transform.position; // 맷돌 위치 받아오기
        m_StartPosition = transform.position; //해당 장애물 시작위치 받아오기
        Spawn_ = transform.parent.parent.GetComponent<Spawner>(); //날 만든 스포너 정보 받아오기


        if (this.name.StartsWith("FatMan"))
        {
            Whatisthis = kindd.FatMan;
            speed_FatMan = Spawn_.spd_Fatman;
            StartCoroutine(ImFatMan());
        }
        else if (this.name.StartsWith("Bomb"))
        {
            Whatisthis = kindd.Bomb;
            ImBomb();
        }
    }

    private void ImBomb()
    {
        #region
        TryGetComponent(out Rigidbody2D ri);
        Force_Bomb = Random.Range(1, 3);
        Speed_Bomb= Random.Range(0.7f, 1.5f);
        
        if ((transform.position.x - Mill_.transform.position.x) > 0) // 맵 기준 우측에서 생성
        {
            ri.AddForce(Vector2.left * Force_Bomb, ForceMode2D.Impulse);
            ri.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            ri.gravityScale = Speed_Bomb;
        }
        else if ((transform.position.x - Mill_.transform.position.x) < 0) // 맵 기준 좌측에서 생성
        {
            ri.AddForce(Vector2.right * Force_Bomb , ForceMode2D.Impulse);
            ri.AddForce(Vector2.up * 4, ForceMode2D.Impulse);
            ri.gravityScale = Speed_Bomb;
        }

        
        #endregion
    }

    private IEnumerator ImFatMan()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, To_, speed_FatMan * Time.deltaTime);
            //transform.position = Vector2.Lerp(transform.position, To_, 0.001f);
            yield return null;
        }
    }

    public void Bomb_obs_Click()
    {
        gameObject.SetActive(false);
    }

    public void FatMan_obs_Click()
    {
        transform.Translate(new Vector2(0,0.2f));  
    }
}

