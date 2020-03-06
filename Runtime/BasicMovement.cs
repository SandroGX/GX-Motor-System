using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GX.StateMachineSystem;

namespace GX.MotorSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Basic Movement", menuName = "Motor/Basic Movement", order = 0)]
    public class BasicMovement : MotorState
    {
        
        public float minVel;
        public float maxVel;
        public float minAcel;
        public float maxAcel;

        public float minAngVel;
        public float maxAngVel;
        public float minAngAcel;
        public float maxAngAcel;

        public bool ignorePrevVel;

        
        protected override void OnState(SMClient c)
        {
            float vel = motor[c].velocity.magnitude / Time.fixedDeltaTime;
            float crrMinVel = (!ignorePrevVel && vel < minVel) ? vel : minVel;
            float crrMaxVel = (!ignorePrevVel && vel > maxVel) ? vel : maxVel;

            Vector3 velDes;
            if (motor[c].input != Vector3.zero) velDes = motor[c].input * crrMaxVel;
            else if(motor[c].velocity != Vector3.zero) velDes = motor[c].velocity.normalized * crrMinVel;
            else velDes = motor[c].lookDir * crrMinVel;

            motor[c].velocity = MotorUtil.MovUniVar(motor[c].velocity, velDes, crrMinVel, crrMaxVel, minAcel, maxAcel);
        }


        public override void OnStateEnter(SMClient c)
        {
            MotorUtil.NavAgent(motor[c], this);
        }
    }
}
