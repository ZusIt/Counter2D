using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _waitInSeconds = 0.5f;

    [SerializeField] private Text _countText;

    private int _count = 0;

    private bool _isCounting = false;

    void Start()
    {
        _countText.text = _count.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = !_isCounting;

            if (_isCounting)
                StartCoroutine(CountUp());
            else
                StopCoroutine(CountUp());
        }
    }

    IEnumerator CountUp()
    {
        while (_isCounting)
        {
            _count++;

            _countText.text = _count.ToString();

            yield return new WaitForSeconds(_waitInSeconds);
        }
    }
}
