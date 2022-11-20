using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThief : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Transform _point;

    private Transform _traget;

    private void Start()
    {
        _traget = _point.GetComponent<Transform>();
    }

    private void Update()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, _point.position, _speed * Time.deltaTime);

        if(transform.position == _point.position)
        {
            yield return new WaitForSeconds(5f);

            _traget.position = new Vector3(0, 0, transform.position.z);

            this.transform.position = Vector3.MoveTowards(transform.position, _traget.position, _speed * Time.deltaTime);
        }
    }
}
