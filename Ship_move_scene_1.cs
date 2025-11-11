using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000B7 RID: 183
public class Ship_move_scene_1 : MonoBehaviour
{
	// Token: 0x06000514 RID: 1300 RVA: 0x0001862C File Offset: 0x0001682C
	public void Start_event()
	{
		base.StartCoroutine(this.IE_Ship_move_back());
		base.StartCoroutine(this.IE_Ship_move());
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x00018648 File Offset: 0x00016848
	public void Load_event()
	{
		this.ship_transform.localPosition = this.end_transform.localPosition;
		this.ship_back_1_transform.localPosition = this.end_back_1_transform.localPosition;
		this.ship_back_2_transform.localPosition = this.end_back_2_transform.localPosition;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x00018697 File Offset: 0x00016897
	private IEnumerator IE_Ship_move()
	{
		base.StartCoroutine(this.IE_event_stady_start());
		yield return base.StartCoroutine(this.IE_event_stady_end());
		Vector3 vector3_start = this.ship_transform.localPosition;
		Vector3 vector3_end = this.end_transform.localPosition;
		float value_ship = 0f;
		while (value_ship <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_ship += Time.deltaTime * this.speed_ship;
			this.ship_transform.localPosition = Vector3.Lerp(vector3_start, vector3_end, this.curve_ship_move.Evaluate(value_ship));
		}
		yield break;
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x000186A6 File Offset: 0x000168A6
	private IEnumerator IE_event_stady_start()
	{
		for (int i = 0; i < this.sprite_stady_start.Length; i++)
		{
			this.sprite_stady_start[i].gameObject.SetActive(true);
		}
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_alpha_start;
			for (int j = 0; j < this.sprite_stady_start.Length; j++)
			{
				this.sprite_stady_start[j].material.SetFloat("_Alpha", Mathf.Lerp(1f, 0f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		for (int k = 0; k < this.sprite_stady_start.Length; k++)
		{
			this.sprite_stady_start[k].gameObject.SetActive(false);
		}
		yield break;
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x000186B5 File Offset: 0x000168B5
	private IEnumerator IE_event_stady_end()
	{
		for (int i = 0; i < this.sprite_stady_end.Length; i++)
		{
			this.sprite_stady_end[i].gameObject.SetActive(true);
		}
		float value = 0f;
		while (value < 1f)
		{
			value += Time.deltaTime * this.speed_alpha_end;
			for (int j = 0; j < this.sprite_stady_end.Length; j++)
			{
				this.sprite_stady_end[j].color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x000186C4 File Offset: 0x000168C4
	private IEnumerator IE_Ship_move_back()
	{
		Vector3 vector3_back_1_start = this.ship_back_1_transform.localPosition;
		Vector3 vector3_back_1_end = this.end_back_1_transform.localPosition;
		Vector3 vector3_back_2_start = this.ship_back_2_transform.localPosition;
		Vector3 vector3_back_2_end = this.end_back_2_transform.localPosition;
		float value_ship = 0f;
		while (value_ship <= 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_ship += Time.deltaTime * this.speed_ship / 3f;
			this.ship_back_1_transform.localPosition = Vector3.Lerp(vector3_back_1_start, vector3_back_1_end, this.curve_ship_back_move.Evaluate(value_ship));
			this.ship_back_2_transform.localPosition = Vector3.Lerp(vector3_back_2_start, vector3_back_2_end, this.curve_ship_back_move.Evaluate(value_ship));
		}
		yield break;
	}

	// Token: 0x0400056B RID: 1387
	[SerializeField]
	private Transform ship_transform;

	// Token: 0x0400056C RID: 1388
	[SerializeField]
	private Transform end_transform;

	// Token: 0x0400056D RID: 1389
	[SerializeField]
	private AnimationCurve curve_ship_move;

	// Token: 0x0400056E RID: 1390
	[SerializeField]
	private float speed_ship;

	// Token: 0x0400056F RID: 1391
	[SerializeField]
	private SpriteRenderer[] sprite_stady_start;

	// Token: 0x04000570 RID: 1392
	[SerializeField]
	private SpriteRenderer[] sprite_stady_end;

	// Token: 0x04000571 RID: 1393
	[SerializeField]
	private float speed_alpha_start;

	// Token: 0x04000572 RID: 1394
	[SerializeField]
	private float speed_alpha_end;

	// Token: 0x04000573 RID: 1395
	[SerializeField]
	private Transform ship_back_1_transform;

	// Token: 0x04000574 RID: 1396
	[SerializeField]
	private Transform end_back_1_transform;

	// Token: 0x04000575 RID: 1397
	[SerializeField]
	private Transform ship_back_2_transform;

	// Token: 0x04000576 RID: 1398
	[SerializeField]
	private Transform end_back_2_transform;

	// Token: 0x04000577 RID: 1399
	[SerializeField]
	private AnimationCurve curve_ship_back_move;
}
