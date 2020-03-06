using UnityEngine;
using System.Collections;
using GX.StateMachineSystem;

namespace GX.MotorSystem
{
    [CreateAssetMenu(fileName = "Instant Accelaration", menuName = "Motor/Instant Accelaration", order = 1)]
    public class InstantAccelaration : MotorState
    {
        public float accelaration = 5;

        protected override void OnState(SMClient c)
        {
            motor[c].velocity += motor[c].input * accelaration;
        }
    }
}
