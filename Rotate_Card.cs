using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class Rotate_Card : MonoBehaviour
{
	// Token: 0x060001A4 RID: 420 RVA: 0x00009708 File Offset: 0x00007908
	private void Start()
	{
		foreach (SpriteRenderer spriteRenderer in this.sprites)
		{
			if (this.mask_on)
			{
				spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
			}
			else
			{
				spriteRenderer.maskInteraction = SpriteMaskInteraction.None;
			}
		}
		this.start_angles = this.this_card.localEulerAngles;
		this.start_scale = this.Point_Scale.localScale;
		base.StartCoroutine(this.Rotate_test());
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00009775 File Offset: 0x00007975
	private IEnumerator Rotate_test()
	{
		for (;;)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			this.update_plus += Time.deltaTime * this.speed;
			this.this_card.localRotation = Quaternion.Euler(this.start_angles.x + this._x.Evaluate(this.update_plus) * this.Multi, this.start_angles.y + this._y.Evaluate(this.update_plus) * this.Multi, this.start_angles.y);
			if (!this.scale_test)
			{
				this.A = ((Mathf.Abs(this.start_angles.x + this._x.Evaluate(this.update_plus) * this.Multi) > Mathf.Abs(this.start_angles.y + this._y.Evaluate(this.update_plus) * this.Multi)) ? Mathf.Abs(this.start_angles.x + this._x.Evaluate(this.update_plus) * this.Multi) : Mathf.Abs(this.start_angles.y + this._y.Evaluate(this.update_plus) * this.Multi));
				this.Point_Scale.localScale = new Vector3(this.start_scale.x, this.start_scale.y, this.scale_0.Evaluate(this.A));
			}
			if (this.front_back)
			{
				Vector3 from = Camera.main.transform.position - this.this_card.position;
				Vector3 to = -this.this_card.forward;
				this.angle_test = Vector3.SignedAngle(from, to, Vector3.back);
				if (Mathf.Abs(this.angle_test) > 90f)
				{
					GameObject[] array = this.Fronts_go;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SetActive(false);
					}
					array = this.Backs_go;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SetActive(true);
					}
				}
				else
				{
					GameObject[] array = this.Fronts_go;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SetActive(true);
					}
					array = this.Backs_go;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].SetActive(false);
					}
				}
			}
		}
		yield break;
	}

	// Token: 0x040001A9 RID: 425
	[SerializeField]
	private Transform this_card;

	// Token: 0x040001AA RID: 426
	[SerializeField]
	private Transform Point_Scale;

	// Token: 0x040001AB RID: 427
	[SerializeField]
	private AnimationCurve _x;

	// Token: 0x040001AC RID: 428
	[SerializeField]
	private AnimationCurve _y;

	// Token: 0x040001AD RID: 429
	[SerializeField]
	private AnimationCurve scale_0;

	// Token: 0x040001AE RID: 430
	[SerializeField]
	private float speed;

	// Token: 0x040001AF RID: 431
	[SerializeField]
	private Vector3 start_angles;

	// Token: 0x040001B0 RID: 432
	[SerializeField]
	private Vector3 start_scale;

	// Token: 0x040001B1 RID: 433
	[SerializeField]
	private bool scale_test;

	// Token: 0x040001B2 RID: 434
	[SerializeField]
	private float Multi;

	// Token: 0x040001B3 RID: 435
	[SerializeField]
	private float A;

	// Token: 0x040001B4 RID: 436
	[SerializeField]
	private float angle_test;

	// Token: 0x040001B5 RID: 437
	private float update_plus;

	// Token: 0x040001B6 RID: 438
	[SerializeField]
	private GameObject[] Fronts_go;

	// Token: 0x040001B7 RID: 439
	[SerializeField]
	private GameObject[] Backs_go;

	// Token: 0x040001B8 RID: 440
	[SerializeField]
	private bool front_back;

	// Token: 0x040001B9 RID: 441
	[SerializeField]
	private SpriteRenderer[] sprites;

	// Token: 0x040001BA RID: 442
	[SerializeField]
	private bool mask_on;
}
