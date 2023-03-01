using System;
using UnityEngine;

public class VariableSO<T> : ScriptableObject where T : struct
{
    public event Action Changed;

    [SerializeField] private T m_Value;
    public T Value
    {
        get
        {
            return m_Value;
        }
        set
        {
            if (m_Value.Equals(value)) return;

            m_Value = value;

            Changed?.Invoke();
        }
    }
}
