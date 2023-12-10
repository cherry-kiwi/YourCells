using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellAi : MonoBehaviour
{
    public float Timer;
    public int dir;

    private Animator animator;
    private Rigidbody2D rb;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            dir = Random.Range(1, 6);
            Timer = Random.Range(3, 10);
        }

        if (transform.position.x < 4f && transform.position.x > -4f && transform.position.y < 2.5f && transform.position.y > -3f)
        {
            if (dir == 1)
            {
                animator.Play("Idle");
            }
            else if (dir == 2)
            {
                animator.Play("Run");
                transform.localScale = new Vector3(-0.1f, 0.1f, 1);
                transform.Translate(new Vector3(1, 1, 0) * Time.deltaTime / 10);
            }
            else if (dir == 3)
            {
                animator.Play("Run");
                transform.localScale = new Vector3(0.1f, 0.1f, 1);
                transform.Translate(new Vector3(-1, 1, 0) * Time.deltaTime / 10);
            }
            else if (dir == 4)
            {
                animator.Play("Run");
                transform.localScale = new Vector3(-0.1f, 0.1f, 1);
                transform.Translate(new Vector3(1, -1, 0) * Time.deltaTime / 10);
            }
            else if (dir == 5)
            {
                animator.Play("Run");
                transform.localScale = new Vector3(0.1f, 0.1f, 1);
                transform.Translate(new Vector3(-1, -1, 0) * Time.deltaTime / 10);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -2, 0), 0.1f * Time.deltaTime);
        }
    }
}
