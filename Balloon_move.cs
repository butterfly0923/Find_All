using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000047 RID: 71
public class Balloon_move : MonoBehaviour
{
	// Token: 0x060001CA RID: 458 RVA: 0x00009DBC File Offset: 0x00007FBC
	private void Start()
	{
		this.main.position = new Vector3(this.curveX.Evaluate(this.value_move), this.curveY.Evaluate(this.value_move), this.curveZ.Evaluate(this.value_move));
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00009E0C File Offset: 0x0000800C
	[ContextMenu("Start_move")]
	public void Start_move()
	{
		base.StartCoroutine(this.IE_Multiply_start());
		base.StartCoroutine(this.IE_Start_move());
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00009E28 File Offset: 0x00008028
	public void Load_move()
	{
		this.multiply = 1f;
		this.value_move = Random.Range(0f, 1f);
		base.StartCoroutine(this.IE_Start_move());
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00009E57 File Offset: 0x00008057
	private IEnumerator IE_Start_move()
	{
		for (;;)
		{
			this.value_move += Time.deltaTime * this.speed * this.multiply;
			yield return new WaitForSeconds(Time.deltaTime);
			this.main.position = new Vector3(this.curveX.Evaluate(this.value_move), this.curveY.Evaluate(this.value_move), this.curveZ.Evaluate(this.value_move));
			this.main.localScale = new Vector3(this.scale.Evaluate(this.value_move), 1f, 1f);
		}
		yield break;
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00009E66 File Offset: 0x00008066
	private IEnumerator IE_Multiply_start()
	{
		while (this.multiply < 1f)
		{
			this.multiply += Time.deltaTime;
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.multiply = 1f;
		yield break;
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00009E78 File Offset: 0x00008078
	private Vector3 CalculateCatmullRomPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
	{
		float num = t * t;
		float d = num * t;
		return 0.5f * (2f * p1 + (-p0 + p2) * t + (2f * p0 - 5f * p1 + 4f * p2 - p3) * num + (-p0 + 3f * p1 - 3f * p2 + p3) * d);
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x00009F34 File Offset: 0x00008134
	private void OnDrawGizmos()
	{
		if (!this.drawGizmos || this.pathPoints.Count < 2)
		{
			return;
		}
		Vector3 from = this.pathPoints[0].position;
		for (float num = 0f; num < 1f; num += this.gizmoStep)
		{
			Vector3 splinePoint = this.GetSplinePoint(num);
			Gizmos.color = Color.green;
			Gizmos.DrawLine(from, splinePoint);
			from = splinePoint;
		}
		if (this.loop)
		{
			Gizmos.DrawLine(from, this.pathPoints[0].position);
		}
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00009FC0 File Offset: 0x000081C0
	[ContextMenu("Bake Path")]
	public void BakePath()
	{
		this.curveX = new AnimationCurve();
		this.curveY = new AnimationCurve();
		this.curveZ = new AnimationCurve();
		if (this.pathPoints.Count < 2)
		{
			return;
		}
		int num = this.loop ? (this.pathPoints.Count * this.samplesPerSegment) : ((this.pathPoints.Count - 1) * this.samplesPerSegment);
		float num2 = 1f / (float)num;
		for (int i = 0; i <= num; i++)
		{
			float num3 = (float)i * num2;
			Vector3 splinePoint = this.GetSplinePoint(num3);
			this.curveX.AddKey(num3, splinePoint.x);
			this.curveY.AddKey(num3, splinePoint.y);
			this.curveZ.AddKey(num3, splinePoint.z);
		}
		this.curveX = this.SimplifyCurve(this.curveX, 0.01f);
		this.curveY = this.SimplifyCurve(this.curveY, 0.01f);
		this.curveZ = this.SimplifyCurve(this.curveZ, 0.01f);
		Debug.Log("Путь записан в AnimationCurve!");
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0000A0DC File Offset: 0x000082DC
	private AnimationCurve SimplifyCurve(AnimationCurve curve, float tolerance)
	{
		if (curve.length <= 2)
		{
			return curve;
		}
		Keyframe[] keys = curve.keys;
		List<Keyframe> list = new List<Keyframe>();
		list.Add(keys[0]);
		for (int i = 1; i < keys.Length - 1; i++)
		{
			float num = Mathf.Lerp(keys[i - 1].value, keys[i + 1].value, (keys[i].time - keys[i - 1].time) / (keys[i + 1].time - keys[i - 1].time));
			if (Mathf.Abs(keys[i].value - num) > tolerance)
			{
				list.Add(keys[i]);
			}
		}
		list.Add(keys[keys.Length - 1]);
		return new AnimationCurve
		{
			keys = list.ToArray()
		};
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x0000A1C4 File Offset: 0x000083C4
	private Vector3 GetSplinePoint(float t)
	{
		int count = this.pathPoints.Count;
		float num = (float)(count - (this.loop ? 0 : 3));
		float num2 = t * num;
		int num3 = Mathf.FloorToInt(num2);
		float t2 = num2 - (float)num3;
		if (this.loop)
		{
			num3 %= count;
			int index = (num3 + 1) % count;
			int index2 = (num3 - 1 + count) % count;
			int index3 = (num3 + 2) % count;
			return this.CalculateCatmullRomPoint(this.pathPoints[index2].position, this.pathPoints[num3].position, this.pathPoints[index].position, this.pathPoints[index3].position, t2);
		}
		if (num3 >= count - 3)
		{
			num3 = count - 3;
			t2 = 1f;
		}
		return this.CalculateCatmullRomPoint(this.pathPoints[num3].position, this.pathPoints[num3 + 1].position, this.pathPoints[num3 + 2].position, this.pathPoints[num3 + 3].position, t2);
	}

	// Token: 0x040001EF RID: 495
	[SerializeField]
	private float value_move;

	// Token: 0x040001F0 RID: 496
	[SerializeField]
	private float multiply;

	// Token: 0x040001F1 RID: 497
	[SerializeField]
	private Transform main;

	// Token: 0x040001F2 RID: 498
	public List<Transform> pathPoints = new List<Transform>();

	// Token: 0x040001F3 RID: 499
	public float speed = 2f;

	// Token: 0x040001F4 RID: 500
	public bool loop = true;

	// Token: 0x040001F5 RID: 501
	public bool drawGizmos = true;

	// Token: 0x040001F6 RID: 502
	public float gizmoStep = 0.05f;

	// Token: 0x040001F7 RID: 503
	public int samplesPerSegment = 10;

	// Token: 0x040001F8 RID: 504
	public AnimationCurve scale;

	// Token: 0x040001F9 RID: 505
	public AnimationCurve curveX = new AnimationCurve();

	// Token: 0x040001FA RID: 506
	public AnimationCurve curveY = new AnimationCurve();

	// Token: 0x040001FB RID: 507
	public AnimationCurve curveZ = new AnimationCurve();

	// Token: 0x040001FC RID: 508
	private float totalDuration;
}
