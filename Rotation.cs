using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float _rotationTime;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _timeWait;

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

        _coroutine = StartCoroutine(TransformObject(_rotationTime));
    }

    private IEnumerator TransformObject(float duration)
    {
        float time = 0;

        while (time < duration)
        {
            transform.Rotate(0, _rotationSpeed, 0);

            time += Time.deltaTime;

            yield return null;
        }

        StopCoroutine(_coroutine);       
    }
}
