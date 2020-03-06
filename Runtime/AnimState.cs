using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GX.StateMachineSystem;

namespace GX.MotorSystem
{
    [CreateAssetMenu(fileName = "Anim", menuName = "Motor/Anim", order = 0)]
    public class AnimState : MotorState
    {
        public Anim[] conditions;


        protected override void OnState(SMClient c)
        {
            PlayConditions(motor[c]);
        }

        protected virtual void PlayConditions(Motor motor)
        {
            foreach (Anim condicao in conditions) condicao.SetParam(motor.anim);
        }

    }
}
