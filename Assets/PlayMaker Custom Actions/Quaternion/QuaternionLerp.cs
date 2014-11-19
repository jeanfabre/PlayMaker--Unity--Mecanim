// (c) Copyright HutongGames, LLC 2010-2012. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Quaternion")]
	[Tooltip("Interpolates between from and to by t and normalizes the result afterwards.")]
	[HelpUrl("https://hutonggames.fogbugz.com/default.asp?W1092")]
	public class QuaternionLerp : FsmStateAction
	{
		[RequiredField]
		[Tooltip("From Quaternion.")]
		public FsmQuaternion fromQuaternion;
		
		[RequiredField]
		[Tooltip("To Quaternion.")]
		public FsmQuaternion toQuaternion;
		
		[RequiredField]
		[Tooltip("Interpolate between fromQuaternion and toQuaternion by this amount. Value is clamped to 0-1 range. 0 = fromQuaternion; 1 = toQuaternion; 0.5 = half way between.")]
		[HasFloatSlider(0f, 1f)]
		public FsmFloat amount;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in this quaternion variable.")]
		public FsmQuaternion storeResult;

		[Tooltip("Repeat every frame. Useful if any of the values are changing.")]
		public bool everyFrame;

		public override void Reset()
		{
			fromQuaternion = new FsmQuaternion { UseVariable = true };
			toQuaternion = new FsmQuaternion { UseVariable = true };
			amount = 0.5f;
			storeResult = null;
			everyFrame = true;
		}

		public override void OnEnter()
		{
			DoQuatLerp();

			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoQuatLerp();
		}

		void DoQuatLerp()
		{
			storeResult.Value = Quaternion.Lerp(fromQuaternion.Value, toQuaternion.Value, amount.Value);
		}
	}
}

