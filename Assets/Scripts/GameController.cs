using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform cameraObj;
    [SerializeField] private Transform inventory;
    [SerializeField] private LayerMask avoidStruct;

    private Vector2 _mousePos;
    bool _mouseLeftDown = false;
    bool _movingStruct = false;
    //bool _isRotate = true;

    Vector3 test = Vector3.zero;

    private Transform _structPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraInputs();
        UIInputs();

    }

    void CameraInputs()
    {
        float y;
        float x;
        if (Input.GetMouseButtonDown(1))
        {
            _mousePos = Input.mousePosition;
            _mouseLeftDown = true;
        }

        if (_mouseLeftDown)
        {
            y = Input.mousePosition.y - _mousePos.y;
            x = Input.mousePosition.x - _mousePos.x;
            cameraObj.position += new Vector3(x/100 + y/100, 0, y/100 - x/100);
            _mousePos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(1))
        {
            _mouseLeftDown = false;
            y = Input.mousePosition.y - _mousePos.y;
            x = Input.mousePosition.x - _mousePos.x;
        }
    }

    void UIInputs()
    {
        RaycastHit hit;
        //Debug.DrawLine(Camera.main.ScreenToWorldPoint(Input.mousePosition), test, Color.red);
        
        if (Input.GetMouseButtonDown(0))
        {
            
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.gameObject.tag);
                if(hit.collider.gameObject.tag == "Structure")
                {
                    _structPos = hit.collider.gameObject.GetComponent<Transform>();
                    _movingStruct = true;
                }
                
                //test = hit.point;
            }
        }

        if (_movingStruct)
        {
            
            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Camera.main.transform.forward, out hit, Mathf.Infinity, avoidStruct))
            {
                //Debug.Log(hit.point);
                _structPos.position = hit.point;
                if(hit.collider.gameObject.tag == "CamUI")
                {
                    _structPos.localScale = Vector3.one / 2;
                    _structPos.parent = inventory;
                }
                else
                {
                    _structPos.localScale = Vector3.one;
                    _structPos.parent = null;
                }
                    
                //test = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _structPos = null;
            _movingStruct = false;
        }
    }
}
