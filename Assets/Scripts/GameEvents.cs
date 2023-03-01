using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static event Action<TeamSO> Chop;

    public static void RaiseChopEvent(TeamSO team)
    {
        Chop?.Invoke(team);
    }
}
