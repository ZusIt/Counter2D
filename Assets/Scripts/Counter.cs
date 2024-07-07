using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _waitInSeconds = 0.5f;

    public int Count { get; private set; }

    private bool _isCounting = false;

    public event Action CountViewing;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;

            if (_isCounting)
                StartCoroutine(CountUp());
            else
                StopCoroutine(CountUp());
        }
        
        CountViewing?.Invoke();
    }

    private IEnumerator CountUp()
    {
        while (_isCounting)
        {
            Count++;
            yield return new WaitForSeconds(_waitInSeconds);
        }
    }
}
