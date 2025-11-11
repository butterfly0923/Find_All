using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000041 RID: 65
public class Car_move_old : MonoBehaviour
{
	// Token: 0x060001AE RID: 430 RVA: 0x00009803 File Offset: 0x00007A03
	private void Start()
	{
		base.StartCoroutine(this.Update_car_right());
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00009814 File Offset: 0x00007A14
	private void FixedUpdate()
	{
		this._ro_O += this.speed_O;
		this._left_O.rotation = Quaternion.Euler(this._left_O.eulerAngles.x, this._left_O.eulerAngles.y, this._ro_O);
		this._right_O.rotation = Quaternion.Euler(this._left_O.eulerAngles.x, this._left_O.eulerAngles.y, this._ro_O);
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x000098A0 File Offset: 0x00007AA0
	private IEnumerator Update_car_right()
	{
		this.alpha_plus = true;
		this.alpha_minus = false;
		if (this.first)
		{
			this.first = false;
			this._alpha_float = this.first_alpha_float;
		}
		else
		{
			this._alpha_float = 0f;
		}
		while (this.alpha_plus)
		{
			this._alpha_float += this._step_alpha;
			if (this._alpha_float >= 1f)
			{
				this._alpha_float = 1f;
				this._car.position = new Vector3(this._alpha_curve.Evaluate(this._alpha_float), this._car.position.y, 31.25619f);
				this._car_K.localPosition = new Vector3(0f, this._up_down_car.Evaluate(this._alpha_float), 0f);
				this.alpha_plus = false;
				break;
			}
			this._car.position = new Vector3(this._alpha_curve.Evaluate(this._alpha_float), this._car.position.y, 31.25619f);
			this._car_K.localPosition = new Vector3(0f, this._up_down_car.Evaluate(this._alpha_float), 0f);
			yield return new WaitForSeconds(this._speed_alpha);
		}
		this._car.localScale = new Vector3(-2f, 2f, 2f);
		base.StartCoroutine(this.Update_car_left());
		this.speed_O *= -1f;
		yield break;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x000098AF File Offset: 0x00007AAF
	private IEnumerator Update_car_left()
	{
		this.alpha_plus = false;
		this.alpha_minus = true;
		while (this.alpha_minus)
		{
			this._alpha_float -= this._step_alpha;
			if (this._alpha_float <= 0f)
			{
				this._alpha_float = 0f;
				this._car.position = new Vector3(this._alpha_curve.Evaluate(this._alpha_float), this._car.position.y, this._car.position.z);
				this._car_K.localPosition = new Vector3(0f, this._up_down_car.Evaluate(this._alpha_float), 0f);
				this.alpha_minus = false;
				break;
			}
			this._car.position = new Vector3(this._alpha_curve.Evaluate(this._alpha_float), this._car.position.y, this._car.position.z);
			this._car_K.localPosition = new Vector3(0f, this._up_down_car.Evaluate(this._alpha_float), 0f);
			yield return new WaitForSeconds(this._speed_alpha);
		}
		base.StartCoroutine(this.Update_car_right());
		this._car.localScale = new Vector3(2f, 2f, 2f);
		this.speed_O *= -1f;
		yield break;
	}

	// Token: 0x040001BF RID: 447
	[SerializeField]
	private Transform _left_O;

	// Token: 0x040001C0 RID: 448
	[SerializeField]
	private Transform _right_O;

	// Token: 0x040001C1 RID: 449
	[SerializeField]
	private Transform _car;

	// Token: 0x040001C2 RID: 450
	[SerializeField]
	private Transform _car_K;

	// Token: 0x040001C3 RID: 451
	[SerializeField]
	private AnimationCurve _trail_car;

	// Token: 0x040001C4 RID: 452
	[SerializeField]
	private AnimationCurve _up_down_car;

	// Token: 0x040001C5 RID: 453
	[Header("Кривая для настройки плавности появления/исчезновения:")]
	[SerializeField]
	private AnimationCurve _alpha_curve;

	// Token: 0x040001C6 RID: 454
	[Space(5f)]
	[Header("Скорость появления/исчезновения:")]
	[SerializeField]
	private float _speed_alpha = 0.02f;

	// Token: 0x040001C7 RID: 455
	[Header("Шаг на который меняется параметр Curve:")]
	[SerializeField]
	private float _step_alpha = 0.001f;

	// Token: 0x040001C8 RID: 456
	[SerializeField]
	private float speed_O;

	// Token: 0x040001C9 RID: 457
	private bool alpha_plus;

	// Token: 0x040001CA RID: 458
	private bool alpha_minus;

	// Token: 0x040001CB RID: 459
	private float _alpha_float;

	// Token: 0x040001CC RID: 460
	[SerializeField]
	private bool first;

	// Token: 0x040001CD RID: 461
	[SerializeField]
	private float first_alpha_float;

	// Token: 0x040001CE RID: 462
	private float _ro_O;

	// Token: 0x040001CF RID: 463
	[SerializeField]
	private float Up;
}
