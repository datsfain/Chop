using UnityEngine;

public class ChopHandler : MonoBehaviour
{
    [SerializeField] private TeamSO m_TopTeam;
    [SerializeField] private TeamSO m_BottomTeam;
    [SerializeField] private TeamReferenceSO m_ChoppingTeam;
    [SerializeField] private FloatVariable m_ChopperY;
    [SerializeField] private FloatVariable m_MinCutSize;

    private TeamSO GetOpposingTeam(TeamSO team)
    {
        if (team == m_TopTeam) return m_BottomTeam;
        else return m_TopTeam;
    }

    private void Awake()
    {
        m_TopTeam.ResetValues();
        m_BottomTeam.ResetValues();
    }

    private void Start()
    {
        GameEvents.Chop += GameEvents_Chop;
    }

    private void OnDestroy()
    {
        GameEvents.Chop -= GameEvents_Chop;
    }

    private void GameEvents_Chop(TeamSO team)
    {
        if (m_ChoppingTeam.Ref != team)
        {
            return;
        }

        if (team == m_TopTeam && m_ChopperY.Value > 0f)
        {
            return;
        }

        if (team == m_BottomTeam && m_ChopperY.Value < 0f)
        {
            return;
        }

        var opposingTeam = GetOpposingTeam(team);

        var remainingSize = Mathf.Abs(m_ChopperY.Value);
        var maxRemainingSize = Mathf.Max(0f, opposingTeam.RemainingSize.Value - m_MinCutSize.Value);
        var minRemainingSize = Mathf.Min(maxRemainingSize, m_MinCutSize.Value);

        opposingTeam.RemainingSize.Value = Mathf.Clamp(remainingSize, minRemainingSize, maxRemainingSize);

        m_ChoppingTeam.Ref = opposingTeam;
    }
}
