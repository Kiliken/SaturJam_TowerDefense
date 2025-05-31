using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Vector2 _mousePos;
    bool _mouseDown = false;
    bool _isRotate = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        float y;
        float x;
        if (Input.GetMouseButtonDown(0))
        {
            _mousePos = Input.mousePosition;
            _mouseDown = true;
            _isRotate = true;
        }

        if (_mouseDown)
        {
            y = Input.mousePosition.y - _mousePos.y;
            x = Input.mousePosition.x - _mousePos.x;
            Camera.main.transform.position += new Vector3(x/100 + y/100, 0, y/100 - x/100);
            _mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _mouseDown = false;
            y = Input.mousePosition.y - _mousePos.y;
            x = Input.mousePosition.x - _mousePos.x;
        }
    }
    }
