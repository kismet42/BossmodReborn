namespace BossMod.Stormblood.Extreme.Ex7Suzaku;

public enum OID : uint
{
    Boss = 0x2464, // R2.8-6.93, x1
    Suzaku2 = 0x246B, // R2.1, x4
    Suzaku3 = 0x2570, // R1, x0 (spawn during fight)

    ScarletLady = 0x2465, // R1.12, x4
    ScarletPlume = 0x2466, // R1, x0 (spawn during fight)
    ScarletTailFeather = 0x2467, // R1.8, x0 (spawn during fight)

    RapturousEcho = 0x2468, // R1.5, x0 (spawn during fight)
    RapturousEchoPlatform = 0x1EA1A1, // R2, x11, EventObj type

    SongOfSorrow = 0x2461, // R1.5, x0 (spawn during fight)
    SongOfOblivion = 0x2462, // R1.5, x0 (spawn during fight)
    SongOfFire = 0x2460, // R1.5, x0 (spawn during fight)
    SongOfDurance = 0x2463, // R1.5, x0 (spawn during fight)

    NorthernPyre = 0x246C, // R2, x0 (spawn during fight)
    EasternPyre = 0x246D, // R2, x0 (spawn during fight)
    SouthernPyre = 0x246E, // R2, x0 (spawn during fight)
    WesternPyre = 0x246F, // R2, x0 (spawn during fight)

    Helper = 0x233C, // R0.5, x8, Helper type
}

public enum AID : uint
{
    AutoAttack = 871, // Boss->player, no cast, single-target
    AutoAttack2 = 12863, // Boss->player, no cast, single-target
    Cremate = 13009, // Boss->player, 3s cast, single-target tankbuster

    ScarletLadyAutoAttack = 14065, // ScarletLady->player, no cast, single-target
    AshesToAshes = 13008, // ScarletLady->self, 3s cast, range 40 circle raidwide

    ScreamsOfTheDamned = 13010, // Boss->self, 3s cast, range 40 circle raidwide
    ScarletFever = 13017, // Helper->self, 7s cast, range 41 circle raidwide arena change
    SouthronStar = 13023, // Boss->self, 4s cast, range 41 circle raidwide

    Rout = 13040, // Boss->self, 3s cast, range 55 width 6 rect

    RekindleSpread = 13024, // Helper->players, no cast, range 6 circle spread

    FleetingSummer = 13011, // Boss->self, 3s cast, range 40 90-degree cone

    PhoenixDown = 12836, // Boss->self, 3s cast, single-target
    WingAndAPrayerPlume = 12868, // ScarletPlume->self, 20s cast, range 9 circle
    WingAndAPrayerTailFeather = 13012, // ScarletTailFeather->self, 20s cast, range 9 circle
    EternalFlame = 12834, // Boss->self, 3s cast, range 80 circle
    LovesTrueForm = 12838, // Boss->self, no cast, single-target

    RapturousEcho1 = 13445, // Boss->self, no cast, single-target
    RapturousEcho2 = 13446, // Boss->self, no cast, single-target
    ScarletHymn = 12855, // Boss->self, no cast, single-target
    ScarletHymnPlayer = 13014, // RapturousEcho->player, no cast, single-target
    ScarletHymnBoss = 13015, // RapturousEcho->Suzaku3, no cast, single-target

    MesmerizingMelody = 13018, // Boss->self, 4s cast, range 41 circle
    RuthlessRefrain = 13019, // Boss->self, 4s cast, range 41 circle

    WellOfFlame = 13025, // Boss->self, 4s cast, range 41 width 20 rect

    ScathingNetStack = 12867, // Helper->player, no cast, range 6 circle

    PhantomFlurryCombo = 13020, // Boss->self, 4s cast, single-target
    PhantomFlurryHit = 13021, // Helper->players, no cast, single-target
    PhantomFlurryKnockback = 13022, // Helper->self, 6s cast, range 41 180-degree cone

    Hotspot = 13026, // Helper->self, 0.9s cast, range 21 90-degree cone

    CloseQuarterCrescendo = 13028, // Boss->self, 4s cast, single-target
    PayThePiperNorth = 13031, // NorthernPyre->player, no cast, single-target
    PayThePiperEast = 13032, // EasternPyre->player, no cast, single-target
    PayThePiperSouth = 13034, // SouthernPyre->player, no cast, single-target
    PayThePiperWest = 13033, // WesternPyre->player, no cast, single-target

    UnknownAbility4 = 12846, // Boss->location, no cast, single-target
    UnknownAbility5 = 12858, // Boss->self, no cast, single-target
}

public enum SID : uint
{
    Burns = 530, // ScarletLady->player, extra=0x1/0x2/0x3/0x4
    DamageUp = 505, // RapturousEcho->player, extra=0x1/0x2/0x3/0x4/0x5/0x6/0x7/0x8/0x9/0xA
    HPBoost = 586, // none->ScarletLady, extra=0xE/0xF
    LoomingCrescendo = 1699, // none->player, extra=0x0
    LovesTrueForm = 1630, // Boss->Boss, extra=0xC6
    PayingThePiper = 1681, // Pyre->player, extra=0x8
    PhysicalVulnerabilityUp = 695, // Helper->player, extra=0x0
    PrimaryTarget = 1689, // ScarletLady->player, extra=0x0
    Stun = 149, // Helper->player, extra=0x0
    Suppuration = 375, // ScarletLady->player, extra=0x1/0x2/0x3/0x4
    VulnerabilityDown = 350, // none->ScarletLady, extra=0x0
    VulnerabilityUp = 202, // ScarletTailFeather->player, extra=0x1
}

public enum IconID : uint
{
    Spreadmarker = 139, // player
    Stackmarker = 161, // player
}

public enum TetherID : uint
{
    Tether_14 = 14, // ScarletLady->ScarletLady
    Tether_79 = 79, // Suzaku2->Boss
}

public enum Direction { Unset = -1, North = 0, East = 1, South = 2, West = 3 };

class Cremate(BossModule module) : Components.SingleTargetCast(module, ActionID.MakeSpell(AID.Cremate));
class ScreamsOfTheDamned(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ScreamsOfTheDamned));
class AshesToAshes(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.AshesToAshes));
class ScarletFever(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.ScarletFever));
class SouthronStar(BossModule module) : Components.RaidwideCast(module, ActionID.MakeSpell(AID.SouthronStar));
class Rout(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Rout), new AOEShapeRect(55, 3));
class RekindleSpread(BossModule module) : Components.SpreadFromIcon(module, (uint)IconID.Spreadmarker, ActionID.MakeSpell(AID.RekindleSpread), 6, 5.1f);
class FleetingSummer(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.FleetingSummer), new AOEShapeCone(40, 45.Degrees()));

class RapturousEcho(BossModule module) : BossComponent(module)
{
    private const float _radius = 1.5f;
    private readonly List<Actor> _orbs = [];

    public override void DrawArenaForeground(int pcSlot, Actor pc)
    {
        foreach (var orb in _orbs)
            Arena.AddCircle(orb.Position, _radius, Colors.Object);
    }

    public override void OnActorCreated(Actor actor)
    {
        if ((OID)actor.OID == OID.RapturousEcho)
            _orbs.Add(actor);
    }

    public override void OnEventCast(Actor caster, ActorCastEvent spell)
    {
        if ((OID)caster.OID == OID.RapturousEcho && (AID)spell.Action.ID is AID.ScarletHymnPlayer or AID.ScarletHymnBoss)
            _orbs.Remove(caster);
    }

    public override void OnActorDestroyed(Actor actor)
    {
        if ((OID)actor.OID == OID.RapturousEcho)
            _orbs.Remove(actor);
    }
}

public class RapturousEchoTowers(BossModule module) : Components.GenericTowers(module)
{
    private readonly HashSet<ulong> _seenInstanceIDs = [];
    private bool _transitioned = false;

    public override void OnActorEAnim(Actor actor, uint state)
    {
        if (!_transitioned && (OID)actor.OID == OID.RapturousEchoPlatform && state != 0x00010002 && !_seenInstanceIDs.Contains(actor.InstanceID))
        {
            Towers.Add(new(actor.Position, 0.7f, minSoakers: 1, maxSoakers: 1));
            _seenInstanceIDs.Add(actor.InstanceID);
        }
    }

    public override void OnActorDestroyed(Actor actor)
    {
        if ((OID)actor.OID == OID.Suzaku3)
        {
            Towers.Clear();
            _transitioned = true;
        }
    }
}

class RapturousEchoDance(BossModule module) : BossComponent(module)
{
    private Direction _faceDirection = Direction.Unset;
    private enum Platform
    {
        North = 0x00080004,
        East = 0x02000100,
        South = 0x00400020,
        West = 0x10000800
    };
    private bool _transitioned = false;
    private readonly Dictionary<ulong, (WPos Position, uint State)> _platformData = [];

    public override void OnActorEAnim(Actor actor, uint state)
    {
        if (_transitioned || actor.OID != (uint)OID.RapturousEchoPlatform)
            return;

        _platformData[actor.InstanceID] = (actor.Position, state);
    }

    public override void OnActorDestroyed(Actor actor)
    {
        if ((OID)actor.OID == OID.Suzaku3)
        {
            _faceDirection = Direction.Unset;
            _transitioned = true;
        }
    }

    public override void AddAIHints(int slot, Actor actor, PartyRolesConfig.Assignment assignment, AIHints hints)
    {
        if (_transitioned || actor != Module.Raid.Player())
            return;

        foreach (var platform in _platformData)
        {
            if ((platform.Value.Position - Module.Raid.Player()!.Position).LengthSq() < 0.7f)
            {
                switch ((Platform)platform.Value.State)
                {
                    case Platform.North:
                        _faceDirection = Direction.North;
                        break;
                    case Platform.East:
                        _faceDirection = Direction.East;
                        break;
                    case Platform.South:
                        _faceDirection = Direction.South;
                        break;
                    case Platform.West:
                        _faceDirection = Direction.West;
                        break;
                }
            }
        }

        switch (_faceDirection)
        {
            case Direction.Unset:
                return;
            case Direction.North:
                hints.ForbiddenDirections.Add((Angle.FromDirection(new WDir(0, 5)), 175.Degrees(), WorldState.CurrentTime));
                break;
            case Direction.East:
                hints.ForbiddenDirections.Add((Angle.FromDirection(new WDir(-5, 0)), 175.Degrees(), WorldState.CurrentTime));
                break;
            case Direction.South:
                hints.ForbiddenDirections.Add((Angle.FromDirection(new WDir(0, -5)), 175.Degrees(), WorldState.CurrentTime));
                break;
            case Direction.West:
                hints.ForbiddenDirections.Add((Angle.FromDirection(new WDir(5, 0)), 175.Degrees(), WorldState.CurrentTime));
                break;
        }
    }
}

// class WingAndAPrayerTailFeather(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.WingAndAPrayerTailFeather), new AOEShapeCircle(9));
// class WingAndAPrayerPlume(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.WingAndAPrayerPlume), new AOEShapeCircle(9));

class ScarletFeverArenaChange(BossModule module) : Components.GenericAOEs(module)
{
    private static readonly AOEShapeCircle s_circle = new(Ex7Suzaku.InnerRadius);
    private AOEInstance? _aoe;

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor) => Utils.ZeroOrOne(_aoe);

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        if ((AID)spell.Action.ID == AID.ScarletFever && Module.Arena.Bounds == Ex7Suzaku.Phase1Bounds)
            _aoe = new(s_circle, Module.Center, default, Module.CastFinishAt(spell, 7));
    }

    public override void OnActorEAnim(Actor actor, uint state)
    {
        if ((OID)actor.OID == OID.RapturousEchoPlatform && state == 0x00040008)
            Module.Arena.Bounds = Ex7Suzaku.Phase2Bounds;
    }
}
class MesmerizingMelody(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.MesmerizingMelody), s_knockbackDistance, kind: Kind.TowardsOrigin)
{
    private static readonly float s_knockbackDistance = 11;
    private static readonly float s_safeDistance = Ex7Suzaku.OuterRadius - Ex7Suzaku.InnerRadius - s_knockbackDistance - 0.5f;
    private (WPos, DateTime) _data;

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        base.OnCastStarted(caster, spell);
        if (spell.Action == WatchedAction)
            _data = (caster.Position, Module.CastFinishAt(spell, 0.5f));
    }

    public override void AddAIHints(int slot, Actor actor, PartyRolesConfig.Assignment assignment, AIHints hints)
    {
        if (Sources(slot, actor).Any() || _data.Item2 > Module.WorldState.CurrentTime) // 0.5s delay to wait for action effect
            hints.AddForbiddenZone(ShapeDistance.InvertedDonutSector(_data.Item1, Ex7Suzaku.OuterRadius - s_safeDistance, Ex7Suzaku.OuterRadius, default, 180.Degrees()), _data.Item2.AddSeconds(-0.5f));
    }
}
class RuthlessRefrain(BossModule module) : Components.KnockbackFromCastTarget(module, ActionID.MakeSpell(AID.RuthlessRefrain), s_knockbackDistance, kind: Kind.AwayFromOrigin)
{
    private static readonly float s_knockbackDistance = 11;
    private static readonly float s_safeDistance = Ex7Suzaku.OuterRadius - Ex7Suzaku.InnerRadius - s_knockbackDistance - 0.5f;
    private (WPos, DateTime) _data;

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        base.OnCastStarted(caster, spell);
        if (spell.Action == WatchedAction)
            _data = (caster.Position, Module.CastFinishAt(spell, 0.5f));
    }

    public override void AddAIHints(int slot, Actor actor, PartyRolesConfig.Assignment assignment, AIHints hints)
    {
        if (Sources(slot, actor).Any() || _data.Item2 > Module.WorldState.CurrentTime) // 0.5s delay to wait for action effect
            hints.AddForbiddenZone(ShapeDistance.InvertedDonutSector(_data.Item1, Ex7Suzaku.InnerRadius, Ex7Suzaku.InnerRadius + s_safeDistance, default, 180.Degrees()), _data.Item2.AddSeconds(-0.5f));
    }
}
class PayThePiper(BossModule module) : BossComponent(module)
{
    private bool _isLoomingCrescendo = false;
    private Direction _marchDirection = Direction.Unset;

    public override void OnTethered(Actor source, ActorTetherInfo tether)
    {
        var target = WorldState.Actors.Find(tether.Target)!;
        if (target != Module.Raid.Player() || (TetherID)tether.ID != TetherID.Tether_79)
            return;
        switch ((OID)source.OID)
        {
            case OID.NorthernPyre:
                _marchDirection = Direction.North;
                break;
            case OID.EasternPyre:
                _marchDirection = Direction.East;
                break;
            case OID.SouthernPyre:
                _marchDirection = Direction.East;
                break;
            case OID.WesternPyre:
                _marchDirection = Direction.West;
                break;
        }
    }

    public override void OnStatusGain(Actor actor, ActorStatus status)
    {
        if (actor != Module.Raid.Player())
            return;
        switch ((SID)status.ID)
        {
            case SID.LoomingCrescendo:
                _isLoomingCrescendo = true;
                break;
            case SID.PayingThePiper:
                _isLoomingCrescendo = false;
                break;
        }
    }

    public override void OnStatusLose(Actor actor, ActorStatus status)
    {
        if (actor != Module.Raid.Player())
            return;
        if ((SID)status.ID == SID.LoomingCrescendo)
            _isLoomingCrescendo = false;
    }

    public override void AddAIHints(int slot, Actor actor, PartyRolesConfig.Assignment assignment, AIHints hints)
    {
        if (_isLoomingCrescendo)
        {
            var safeCenter = new WPos();
            var safeOffset = Ex7Suzaku.OuterRadius + Ex7Suzaku.InnerRadius + 0.5f;
            var rotation = 0.Degrees();

            switch (_marchDirection)
            {
                case Direction.Unset:
                    return;
                case Direction.North:
                    safeCenter = new WPos(Ex7Suzaku.ArenaCenter.X, Ex7Suzaku.ArenaCenter.Z + safeOffset);
                    rotation = 90.Degrees();
                    break;
                case Direction.East:
                    safeCenter = new WPos(Ex7Suzaku.ArenaCenter.X - safeOffset, Ex7Suzaku.ArenaCenter.Z);
                    rotation = 0.Degrees();
                    break;
                case Direction.South:
                    safeCenter = new WPos(Ex7Suzaku.ArenaCenter.X, Ex7Suzaku.ArenaCenter.Z - safeOffset);
                    rotation = 90.Degrees();
                    break;
                case Direction.West:
                    safeCenter = new WPos(Ex7Suzaku.ArenaCenter.X + safeOffset, Ex7Suzaku.ArenaCenter.Z);
                    rotation = 0.Degrees();
                    break;
            }

            hints.AddForbiddenZone(ShapeDistance.Rect(Ex7Suzaku.ArenaCenter, rotation, Ex7Suzaku.InnerRadius + 0.5f, Ex7Suzaku.InnerRadius + 0.5f, Ex7Suzaku.OuterRadius));
            hints.AddForbiddenZone(ShapeDistance.InvertedCircle(safeCenter, Ex7Suzaku.OuterRadius));
        }
    }
}
class WellOfFlame(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.WellOfFlame), new AOEShapeRect(41, 10));
class ScathingNetStack(BossModule module) : Components.StackWithIcon(module, (uint)IconID.Stackmarker, ActionID.MakeSpell(AID.ScathingNetStack), 6, 5.1f, 8);
class PhantomFlurryCombo(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PhantomFlurryCombo), new AOEShapeCone(41, 90.Degrees()));
class PhantomFlurryKnockback(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.PhantomFlurryKnockback), new AOEShapeCone(41, 90.Degrees()));
class Hotspot(BossModule module) : Components.SelfTargetedAOEs(module, ActionID.MakeSpell(AID.Hotspot), new AOEShapeCone(21, 45.Degrees()));
class Ex7SuzakuStates : StateMachineBuilder
{
    public Ex7SuzakuStates(BossModule module) : base(module)
    {
        TrivialPhase()
            .ActivateOnEnter<Cremate>()
            .ActivateOnEnter<ScreamsOfTheDamned>()
            .ActivateOnEnter<AshesToAshes>()
            .ActivateOnEnter<ScarletFever>()
            .ActivateOnEnter<ScarletFeverArenaChange>()
            .ActivateOnEnter<SouthronStar>()
            .ActivateOnEnter<Rout>()
            .ActivateOnEnter<RekindleSpread>()
            .ActivateOnEnter<FleetingSummer>()
            .ActivateOnEnter<RapturousEcho>()
            .ActivateOnEnter<RapturousEchoTowers>()
            .ActivateOnEnter<RapturousEchoDance>()
            // .ActivateOnEnter<WingAndAPrayerTailFeather>()
            // .ActivateOnEnter<WingAndAPrayerPlume>()
            .ActivateOnEnter<MesmerizingMelody>()
            .ActivateOnEnter<RuthlessRefrain>()
            .ActivateOnEnter<PayThePiper>()
            .ActivateOnEnter<WellOfFlame>()
            .ActivateOnEnter<ScathingNetStack>()
            .ActivateOnEnter<PhantomFlurryCombo>()
            .ActivateOnEnter<PhantomFlurryKnockback>()
            .ActivateOnEnter<Hotspot>();
    }
}

[ModuleInfo(BossModuleInfo.Maturity.WIP, Contributors = "Kismet", GroupType = BossModuleInfo.GroupType.CFC, GroupID = 597, NameID = 7702)]
public class Ex7Suzaku(WorldState ws, Actor primary) : BossModule(ws, primary, ArenaCenter, Phase1Bounds)
{
    public static readonly int InnerRadius = 4;
    public static readonly int OuterRadius = 20;
    public static readonly WPos ArenaCenter = new(100, 100);
    public static readonly ArenaBoundsCircle Phase1Bounds = new(OuterRadius);
    public static readonly ArenaBoundsComplex Phase2Bounds = new([new Donut(ArenaCenter, InnerRadius, OuterRadius)]);

    protected override void DrawEnemies(int pcSlot, Actor pc)
    {
        Arena.Actor(PrimaryActor);
        Arena.Actors(Enemies(OID.ScarletLady), Colors.Vulnerable);
    }
}