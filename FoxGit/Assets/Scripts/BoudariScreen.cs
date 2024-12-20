using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoudariScreen : MonoBehaviour
{
    Camera _camera;
    Vector2 _screenBoundary;

    Vector2 _leftEdge;
    Vector2 _rightEdge;

    float _objectWidth;

    void Start()
    {
        _camera = Camera.main;
        _objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void LateUpdate()
    {
        Vector2 Pos = transform.position;
        _leftEdge = _camera.ScreenToWorldPoint(Vector2.zero);
        _rightEdge = _camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Pos.x = Mathf.Clamp(Pos.x,_leftEdge.x + 0.5f,_rightEdge.x - _objectWidth);
        transform.position = Pos;
    }
}
