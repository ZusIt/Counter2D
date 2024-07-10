using UnityEngine;
using UnityEngine.UI;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Text _countView;

    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountViewing += DisplayCount;
    }

    private void OnDisable()
    {
        _counter.CountViewing -= DisplayCount;
    }

    public void DisplayCount()
    {
        _countView.text = _counter.Count.ToString();
    }
}
