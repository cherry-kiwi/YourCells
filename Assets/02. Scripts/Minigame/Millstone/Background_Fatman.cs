using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Fatman : MonoBehaviour
{
    [SerializeField] private Transform happyhead;
    [SerializeField] private Transform badhead;
    //[SerializeField] private Spawner SpawnTrig;

    Animator animator;

    void Start()
    {
        animator= GetComponent<Animator>();
    }

    public void GimicStart()
    {
        badhead.gameObject.SetActive(true);
        animator.SetTrigger("angry");
        happyhead.gameObject.SetActive(false);
    }

    public void GimicEnd()
    {
        Invoke("GimicEndReal", 1);
    }

    private void GimicEndReal()
    {

        happyhead.gameObject.SetActive(true);
        animator.SetTrigger("come");
        badhead.gameObject.SetActive(false);
    }

}
