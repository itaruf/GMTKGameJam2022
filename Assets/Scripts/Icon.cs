using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] Vector3 _offset;

    public Action _onActivation;
    public Action _onDeactivation;

    public RectTransform _rectTransform;
    public RawImage _rawImage;

    void Awake()
    {
        TryGetComponent(out _rawImage);
        TryGetComponent(out _rectTransform);

        if (!_rawImage)
            return;
    }

    void FixedUpdate()
    {
        if (!_rectTransform)
            return;

        transform.position = Camera.main.transform.TransformPoint(_target.transform.position) + _offset;

    }

    private void OnDestroy()
    {
        Event.current._onRollDiceStarted -= Activation;
        Event.current._onRollDiceEnded -= Deactivation;
    }

    public virtual void Activation()
    {
        _rawImage.enabled = true;
    }

    public virtual void Deactivation()
    {
        _rawImage.enabled = false;
    }
}
