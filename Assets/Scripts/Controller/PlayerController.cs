using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float ratio = 1f;
    [SerializeField] private float planeWidth = 10f;
    [SerializeField] private float turnSmoothTime;
    [SerializeField] private float yPos;


    private Vector2 _initialMousePos;
    private Vector3 _initialPos;
    private Vector3 _targetPosition;
    private Vector3 _refVector;

    private Vector2 _differenceVector;
    
    private float _sWidth;
    private float _angle;
    private float _turnSmoothVelocity = 0.1f;
    private float _currentSpeed;

    private float _rightLim = 3.5f;
    private float _leftLim = -3.5f;
    private float _rightPoolLim;
    private float _leftPoolLim;
    private float _curLeftLim;
    private float _curRightLim;

    private float _targetYpos;

    
    private void Start()
    {
        _sWidth = Screen.width;
        _initialPos = transform.localPosition;

        _curLeftLim = _leftLim;
        _curRightLim = _rightLim;
    }

    private void Update()
    {
        
        GetTouchInput();
        UpdatePosition();
    }

    private void GetTouchInput()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector3 currentPos = transform.position;
        Vector3 pos = currentPos;
        

        if (Input.GetMouseButtonDown(0))
        {
            _initialMousePos = mousePos;
            _initialPos = pos;
        }

        if (Input.GetMouseButton(0))
        {
            _initialPos.z = currentPos.z;
            var diff = mousePos.x - _initialMousePos.x;
            var x = (diff / _sWidth * planeWidth) * ratio;
            pos = _initialPos + new Vector3(x, 0, 0);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _initialMousePos = Vector2.zero;
            _initialPos = Vector3.zero;
        }

        if (pos.x >= planeWidth / 2 - 0.1f)
        {
            pos.x = planeWidth / 2 - 0.1f;
        }
        else if (pos.x <= -planeWidth / 2 + 0.1f)
        {
            pos.x = -planeWidth / 2 + 0.1f;
        }
        _targetPosition = pos;
    }
    
    private void UpdatePosition()
    {
        _currentSpeed = Mathf.Lerp(_currentSpeed, speed, Time.deltaTime);
        transform.position = _targetPosition + Vector3.forward * (speed * Time.deltaTime);

        yPos = Mathf.Lerp(yPos, _targetYpos, Time.deltaTime * 2.5f);
        _targetPosition.y = yPos;
        
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition,
            _targetPosition, ref _refVector, 0.1f);
    }

    public void SpeedUp()
    {
        speed += 1;
    }

    public void SlowDown()
    {
        speed -= 1;
    }


    public void AssignPoolLim(float left, float right, bool isPool)
    {
        _leftPoolLim = left;
        _rightPoolLim = right;
        ActivatePoolLim();

        if (isPool)
        {
            StartCoroutine(ChangeY());
        }
    }

    private void ActivatePoolLim()
    {
        _curLeftLim = _leftPoolLim;
        _curRightLim = _rightPoolLim;
    }

    public void DeActivatePoolLim()
    {
        _curLeftLim = _leftLim;
        _curRightLim = _rightLim;
    }

    private IEnumerator ChangeY()
    {
        _targetYpos = -1.5f;
        yield return new WaitForSeconds(1f);
        _targetYpos = 0;
    }
}
