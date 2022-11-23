using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _point;
    [SerializeField] private float _waitSeconds = 5f;

    private void Update()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);

        if(transform.position == _point.position)
        {
            yield return new WaitForSeconds(_waitSeconds);

            _point.position = new Vector3(0, 0, transform.position.z);

            this.transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);
        }
    }
}
