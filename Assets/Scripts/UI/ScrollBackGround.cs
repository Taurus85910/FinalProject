using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class ScrollBackGround : MonoBehaviour
{
    [SerializeField] private float _speed;
    private RawImage _rawImage;
    private float _yPos;
    private void Start() => _rawImage = GetComponent<RawImage>();

    private void Update()
    {
        _yPos += _speed * Time.deltaTime;
        if (_yPos >= 10)
            _yPos = 0;
        _rawImage.uvRect = new Rect(0,_yPos,_rawImage.uvRect.width,_rawImage.uvRect.height);
    }
}
