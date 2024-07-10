using System.Collections;
using UnityEngine;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _WaitInSeconds = 0.5f;

    private bool _isCounting = false;

    public event Action CountViewing;

    public int Count { get; private set; }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;

            if (_isCounting)
                StartCoroutine(CountUp());
        }
    }

    private IEnumerator CountUp()
    {
        while (_isCounting)
        {
            CountViewing?.Invoke();
            Count++;
            yield return new WaitForSeconds(_WaitInSeconds);
        }
    }
}
