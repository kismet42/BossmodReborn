﻿namespace BossMod.Components;

// generic component for cleaving autoattacks; shows shape outline and warns when anyone other than main target is inside
// enemy OID == 0 means 'primary actor'
public class Cleave(BossModule module, ActionID aid, AOEShape shape, uint enemyOID = 0, bool activeForUntargetable = false, bool originAtTarget = false, bool activeWhileCasting = true) : CastCounter(module, aid)
{
    public AOEShape Shape { get; init; } = shape;
    public bool ActiveForUntargetable { get; init; } = activeForUntargetable;
    public bool ActiveWhileCasting { get; init; } = activeWhileCasting;
    public bool OriginAtTarget { get; init; } = originAtTarget;
    public DateTime NextExpected;
    private readonly IReadOnlyList<Actor> _enemies = module.Enemies(enemyOID != 0 ? enemyOID : module.PrimaryActor.OID);

    public override void AddHints(int slot, Actor actor, TextHints hints)
    {
        if (OriginsAndTargets().Any(e => e.target != actor && Shape.Check(actor.Position, e.origin.Position, e.angle)))
        {
            hints.Add("GTFO from cleave!");
        }
    }

    public override void AddAIHints(int slot, Actor actor, PartyRolesConfig.Assignment assignment, AIHints hints)
    {
        if (!OriginsAndTargets().Any())
            return;

        foreach (var (origin, target, angle) in OriginsAndTargets())
            if (actor != target)
                hints.AddForbiddenZone(Shape, origin.Position, angle, NextExpected);
            else
                AddTargetSpecificHints(actor, origin.Position, angle, hints);
    }

    private void AddTargetSpecificHints(Actor actor, WPos origin, Angle angle, AIHints hints)
    {
        switch (Shape)
        {
            case AOEShapeCircle circle:
                foreach (var a in Raid.WithoutSlot().Exclude(actor))
                    hints.AddForbiddenZone(circle, a.Position);
                break;

            case AOEShapeCone cone:
                if (Raid.WithoutSlot().Exclude(actor).InShape(cone, origin, angle).Any())
                    hints.AddForbiddenZone(ShapeDistance.Cone(origin, 100, angle, cone.HalfAngle));
                break;

            case AOEShapeRect rect:
                if (Raid.WithoutSlot().Exclude(actor).InShape(rect, origin, angle).Any())
                    hints.AddForbiddenZone(ShapeDistance.Rect(origin, angle, 100, default, rect.HalfWidth));
                break;
        }
    }

    public override void DrawArenaForeground(int pcSlot, Actor pc)
    {
        foreach (var e in OriginsAndTargets())
        {
            Shape.Outline(Arena, e.origin.Position, e.angle);
        }
    }

    private IEnumerable<(Actor origin, Actor target, Angle angle)> OriginsAndTargets()
    {
        foreach (var enemy in _enemies)
        {
            if (enemy.IsDead)
                continue;

            if (!ActiveForUntargetable && !enemy.IsTargetable)
                continue;

            if (!ActiveWhileCasting && enemy.CastInfo != null)
                continue;

            var target = WorldState.Actors.Find(enemy.TargetID);
            if (target != null)
            {
                yield return (OriginAtTarget ? target : enemy, target, Angle.FromDirection(target.Position - enemy.Position));
            }
        }
    }
}
