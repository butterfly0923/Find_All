using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000049 RID: 73
public class Pasanger : MonoBehaviour
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x060001DA RID: 474 RVA: 0x0000A520 File Offset: 0x00008720
	public Transform Point_pasanger
	{
		get
		{
			return this.point_pasanger;
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000A528 File Offset: 0x00008728
	private void Start()
	{
		this.pasanger_stay_SR = this.pasanger_stay.GetComponent<SpriteRenderer>();
		this.sit_in_car_SR = this.sit_in_car.GetComponent<SpriteRenderer>();
		this.camera_transform = Camera.main.transform;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000A55C File Offset: 0x0000875C
	public void Resp_personage()
	{
		for (int i = 0; i < 3; i++)
		{
			Vector3 vector = new Vector3(Random.Range(this.left_end.position.x, this.right_end.position.x), this.left_end.position.y, this.left_end.position.z);
			Vector2 a = vector;
			Vector2 b = this.camera_transform.position;
			if (Vector2.Distance(a, b) > 35f)
			{
				Debug.Log(string.Format("RESP - {0} {1}", this.point_pasanger.name, vector));
				this.point_pasanger.position = vector;
				this.pasanger_stay.SetActive(true);
				this.pasanger_stay_SR.color = new Color(this.pasanger_stay_SR.color.r, this.pasanger_stay_SR.color.g, this.pasanger_stay_SR.color.b, 1f);
				this.complite = true;
				return;
			}
		}
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0000A673 File Offset: 0x00008873
	public bool Pasanger_complite()
	{
		return this.complite;
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0000A67B File Offset: 0x0000887B
	public void Sit_in_car()
	{
		base.StartCoroutine(this.IE_Sit_in_car());
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0000A68A File Offset: 0x0000888A
	private IEnumerator IE_Sit_in_car()
	{
		this.sit_in_car.SetActive(true);
		float value = 0f;
		while (value <= 1f)
		{
			value += Time.deltaTime * 2f;
			this.pasanger_stay_SR.color = new Color(this.pasanger_stay_SR.color.r, this.pasanger_stay_SR.color.g, this.pasanger_stay_SR.color.b, 1f - value);
			this.sit_in_car_SR.color = new Color(this.sit_in_car_SR.color.r, this.sit_in_car_SR.color.g, this.sit_in_car_SR.color.b, value);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.pasanger_stay.SetActive(false);
		yield break;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0000A699 File Offset: 0x00008899
	public void Exit_car()
	{
		this.sit_in_car.SetActive(false);
		this.complite = false;
		Debug.Log("Пассажир выходит из машины");
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0000A6B8 File Offset: 0x000088B8
	[ContextMenu("Start_Color")]
	public void Start_Color()
	{
		base.StartCoroutine(this.IE_Start_color());
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0000A6C7 File Offset: 0x000088C7
	private IEnumerator IE_Start_color()
	{
		yield return new WaitForSeconds(1f);
		this.pasanger_stay.SetActive(true);
		this.pasanger_stay_SR.color = new Color(this.pasanger_stay_SR.color.r, this.pasanger_stay_SR.color.g, this.pasanger_stay_SR.color.b, 1f);
		this.sprite_start.enabled = false;
		this.complite = true;
		for (;;)
		{
			float seconds = Random.Range(70f, 100f);
			yield return new WaitForSeconds(seconds);
			if (!this.complite)
			{
				Debug.Log("Resp_personage");
				this.Resp_personage();
			}
		}
		yield break;
	}

	// Token: 0x04000213 RID: 531
	[SerializeField]
	private Transform left_end;

	// Token: 0x04000214 RID: 532
	[SerializeField]
	private Transform right_end;

	// Token: 0x04000215 RID: 533
	[SerializeField]
	private Transform point_pasanger;

	// Token: 0x04000216 RID: 534
	[SerializeField]
	private GameObject pasanger_stay;

	// Token: 0x04000217 RID: 535
	[SerializeField]
	private GameObject sit_in_car;

	// Token: 0x04000218 RID: 536
	[SerializeField]
	private SpriteRenderer pasanger_stay_SR;

	// Token: 0x04000219 RID: 537
	[SerializeField]
	private SpriteRenderer sit_in_car_SR;

	// Token: 0x0400021A RID: 538
	[SerializeField]
	private SpriteRenderer sprite_start;

	// Token: 0x0400021B RID: 539
	[SerializeField]
	private bool complite;

	// Token: 0x0400021C RID: 540
	[SerializeField]
	private Transform camera_transform;
}
