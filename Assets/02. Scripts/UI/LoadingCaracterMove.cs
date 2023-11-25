using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCaracterMove : MonoBehaviour
{
    public GameObject Handle;
    public GameObject Caracter;


    private void Start()
    {
        Caracter.GetComponent<Animator>().Play("Run");
    }

    private void Update()
    {
        Caracter.GetComponent<Animator>().Play("Run");
        gameObject.transform.position = Handle.transform.position + new Vector3(0,0.5f,10);
    }
}
