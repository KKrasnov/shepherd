using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerHandler2D : MonoBehaviour {

    public event Action<Collider2D> OnTriggerEnter2DEvent = null;
    public event Action<Collider2D> OnTriggerStay2DEvent = null;
    public event Action<Collider2D> OnTriggerExit2DEvent = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (OnTriggerEnter2DEvent != null)
            OnTriggerEnter2DEvent(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (OnTriggerStay2DEvent != null)
            OnTriggerStay2DEvent(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (OnTriggerExit2DEvent != null)
            OnTriggerExit2DEvent(other);
    }
}
