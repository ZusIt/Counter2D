using System.Collections;
using UnityEngine;
using System;
public class Counter : MonoBehaviour
{
    [SerializeField] private float _waitSeconds = 0.5f;

    private bool _isCounting = false;

    private Coroutine _coroutineCounter;

    public event Action CountViewing;

    public int Count { get; private set; }

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;

            if (_isCounting)
                _coroutineCounter = StartCoroutine(CountUp());
            else
                if(_coroutineCounter != null)
                    StopCoroutine(_coroutineCounter);
        }
    }

    private IEnumerator CountUp()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_waitSeconds);

        while (_isCounting)
        {
            CountViewing?.Invoke();
            Count++;
            yield return waitTime;
        }
    }
}
