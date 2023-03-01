using System;
using UnityEngine;

public class ReferenceSO<T> : ScriptableObject where T : class
{
    public event Action Changed;

    [SerializeField] private T m_ObjectReference;
    public T Ref
    {
        get
        {
            return m_ObjectReference;
        }
        set
        {
            if (m_ObjectReference == value) return;

            m_ObjectReference = value;

            Changed?.Invoke();
        }
    }
}
