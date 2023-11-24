using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCaracterMove : MonoBehaviour
{
    public GameObject Handle;
    public GameObject Caracter;


    private void Start()
    {
        Caracter.GetComponent<Animator>().Play("run");
    }

    private void Update()
    {
        Caracter.GetComponent<Animator>().Play("run");
        gameObject.transform.position = Handle.transform.position + new Vector3(0,0.2f,10);
    }
}
