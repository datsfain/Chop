using UnityEngine;
using UnityEngine.UI;

public class ChopButton : MonoBehaviour
{
    [SerializeField] private TeamSO m_Team;
    [SerializeField] private TeamReferenceSO m_ChoppingTeam;
    [SerializeField] private GameObject m_ButtonObject;

    private void Start()
    {
        m_ChoppingTeam.Changed += ChoppingTeam_Changed;
        ChoppingTeam_Changed();
    }

    private void OnDestroy()
    {
        m_ChoppingTeam.Changed -= ChoppingTeam_Changed;
    }

    public void Chop()
    {
        GameEvents.RaiseChopEvent(m_Team);
    }

    private void ChoppingTeam_Changed()
    {
        ActivateButton(m_Team == m_ChoppingTeam.Ref);
    }

    private void ActivateButton(bool activate)
    {
        m_ButtonObject.SetActive(activate);
    }
}
