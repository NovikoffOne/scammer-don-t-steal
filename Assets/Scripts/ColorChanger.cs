using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float _duration;

    private SpriteRenderer _target;
    private Color _targetColor = Color.red;
    private Color _startColor;
    private float _runningTime;

    private void Start()
    {
        _target = GetComponent<SpriteRenderer>();

        _startColor = _target.color;
    }

    public void ReturnStartColor()
    {
        _target.color = _startColor;
    }
    
    public void LinerColorChanger()
    {
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _target.color = Color.Lerp(_targetColor, _startColor, normalizeRunningTime);
        }
        else if (_runningTime > _duration)
        {
            _runningTime = 0;

            _target.color = _startColor;
        }
    }
}
