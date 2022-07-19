using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Deactivate : MonoBehaviour
{
    [SerializeField] private UnityEvent disableGO;
    [SerializeField] private UnityEvent enableGO;

    [SerializeField] private UnityEvent debugLeBug;

    [SerializeField] private UnityEvent actionEvent;

    [SerializeField] private UnityEvent<int> test;
    private void Start()
    {
        disableGO.Invoke();
        StartCoroutine(EnableGO());
        actionEvent.AddListener(() => SomeAction());
        actionEvent.Invoke();
    }

    private IEnumerator EnableGO()
    {
        yield return new WaitForSeconds(5);
        enableGO.Invoke();
        debugLeBug.Invoke();
    }

    public Action SomeAction = () => 
    {
        Debug.Log($"Hi ");
    };
    public void RandomDebugs()
    {
        Debug.Log("Some random Debug.");
    }

}
