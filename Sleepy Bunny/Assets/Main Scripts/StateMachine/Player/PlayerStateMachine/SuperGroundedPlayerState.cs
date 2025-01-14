using System;
using UnityEngine;
using PlayerStM.BaseStates;

namespace PlayerStM.SuperState
{
    /// <summary>
    /// The most default super state becasue it handles everything while on ground
    /// and not doing a more advanced task
    /// </summary>
    public class SuperGroundedPlayerState : BasePlayerState
    {
        public SuperGroundedPlayerState(PlayerStateMachine currentContext
            , StateFactory stateFactory)
            : base(currentContext, stateFactory)
        {
            IsRootState = true;
            InitializeSubState();
        }

        public override void CheckSwitchState()
        {
            if (Ctx.TheInput.JumpCtx.ReadValueAsButton())
            {
                SwitchState(Factory.SuperJump());
            }
            else if (Ctx.IsClimbing)
            {
                SwitchState(Factory.SuperClimb());
            }
            else if (Ctx.IsGrabing)
            {
                SwitchState(Factory.SuperGrab());
            }
        }

        public override void EnterState()
        {
            Debug.Log("Grounded");
        }

        public override void ExitState()
        {
        }

        public override void InitializeSubState()
        {
            if (Ctx.TheInput.MoveCtx.ReadValue<Vector2>() != Vector2.zero)
            {
                SetSubState(Factory.SubMovement());
            }
            else
            {
                SetSubState(Factory.SubIdle());
            }

            //else if (!Ctx.IsGrounded)
            //{
            //    SetSubState(Factory.SubFalling());
            //}
        }

        public override void FixedUpdateState()
        {
            CheckSwitchState();
        }

        public override void UpdateState()
        {
        }

        public override void CheckSwitchAnimation()
        {
           
        }
    }
}