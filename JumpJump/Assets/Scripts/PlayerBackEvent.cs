using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerBackEvent
{
    private static Action m_BackEvent;
    public static void Register(Action BackEvent)
    {
        m_BackEvent += BackEvent;
    }
    public static void UnRegister(Action BackEvent)
    {
        m_BackEvent -= BackEvent;
    }
    public static void Trigger()
    {
        m_BackEvent?.Invoke();
    }
}
