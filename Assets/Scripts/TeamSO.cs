using UnityEngine;

[CreateAssetMenu(fileName = "Team", menuName = "ScriptableObjects/Team")]
public class TeamSO : ScriptableObject
{
    [field: SerializeField] public Color Color { get; private set; }
    [field: SerializeField] public FloatVariable RemainingSize { get; private set; }
    [field: SerializeField] public FloatVariable InitialSize { get; private set; }

    public void ResetValues()
    {
        RemainingSize.Value = InitialSize.Value;
    }
}
