using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000061 RID: 97
public class Arrow_Rotate : MonoBehaviour
{
	// Token: 0x06000271 RID: 625 RVA: 0x0000CEB4 File Offset: 0x0000B0B4
	private void OnEnable()
	{
		EA.Help_find_item = (Action<Vector3, Enums_Localization.Items_E>)Delegate.Combine(EA.Help_find_item, new Action<Vector3, Enums_Localization.Items_E>(this.Start_Help_Find));
		EA.Help_end_item_find_complite = (Action)Delegate.Combine(EA.Help_end_item_find_complite, new Action(this.Stop_Help));
		EA.Escape_level = (Action)Delegate.Combine(EA.Escape_level, new Action(this.Stop_Help));
		EA.Puzzle_arrow = (Action<Vector3, Enum_Data.Puzzle_Name>)Delegate.Combine(EA.Puzzle_arrow, new Action<Vector3, Enum_Data.Puzzle_Name>(this.Start_Puzzle_arrow));
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0000CF44 File Offset: 0x0000B144
	private void OnDisable()
	{
		EA.Help_find_item = (Action<Vector3, Enums_Localization.Items_E>)Delegate.Remove(EA.Help_find_item, new Action<Vector3, Enums_Localization.Items_E>(this.Start_Help_Find));
		EA.Help_end_item_find_complite = (Action)Delegate.Remove(EA.Help_end_item_find_complite, new Action(this.Stop_Help));
		EA.Escape_level = (Action)Delegate.Remove(EA.Escape_level, new Action(this.Stop_Help));
		EA.Puzzle_arrow = (Action<Vector3, Enum_Data.Puzzle_Name>)Delegate.Remove(EA.Puzzle_arrow, new Action<Vector3, Enum_Data.Puzzle_Name>(this.Start_Puzzle_arrow));
	}

	// Token: 0x06000273 RID: 627 RVA: 0x0000CFD4 File Offset: 0x0000B1D4
	private void Start()
	{
		this.item_Data = Level_Data.st.Item_data;
		if (Camera.main != null)
		{
			this.camera_main = Camera.main.transform;
		}
		this.arrow.color = new Color(1f, 1f, 1f, 0f);
		this.icon.color = new Color(1f, 1f, 1f, 0f);
		this.frame.color = new Color(1f, 1f, 1f, 0f);
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0000D07C File Offset: 0x0000B27C
	public void Start_Arrow_Help()
	{
		this.Distace_min = false;
		if (this.coroutine_rotate != null)
		{
			base.StopCoroutine(this.coroutine_rotate);
		}
		this.coroutine_rotate = base.StartCoroutine(this.Rotate_Arrow());
		if (this.coroutine_alpha != null)
		{
			base.StopCoroutine(this.coroutine_alpha);
		}
		this.coroutine_alpha = base.StartCoroutine(this.Alpha_Arrow());
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0000D0DC File Offset: 0x0000B2DC
	private void Stop_Help()
	{
		if (!this.Distace_min)
		{
			if (this.coroutine_alpha != null)
			{
				base.StopCoroutine(this.coroutine_alpha);
			}
			this.coroutine_alpha = base.StartCoroutine(this.Alpha_Arrow_False());
		}
	}

	// Token: 0x06000276 RID: 630 RVA: 0x0000D10C File Offset: 0x0000B30C
	private void Start_Puzzle_arrow(Vector3 transform_target_v, Enum_Data.Puzzle_Name puzzle_name_v)
	{
		this.icon.sprite = this.puzzle_Data.Return_Icon_Sprite(puzzle_name_v);
		this.distance_void = this.distance_button;
		this.help_puzzle_flag = false;
		this.target_vector3 = transform_target_v;
		this.Start_Arrow_Help();
	}

	// Token: 0x06000277 RID: 631 RVA: 0x0000D148 File Offset: 0x0000B348
	private void Start_Help_Find(Vector3 transform_target_v, Enums_Localization.Items_E group_name_v)
	{
		Debug.Log(string.Format("{0}", transform_target_v));
		this.icon.sprite = this.item_Data.Return_Icon_Sprite(group_name_v);
		this.distance_void = this.distance_find;
		this.help_puzzle_flag = true;
		this.target_vector3 = transform_target_v;
		this.Start_Arrow_Help();
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0000D1A1 File Offset: 0x0000B3A1
	private IEnumerator Rotate_Arrow()
	{
		for (;;)
		{
			Vector3 vector = this.target_vector3;
			Vector2 vector2 = this.target_vector3 - this.camera_main.position;
			float z = Mathf.Atan2(vector2.y, vector2.x) * 57.29578f;
			this.Arrow_UI.eulerAngles = new Vector3(0f, 0f, z);
			if (this.Arrow_UI.localEulerAngles.z < 100f)
			{
				this.Arrow_UI.localScale = new Vector3(1f, 1f, 1f);
			}
			else
			{
				this.Arrow_UI.localScale = new Vector3(1f, -1f, 1f);
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0000D1B0 File Offset: 0x0000B3B0
	private IEnumerator Alpha_Arrow()
	{
		bool alpha_value = false;
		float alpha_end = 0f;
		float alpha_start = 0f;
		while (!this.Distace_min)
		{
			float num;
			if (this.help_puzzle_flag)
			{
				num = this.Alpha_distance.Evaluate(Vector2.Distance(this.target_vector3, this.camera_main.position) - this.distance_void);
			}
			else
			{
				num = this.Alpha_puzzle.Evaluate(Vector2.Distance(this.target_vector3, this.camera_main.position) - this.distance_void);
			}
			if (this.Alpha_update)
			{
				if (alpha_value)
				{
					alpha_end = num;
				}
				else
				{
					alpha_start += Time.deltaTime * this.speed_alpha_start;
					alpha_end = Mathf.Lerp(0f, num, alpha_start);
					if (alpha_start >= 1f)
					{
						alpha_value = true;
					}
				}
				this.arrow.color = new Color(1f, 1f, 1f, alpha_end);
				this.icon.color = new Color(1f, 1f, 1f, alpha_end);
				this.frame.color = new Color(1f, 1f, 1f, alpha_end);
			}
			if (alpha_end <= 0f && alpha_value)
			{
				this.arrow.color = new Color(1f, 1f, 1f, 0f);
				this.icon.color = new Color(1f, 1f, 1f, 0f);
				this.frame.color = new Color(1f, 1f, 1f, 0f);
				this.Distace_min = true;
			}
			yield return new WaitForSeconds(Time.deltaTime);
		}
		if (this.coroutine_alpha != null)
		{
			base.StopCoroutine(this.coroutine_alpha);
		}
		yield break;
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0000D1BF File Offset: 0x0000B3BF
	private IEnumerator Alpha_Arrow_False()
	{
		float alpha_start = this.arrow.color.a;
		float alpha = this.arrow.color.a;
		float alpha_end = Mathf.Lerp(0f, alpha, alpha_start);
		while (alpha_end > 0f)
		{
			alpha_end = Mathf.Lerp(0f, alpha, alpha_start);
			alpha_start -= Time.deltaTime * this.speed_alpha_start;
			this.arrow.color = new Color(1f, 1f, 1f, alpha_end);
			this.icon.color = new Color(1f, 1f, 1f, alpha_end);
			this.frame.color = new Color(1f, 1f, 1f, alpha_end);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		Debug.Log("Конец помощи альфа");
		if (this.coroutine_rotate != null)
		{
			base.StopCoroutine(this.coroutine_rotate);
		}
		yield break;
	}

	// Token: 0x040002FA RID: 762
	[SerializeField]
	private Item_Data item_Data;

	// Token: 0x040002FB RID: 763
	[SerializeField]
	private Puzzle_Data puzzle_Data;

	// Token: 0x040002FC RID: 764
	[SerializeField]
	private Transform camera_main;

	// Token: 0x040002FD RID: 765
	[SerializeField]
	private Vector3 target_vector3;

	// Token: 0x040002FE RID: 766
	[SerializeField]
	private RectTransform Arrow_UI;

	// Token: 0x040002FF RID: 767
	[SerializeField]
	private Image arrow;

	// Token: 0x04000300 RID: 768
	[SerializeField]
	private Image frame;

	// Token: 0x04000301 RID: 769
	[SerializeField]
	private Image icon;

	// Token: 0x04000302 RID: 770
	[SerializeField]
	private float distance_find;

	// Token: 0x04000303 RID: 771
	[SerializeField]
	private float distance_button;

	// Token: 0x04000304 RID: 772
	[SerializeField]
	private AnimationCurve Alpha_distance;

	// Token: 0x04000305 RID: 773
	[SerializeField]
	private AnimationCurve Alpha_puzzle;

	// Token: 0x04000306 RID: 774
	[SerializeField]
	private float speed_alpha_start;

	// Token: 0x04000307 RID: 775
	private bool help_puzzle_flag;

	// Token: 0x04000308 RID: 776
	private float distance_void;

	// Token: 0x04000309 RID: 777
	private Coroutine coroutine_rotate;

	// Token: 0x0400030A RID: 778
	private Coroutine coroutine_alpha;

	// Token: 0x0400030B RID: 779
	private bool Distace_min;

	// Token: 0x0400030C RID: 780
	private bool Alpha_update = true;
}
