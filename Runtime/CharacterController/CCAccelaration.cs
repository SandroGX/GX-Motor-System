using UnityEngine;
using GX.StateMachineSystem;

namespace GX.MotorSystem
{
    public class CCAccelaration : InstantAccelaration
    {

        protected override void OnState(SMClient c)
        {
            MotorUtil.MotorInputOnSurface(motor[c]);
            base.OnState(c);
        }
    }
}
