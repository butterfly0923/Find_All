using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200005E RID: 94
public class Frame_Position : MonoBehaviour
{
	// Token: 0x0600025F RID: 607 RVA: 0x0000C916 File Offset: 0x0000AB16
	private void Awake()
	{
		Frame_Position.st = (Frame_Position)Set_Singleton.This<Frame_Position, Frame_Position>(this, Frame_Position.st);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x0000C930 File Offset: 0x0000AB30
	private void Start()
	{
		this.item_Data = Level_Data.st.Item_data;
		ValueTuple<Transform, SpriteRenderer, SpriteRenderer> valueTuple = Frame_Helper.st.RT_data();
		this.frame_position = valueTuple.Item1;
		this.Frame_Sprite_Renderer = valueTuple.Item2;
		this.Icon_Sprite_Renderer = valueTuple.Item3;
		this.Frame_Sprite_Renderer.color = new Color(1f, 1f, 1f, 0f);
		this.Icon_Sprite_Renderer.color = new Color(1f, 1f, 1f, 0f);
		this.Frame_Sprite_Renderer.enabled = false;
		this.Icon_Sprite_Renderer.enabled = false;
		ValueTuple<Vector2, Vector2> valueTuple2 = Zone_manager.st.Map_Zone();
		this.left_down_zone = valueTuple2.Item1;
		this.right_up_zone = valueTuple2.Item2;
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0000CA00 File Offset: 0x0000AC00
	private void OnEnable()
	{
		EA.Help_find_item = (Action<Vector3, Enums_Localization.Items_E>)Delegate.Combine(EA.Help_find_item, new Action<Vector3, Enums_Localization.Items_E>(this.Start_Help_Find));
		EA.Help_end_item_find_complite = (Action)Delegate.Combine(EA.Help_end_item_find_complite, new Action(this.Stop_Help));
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0000CA50 File Offset: 0x0000AC50
	private void OnDisable()
	{
		EA.Help_find_item = (Action<Vector3, Enums_Localization.Items_E>)Delegate.Remove(EA.Help_find_item, new Action<Vector3, Enums_Localization.Items_E>(this.Start_Help_Find));
		EA.Help_end_item_find_complite = (Action)Delegate.Remove(EA.Help_end_item_find_complite, new Action(this.Stop_Help));
	}

	// Token: 0x06000263 RID: 611 RVA: 0x0000CA9D File Offset: 0x0000AC9D
	private void Help_Item_Start(Transform target_v, Enums_Localization.Items_E group_name_v)
	{
		this.Icon_Sprite_Renderer.sprite = this.item_Data.Return_Icon_Sprite(group_name_v);
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0000CAB6 File Offset: 0x0000ACB6
	public SpriteRenderer RT_glare_camera()
	{
		return this.glare_camera;
	}

	// Token: 0x06000265 RID: 613 RVA: 0x0000CAC0 File Offset: 0x0000ACC0
	public void Random_position()
	{
		float num = Random.Range(this.frame_zone_left_down.x, this.frame_zone_right_up.x);
		float num2 = Random.Range(this.frame_zone_left_down.y, this.frame_zone_right_up.y);
		if (num2 < -3f && num < 4.5f && num > -3.5f)
		{
			num2 = -3f;
		}
		this.frame_position.position = new Vector3(this.target_position.x + num, this.target_position.y + num2, this.target_position.z);
		if (this.frame_position.position.x < this.left_down_zone.x + 13.5f)
		{
			this.frame_position.position = new Vector3(this.left_down_zone.x + 13.5f, this.frame_position.position.y, this.frame_position.position.z);
		}
		else if (this.frame_position.position.x > this.right_up_zone.x - 13.5f)
		{
			this.frame_position.position = new Vector3(this.right_up_zone.x - 13.5f, this.frame_position.position.y, this.frame_position.position.z);
		}
		if (this.frame_position.position.y > this.right_up_zone.y - 8f)
		{
			this.frame_position.position = new Vector3(this.frame_position.position.x, this.right_up_zone.y - 8f, this.frame_position.position.z);
			return;
		}
		if (this.frame_position.position.y < this.left_down_zone.y + 8f)
		{
			this.frame_position.position = new Vector3(this.frame_position.position.x, this.left_down_zone.y + 8f, this.frame_position.position.z);
		}
	}

	// Token: 0x06000266 RID: 614 RVA: 0x0000CCEC File Offset: 0x0000AEEC
	private void Start_Help_Find(Vector3 transform_target_v, Enums_Localization.Items_E group_name_v)
	{
		ValueTuple<Vector2, Vector2> valueTuple = Zone_manager.st.Map_Zone();
		this.left_down_zone = valueTuple.Item1;
		this.right_up_zone = valueTuple.Item2;
		this.target_position = transform_target_v;
		this.Random_position();
		this.Icon_Sprite_Renderer.sprite = this.item_Data.Return_Icon_Sprite(group_name_v);
		this.Frame_Sprite_Renderer.enabled = true;
		this.Icon_Sprite_Renderer.enabled = true;
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		base.StartCoroutine(this.Alpha_On());
	}

	// Token: 0x06000267 RID: 615 RVA: 0x0000CD79 File Offset: 0x0000AF79
	private IEnumerator Alpha_On()
	{
		float value_alpha = 0f;
		this.Frame_Sprite_Renderer.color = new Color(1f, 1f, 1f, value_alpha);
		this.Icon_Sprite_Renderer.color = new Color(1f, 1f, 1f, value_alpha);
		while (value_alpha < 1f)
		{
			value_alpha += Time.deltaTime * this.speed_alpha;
			this.Frame_Sprite_Renderer.color = new Color(1f, 1f, 1f, value_alpha);
			this.Icon_Sprite_Renderer.color = new Color(1f, 1f, 1f, value_alpha);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x0000CD88 File Offset: 0x0000AF88
	private void Stop_Help()
	{
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		base.StartCoroutine(this.Alpha_Off());
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0000CDAB File Offset: 0x0000AFAB
	private IEnumerator Alpha_Off()
	{
		float value_alpha = this.Frame_Sprite_Renderer.color.a;
		while (value_alpha > 0f)
		{
			value_alpha -= Time.deltaTime * this.speed_alpha;
			this.Frame_Sprite_Renderer.color = new Color(1f, 1f, 1f, value_alpha);
			this.Icon_Sprite_Renderer.color = new Color(1f, 1f, 1f, value_alpha);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.Frame_Sprite_Renderer.enabled = false;
		this.Icon_Sprite_Renderer.enabled = false;
		yield break;
	}

	// Token: 0x040002EB RID: 747
	[SerializeField]
	private Transform frame_position;

	// Token: 0x040002EC RID: 748
	private Vector3 target_position;

	// Token: 0x040002ED RID: 749
	[SerializeField]
	private SpriteRenderer Frame_Sprite_Renderer;

	// Token: 0x040002EE RID: 750
	[SerializeField]
	private SpriteRenderer Icon_Sprite_Renderer;

	// Token: 0x040002EF RID: 751
	[SerializeField]
	private Item_Data item_Data;

	// Token: 0x040002F0 RID: 752
	[SerializeField]
	private Vector2 frame_zone_left_down;

	// Token: 0x040002F1 RID: 753
	[SerializeField]
	private Vector2 frame_zone_right_up;

	// Token: 0x040002F2 RID: 754
	[SerializeField]
	private float speed_alpha;

	// Token: 0x040002F3 RID: 755
	[SerializeField]
	private Vector2 left_down_zone;

	// Token: 0x040002F4 RID: 756
	[SerializeField]
	private Vector2 right_up_zone;

	// Token: 0x040002F5 RID: 757
	[SerializeField]
	private SpriteRenderer glare_camera;

	// Token: 0x040002F6 RID: 758
	private Coroutine coroutine;

	// Token: 0x040002F7 RID: 759
	[SerializeField]
	private Transform transform_find_help;

	// Token: 0x040002F8 RID: 760
	public static Frame_Position st;
}
