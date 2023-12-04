using System.Collections;
using UnityEngine;

public class Scale : MonoBehaviour
{
    [SerializeField] private float _timeToScale;
    [SerializeField] private float _speedScale;
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

        _coroutine = StartCoroutine(TransformObject(_timeToScale));
    }

    private IEnumerator TransformObject(float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.localScale += new Vector3(_speedScale, _speedScale, _speedScale);

            time += Time.deltaTime;

            yield return null;
        }

        StopCoroutine(_coroutine);
    }
}
