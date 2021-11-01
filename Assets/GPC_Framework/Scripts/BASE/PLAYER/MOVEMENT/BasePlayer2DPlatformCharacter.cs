using UnityEngine;

namespace GPC
{
	public class BasePlayer2DPlatformCharacter : ExtendedCustomMonoBehaviour
	{

		public float runPower = 10000f;

		public bool canAirSteer;


		public bool allow_left;


		public bool allow_right;





		public BaseInputController _inputController;

		private void Awake()
		{
			Init();
		}

		public virtual void Init()
		{
			_RB2D = GetComponent<Rigidbody2D>();
			_inputController = GetComponent<BaseInputController>();
			didInit = true;
		}

		public virtual void LateUpdate()
		{
			UpdateMovement();
		}

		public virtual void UpdateMovement()
		{
			if (!didInit)
				Init();

			_inputController.CheckInput();

			Vector2 moveVel = _RB2D.velocity;


			// direction keys
			if (_inputController.Left && allow_left)
			{
			//	Debug.Log("LEFT");
			//	moveVel.x = -runPower;
				_RB2D.AddForce(transform.right  * -runPower * Time.deltaTime);
			}
			else if (_inputController.Right && allow_right)
			{
			//	moveVel.x = runPower;
				_RB2D.AddForce(transform.right * runPower * Time.deltaTime);
			}
			else
			{
				if (allow_right || allow_left)
				{
					// stop if no left/right keys are being pressed
					moveVel.x = 0;
				}
			}







		}
	}
}