using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GX.VarSystem;
using GX.StateMachineSystem;


namespace GX.MotorSystem
{
    public abstract class MotorState : StateBehaviourTicked
    {
        private static YieldInstruction y = new WaitForFixedUpdate();
        protected override object YieldInstruction => y;
        [HideInInspector] public VarAccesser<Motor> motor = new VarAccesser<Motor>();
    }
}
