using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GX.StateMachineSystem;

namespace GX.MotorSystem
{
    public class CCJump : CCAccelaration
    {

        public float jumpHeight = 4;
       
        protected override void OnState(SMClient c)
        {
            float jumpVel = Mathf.Sqrt(-2 * -motor[c].gravity.magnitude * jumpHeight);
            motor[c].velocity += -motor[c].gravity.normalized * jumpVel * Time.fixedDeltaTime;

            base.OnState(c);  
        }
    }
}
