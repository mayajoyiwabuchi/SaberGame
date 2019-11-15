﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScript : MonoBehaviour
{
    private Transform transform;
    // Desired duration of the shake effect
    private float shakeDuration = 0f;

    // A measure of magnitude for the shake. Tweak based on your preference
    private float shakeMagnitude = 0.1f;

    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;

    // The initial position of the GameObject
    Vector3 initialPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }
    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }
    void Start()
    {
        StartCoroutine(triggerMegalovania());
        Debug.Log("started megalovania");
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }

    }
    public void TriggerShake()
    {
        shakeDuration = 100.0f;
    }

    public IEnumerator triggerMegalovania()
    {
        yield return new WaitForSeconds(16);
        TriggerShake();
    }

}
