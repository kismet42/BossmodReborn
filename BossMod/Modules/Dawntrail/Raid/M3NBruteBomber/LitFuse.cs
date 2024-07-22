namespace BossMod.Dawntrail.Raid.M3NBruteBomber;

public class LitFuse(BossModule module) : Components.GenericAOEs(module)
{
    private List<AOEInstance> _aoes = [];
    private static readonly AOEShapeCircle circle = new(8);
    private bool sorted;
    private bool fusesOfFury;

    public override IEnumerable<AOEInstance> ActiveAOEs(int slot, Actor actor)
    {
        var towers = Module.FindComponent<BarbarousBarrageTower>()!.Towers;
        if (_aoes.Count > 3)
            for (var i = 0; i < 4; i++)
                yield return _aoes[i] with { Color = ArenaColor.Danger, Risky = towers.Count == 0 };
        if (_aoes.Count > 7)
            for (var i = 4; i < 8; i++)
                yield return _aoes[i] with { Risky = false };
    }

    public override void OnCastStarted(Actor caster, ActorCastInfo spell)
    {
        if ((AID)spell.Action.ID == AID.FusesOfFury)
            fusesOfFury = true;
    }

    public override void Update()
    {
        var towers = Module.FindComponent<BarbarousBarrageTower>()!.Towers;
        if (towers.Count > 0 && fusesOfFury && _aoes.Count == 8)
        {
            var updatedAOEs = new List<AOEInstance>();
            foreach (var a in _aoes)
            {
                var updatedAOE = new AOEInstance(a.Shape, a.Origin, default, a.Activation.AddSeconds(3));
                updatedAOEs.Add(updatedAOE);
            }
            _aoes = updatedAOEs;
            fusesOfFury = false;
        }
    }

    public override void OnStatusGain(Actor actor, ActorStatus status)
    {
        switch ((SID)status.ID)
        {
            case SID.LitFuseLong:
                _aoes.Add(new(circle, actor.Position, default, Module.WorldState.FutureTime(10.4f)));
                break;
            case SID.LitFuseShort:
                _aoes.Add(new(circle, actor.Position, default, Module.WorldState.FutureTime(7.4f)));
                break;
        }
        if (_aoes.Count == 8 && !sorted)
        {
            _aoes.Sort((x, y) => x.Activation.CompareTo(y.Activation));
            sorted = true;
        }
    }

    public override void OnCastFinished(Actor caster, ActorCastInfo spell)
    {
        if (_aoes.Count > 0)
            switch ((AID)spell.Action.ID)
            {
                case AID.SelfDestruct1:
                case AID.SelfDestruct2:
                    _aoes.RemoveAt(0);
                    sorted = false;
                    fusesOfFury = false;
                    break;
            }
    }

    public override void AddGlobalHints(GlobalHints hints)
    {
        var towers = Module.FindComponent<BarbarousBarrageTower>()!.Towers;
        if (_aoes.Count > 0 && towers.Count > 0)
            hints.Add("Don't panic! AOEs start resolving 3.8s after towers.");
    }
}
