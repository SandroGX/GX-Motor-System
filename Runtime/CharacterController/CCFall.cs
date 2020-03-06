using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GX.StateMachineSystem;

namespace GX.MotorSystem
{
    public class CCFall : BasicMovement
    {

        public float terminalVelocity = 15;

        protected override void OnState(SMClient c)
        {
            base.OnState(c);

            motor[c].velocity = MotorUtil.MovUniVarDir(motor[c].velocity, motor[c].gravity.normalized * terminalVelocity, 1, terminalVelocity, 0, motor[c].gravity.magnitude);
        }
    }
}
