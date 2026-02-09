public readonly struct GameEndedSignal
{
    public readonly ArmyType ArmyType;

    public GameEndedSignal(ArmyType armyType)
    {
        ArmyType = armyType;
    }
}
