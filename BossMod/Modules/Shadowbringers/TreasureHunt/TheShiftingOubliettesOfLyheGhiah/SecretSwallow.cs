namespace BossMod.Shadowbringers.TreasureHunt.ShiftingOubliettesOfLyheGhiah.SecretSwallow;

public enum OID : uint
{
    Boss = 0x302B, //R=4.0
    SwallowHatchling = 0x302C, //R=2.0 
    Helper = 0x233C
}

public enum AID : uint
{
    AutoAttack = 870, // Boss/SwallowHatchling->player, no cast, single-target

    ElectricWhorl = 21720, // Boss->self, 4.5s cast, range 8-60 donut
    Hydrocannon = 21712, // Boss->self, no cast, single-target
    Hydrocannon2 = 21766, // Helper->location, 3.0s cast, range 8 circle
    Ceras = 21716, // Boss->player, 4.0s cast, single-target, applies poison
    SeventhWave = 21719, // Boss->self, 4.5s cast, range 11 circle
    BodySlam = 21718, // Boss->location, 4.0s cast, range 10 circle, knockback 20, away from source
    PrevailingCurrent = 21717 // SwallowHatchling->self, 3.0s cast, range 22+R width 6 rect
}

class ElectricWhorl(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.SeventhWave), new AOEShapeCircle(11));
class PrevailingCurrent(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PrevailingCurrent), new AOEShapeRect(24, 3));
class SeventhWave(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.ElectricWhorl), new AOEShapeDonut(8, 60));
class Hydrocannon(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.Hydrocannon2), 8);
class Ceras(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.Ceras));
class BodySlam(BossModule module) : Components.LocationTargetedAOEs(module, ActionID.MakeSpell(AID.BodySlam), 10);

class BodySlamKB(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.BodySlam), 20, shape: new AOEShapeCircle(10), stopAtWall: true)
{
    public override bool DestinationUnsafe(int slot, Actor actor, WPos pos) => Module.FindComponent<PrevailingCurrent>()?.ActiveAOEs(slot, actor).Any(z => z.Shape.Check(pos, z.Origin, z.Rotation)) ?? false;
}

class SecretSwallowStates : StateMachineBuilder
{
    public SecretSwallowStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<ElectricWhorl>()
            .ActivateOnEnter<PrevailingCurrent>()
            .ActivateOnEnter<SeventhWave>()
            .ActivateOnEnter<Hydrocannon>()
            .ActivateOnEnter<Ceras>()
            .ActivateOnEnter<BodySlam>()
            .ActivateOnEnter<BodySlamKB>()
            .Raw.Update = () => module.Enemies(OID.SwallowHatchling).Concat([module.PrimaryActor]).All(e => e.IsDeadOrDestroyed);
    }
}

[ModuleInfo(BossModuleInfo.Maturity.Verified, Contributors = "Malediktus", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 745, NameID = 9782)]
public class SecretSwallow(WorldState ws, Actor primary) : BossModule(ws, primary, new(100, 100), new ArenaBoundsCircle(19))
{
    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor);
        Arena.Actors(Enemies(OID.SwallowHatchling));
    }

    protected override void CalculateModuleAIHints(int slot, Actor actor, PartyRolesConfig.Assignment assignment, AIHints hints)
    {
        foreach (var e in hints.PotentialTargets)
        {
            e.Priority = (OID)e.Actor.OID switch
            {
                OID.SwallowHatchling => 2,
                OID.Boss => 1,
                _ => 0
            };
        }
    }
}
