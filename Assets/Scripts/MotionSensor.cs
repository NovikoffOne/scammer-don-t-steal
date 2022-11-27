using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class MotionSensor: MonoBehaviour
{
    private AudioAndColorControlls _alert;

    private void Start()
    {   
        _alert = GetComponent<AudioAndColorControlls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _alert.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out Thief thief))
        {
            _alert.IncreaseVolume();
            _alert.LinerColorChanger();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _alert.DecrementVolume();
        _alert.ReturnStartColor();
    }
}
