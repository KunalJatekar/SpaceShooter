﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    List<EventListener> _eventListener = new List<EventListener>();

    public void Raise()
    {
        Debug.Log(this.name + " Raised");
        for (int i = 0; i < _eventListener.Count; i++)
        {
            _eventListener[i].OnEventRaised();
        }
    }

    public void Register(EventListener listener)
    {
        if (!_eventListener.Contains(listener))
        {
            _eventListener.Add(listener);
        }
    }

    public void DeRegister(EventListener listener)
    {
        if (_eventListener.Contains(listener))
        {
            _eventListener.Remove(listener);
        }
    }
}
