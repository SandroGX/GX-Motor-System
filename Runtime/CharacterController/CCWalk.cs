using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GX.StateMachineSystem;


namespace GX.MotorSystem
{
    public class CCWalk : BasicMovement
    {
        public float maxFallSpeed = 35;
        public float staticFriction = 1.5f, dynamicFriction = 1.5f;
        

        protected override void OnState(SMClient c)
        {
            //normal force
            Vector3 normal = motor[c].groundInfo.surfaceNormal * motor[c].gravity.magnitude * Mathf.Cos(Vector3.Angle(motor[c].gravity, -motor[c].groundInfo.surfaceNormal) * Mathf.Deg2Rad);
            //normal force + gravity
            Vector3 slopeRaw = normal + motor[c].gravity;
            //friction force
            float friction = normal.magnitude * (motor[c].velocity == Vector3.zero ? staticFriction * motor[c].groundInfo.surfaceStaticFriction : dynamicFriction * motor[c].groundInfo.surfaceDynamicFriction);

            //slope force magnitude counting with friction
            float slopeMag = slopeRaw.magnitude - friction;

            //slope force
            Vector3 slope = slopeMag > 0 ? slopeRaw.normalized * maxFallSpeed : Vector3.zero;
            motor[c].velocity = MotorUtil.MovUniVarDir(motor[c].velocity, slope, 0, maxFallSpeed, 0, Mathf.Abs(slopeMag));

            //add platform velocity with friction as max acel
            motor[c].velocity = MotorUtil.MovUniVarDir(motor[c].velocity, motor[c].groundInfo.platformVel, 0, Mathf.Infinity, 0, friction);

            //input direction on surface
            MotorUtil.MotorInputOnSurface(motor[c]);
            base.OnState(c);

            //rotate
            float angle = (motor[c].input != Vector3.zero) ? MotorUtil.GetAngleWithSignal(motor[c].transform.forward, motor[c].lookDir) : 0;
            motor[c].angularVelocity.y = MotorUtil.MovUniVar(motor[c].angularVelocity.y, angle/Time.fixedDeltaTime, minAngVel, maxAngVel, minAngAcel, maxAngAcel);

            motor[c].angularVelocity += motor[c].groundInfo.platformAngVel;


            //motor.transform.up = -cMotor.gravidadeDirecao.normalized; //try putting perpendicular to the ground
        }

        public override void OnStateEnter(SMClient c)
        {
            base.OnStateEnter(c);
            Vector3 v = Vector3.Project(motor[c].velocity, motor[c].gravity);
            motor[c].velocity -= v;
            v *= Mathf.Cos(Vector3.Angle(motor[c].gravity, -motor[c].groundInfo.surfaceNormal) * Mathf.Deg2Rad);
            motor[c].velocity += v;
        }
    }
}
