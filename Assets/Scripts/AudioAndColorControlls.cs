using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioAndColorControlls : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private float _waitSeconds = 0.02f;
    [SerializeField] private float _incrementVolume = 0.02f;

    private AudioSource _signal;
    private WaitForSeconds _waitForSeconds;
    private SpriteRenderer _targetSprite;
    private float _targetVolume;
    private Color _targetColor = Color.red;
    private Color _startColor;
    private float _runningTime;

    private void Start()
    {
        _targetSprite = GetComponent<SpriteRenderer>();
        
        _signal = GetComponent<AudioSource>();

        _waitForSeconds = new WaitForSeconds(_waitSeconds);

        _startColor = _targetSprite.color;
    }

    public void Play()
    {
        _signal.Play();
    }

    public void IncreaseVolume()
    {
        _targetVolume = 1;

        _signal.volume = Mathf.MoveTowards(_signal.volume, _targetVolume, _incrementVolume * Time.deltaTime);
    }

    public void DecrementVolume()
    {
        _targetVolume = 0;

        StartCoroutine(LinerDecrementVolume(_targetVolume));
    }

    public void ReturnStartColor()
    {
        _targetSprite.color = _startColor;
    }

    public void LinerColorChanger()
    {
        if (_runningTime <= _duration)
        {
            _runningTime += Time.deltaTime;

            float normalizeRunningTime = _runningTime / _duration;

            _targetSprite.color = Color.Lerp(_targetColor, _startColor, normalizeRunningTime);
        }
        else if (_runningTime > _duration)
        {
            _runningTime = 0;

            _targetSprite.color = _startColor;
        }
    }

    private IEnumerator LinerDecrementVolume(float target)
    {
        while (_signal.volume > target)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, target, _incrementVolume * Time.deltaTime);

            yield return _waitForSeconds;
        }

        if (_signal.volume == target)
        {
            _signal.Stop();
        }
    }
}