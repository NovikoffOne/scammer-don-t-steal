using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signaling : MonoBehaviour
{
    private ColorChanger[] _environments;
    private AudioControlls _signal;

    private void Start()
    {
        _environments = GetComponentsInChildren<ColorChanger>();
        
        _signal = GetComponent<AudioControlls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveThief>(out MoveThief thief))
        {
            _signal.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<MoveThief>(out MoveThief thief))
        {
            _signal.IncreaseVolume();

            foreach (var part in _environments)
            {
                part.LinerColorChanger();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _signal.DecrementVolume();

        foreach (var part in _environments)
        {
            part.ReturnStartColor();
        }
    }
}
