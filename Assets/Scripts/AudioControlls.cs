using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControlls : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 0.02f;
    [SerializeField] private float _incrementVolume = 0.02f;
    
    private AudioSource _signal;
    private float _target;

    private void Start()
    {
        _signal = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _signal.Play();
    }

    public void IncreaseVolume()
    {
        _target = 1;

        _signal.volume = Mathf.MoveTowards(_signal.volume, _target, _incrementVolume * Time.deltaTime);
    }

    public void DecrementVolume()
    {
        _target = 0;

        StartCoroutine(LinerDecrementVolume(_target));
    }

    private IEnumerator LinerDecrementVolume(float target)
    {
        while (_signal.volume > target)
        {
            _signal.volume = Mathf.MoveTowards(_signal.volume, target, _incrementVolume * Time.deltaTime);

            yield return new WaitForSeconds(_waitSeconds);
        }

        if (_signal.volume == target)
        {
            _signal.Stop();
        }
    }
}
