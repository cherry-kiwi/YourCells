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
    float speed_Bomb;

    public float m_HeightArc = 30;
    private Vector2 m_StartPosition;
    

    public enum kindd
    {
        FatMan,
        Bomb
    }

    void Start()
    {
        To_ = Mill_.transform.position;
        m_StartPosition = transform.position;
        Spawn_ = transform.parent.parent.GetComponent<Spawner>();

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
        speed_Bomb = Random.Range(3, 5);
        if ((transform.position.x - Mill_.transform.position.x) > 0)
        {

            if (TryGetComponent(out Rigidbody2D ri))
            {
                Debug.Log("Right");
                ri.AddForce(Vector2.left * speed_Bomb, ForceMode2D.Impulse);
                ri.AddForce(Vector2.up * 3, ForceMode2D.Impulse);
            }
        }
        else if ((transform.position.x - Mill_.transform.position.x) < 0)
        {

            if (TryGetComponent(out Rigidbody2D ri))
            {
                Debug.Log("Left");
                ri.AddForce(Vector2.right * speed_Bomb , ForceMode2D.Impulse);
                ri.AddForce(Vector2.up * 3, ForceMode2D.Impulse);

            }
        }
        #endregion
    }


    private IEnumerator ImFatMan()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, To_, speed_FatMan);
            yield return null;
        }
    }
}

