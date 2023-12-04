using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _travelTime;
    [SerializeField] private float _travelSpeed;
    [SerializeField] private int _timeWait;

    private Coroutine _coroutine;

    private void Start()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(WaitForTime(_timeWait));
    }

    private IEnumerator WaitForTime(float delay)
    {
        var wait = new WaitForSeconds(delay);

        yield return wait;

        _coroutine = StartCoroutine(MoveForward(_travelTime));
    }

    private IEnumerator MoveForward(float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.Translate(transform.forward * _travelSpeed * Time.deltaTime);

            time += Time.deltaTime;

            yield return null;
        }

        StopCoroutine(_coroutine);
    }
}
