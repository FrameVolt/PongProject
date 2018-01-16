using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventBase
{
    private List<Action> _actions;

    public bool KeepOnLevelChanging { get; protected set; }

    public void Publish()
    {
        if (_actions == null) return;

        foreach (var action in _actions)
        {
            action();
        }
    }

    public void Subscribe(Action action)
    {
        if (_actions == null)
        {
            _actions = new List<Action>();
        }

        if (!_actions.Contains(action))
        {
            _actions.Add(action);
        }
    }

    public void Unsubscribe(Action action)
    {
        if (_actions == null)
        {
            return;
        }

        if (_actions.Contains(action))
        {
            _actions.Remove(action);
        }
    }

    public void Clear()
    {
        if (_actions == null)
        {
            return;
        }

        _actions.Clear();
    }
}
