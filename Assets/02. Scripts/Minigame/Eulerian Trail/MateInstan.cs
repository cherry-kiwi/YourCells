using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateInstan : MonoBehaviour
{
    private SpriteRenderer _meshR;

    [SerializeField] private Color _color;

    void Start()
    {
        _meshR = GetComponent<SpriteRenderer>();
        _meshR.material = Instantiate(_meshR.material);
        _meshR.material.SetColor("Color",_color);

    }
}
