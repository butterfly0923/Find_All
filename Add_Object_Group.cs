using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000018 RID: 24
public class Add_Object_Group : MonoBehaviour
{
	// Token: 0x0600006C RID: 108 RVA: 0x00003518 File Offset: 0x00001718
	public void Set_Awake()
	{
		this.Item_need_material = new Item_Find_Material[this.Item_need_find.Length];
		for (int i = 0; i < this.Item_need_find.Length; i++)
		{
			this.Item_need_material[i] = this.Item_need_find[i].GetComponent<Item_Find_Material>();
		}
		for (int j = 0; j < this.objects_Color_Time.Length; j++)
		{
			if (this.all_delay_time_setting)
			{
				this.objects_Color_Time[j].delay_time_next = this.all_delay_time;
			}
			this.objects_Color_Time[j].objects_Color_Material = new Object_Color_Material[this.objects_Color_Time[j].go_color_sprite.Length];
			for (int k = 0; k < this.objects_Color_Time[j].objects_Color_Material.Length; k++)
			{
				this.objects_Color_Time[j].objects_Color_Material[k] = this.objects_Color_Time[j].go_color_sprite[k].AddComponent<Object_Color_Material>();
				this.objects_Color_Time[j].objects_Color_Material[k].Add_Component_Setup();
			}
		}
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00003624 File Offset: 0x00001824
	public bool test_all_item_find()
	{
		bool result = true;
		for (int i = 0; i < this.Item_need_material.Length; i++)
		{
			if (!this.Item_need_material[i].Return_Find_Complite())
			{
				result = false;
				break;
			}
		}
		return result;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x0000365C File Offset: 0x0000185C
	public void Start_White_Color()
	{
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			for (int j = 0; j < this.objects_Color_Time[i].objects_Color_Material.Length; j++)
			{
				this.objects_Color_Time[i].objects_Color_Material[j].Load_White_Color();
			}
		}
		if (!this.load_individual)
		{
			UnityEvent unityEvent = this.end_event_complite;
			if (unityEvent == null)
			{
				return;
			}
			unityEvent.Invoke();
			return;
		}
		else
		{
			UnityEvent unityEvent2 = this.load_event_complite;
			if (unityEvent2 == null)
			{
				return;
			}
			unityEvent2.Invoke();
			return;
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x000036DB File Offset: 0x000018DB
	public void Update_White_Color(bool delay_time_v = true)
	{
		base.StartCoroutine(this.IE_Update_White_Color(delay_time_v));
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000036EB File Offset: 0x000018EB
	private IEnumerator IE_Update_White_Color(bool delay_time_v)
	{
		int num;
		for (int i = 0; i < this.objects_Color_Time.Length; i = num + 1)
		{
			for (int j = 0; j < this.objects_Color_Time[i].objects_Color_Material.Length; j++)
			{
				this.objects_Color_Time[i].objects_Color_Material[j].Update_White_Color(this.color_update);
			}
			yield return new WaitForSeconds(delay_time_v ? this.objects_Color_Time[i].delay_time_next : 0f);
			num = i;
		}
		UnityEvent unityEvent = this.end_event_complite;
		if (unityEvent != null)
		{
			unityEvent.Invoke();
		}
		yield break;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00003704 File Offset: 0x00001904
	public void Unity_Editor_Awake(GameObject gameObject_v)
	{
		Transform[] componentsInChildren = base.GetComponentsInChildren<Transform>();
		Vector3 vector = default(Vector3);
		Transform[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i++)
		{
			Vector3 position = array[i].position;
			vector.x += position.x;
			vector.y += position.y;
			vector.z += position.z;
		}
		vector /= (float)componentsInChildren.Length;
		Object.Instantiate<GameObject>(gameObject_v, base.transform, false).transform.position = vector;
		List<GameObject> list = new List<GameObject>();
		for (int j = 0; j < this.objects_Color_Time.Length; j++)
		{
			for (int k = 0; k < this.objects_Color_Time[j].go_color_sprite.Length; k++)
			{
				list.Add(this.objects_Color_Time[j].go_color_sprite[k]);
			}
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x000037F4 File Offset: 0x000019F4
	public void Re_test_color()
	{
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			for (int j = 0; j < this.objects_Color_Time[i].objects_Color_Material.Length; j++)
			{
				this.objects_Color_Time[i].objects_Color_Material[j].Re_test_color();
			}
		}
		base.StartCoroutine(this.IE_test_Update_White_Color());
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00003857 File Offset: 0x00001A57
	private IEnumerator IE_test_Update_White_Color()
	{
		yield return new WaitForSeconds(1f);
		this.Update_White_Color(true);
		yield break;
	}

	// Token: 0x0400007F RID: 127
	[SerializeField]
	private GameObject[] Item_need_find;

	// Token: 0x04000080 RID: 128
	[SerializeField]
	private Item_Find_Material[] Item_need_material;

	// Token: 0x04000081 RID: 129
	[SerializeField]
	private bool all_delay_time_setting;

	// Token: 0x04000082 RID: 130
	[SerializeField]
	private float all_delay_time;

	// Token: 0x04000083 RID: 131
	[Header("Скорость закрашивания объектов:")]
	[SerializeField]
	private float color_update = 30f;

	// Token: 0x04000084 RID: 132
	[SerializeField]
	private UnityEvent end_event_complite;

	// Token: 0x04000085 RID: 133
	[SerializeField]
	private bool load_individual;

	// Token: 0x04000086 RID: 134
	[SerializeField]
	private UnityEvent load_event_complite;

	// Token: 0x04000087 RID: 135
	[SerializeField]
	private Add_Object_Group.Objects_Color_Time[] objects_Color_Time;

	// Token: 0x020000F4 RID: 244
	[Serializable]
	private struct Objects_Color_Time
	{
		// Token: 0x040006A4 RID: 1700
		public GameObject[] go_color_sprite;

		// Token: 0x040006A5 RID: 1701
		public float delay_time_next;

		// Token: 0x040006A6 RID: 1702
		public Object_Color_Material[] objects_Color_Material;
	}
}
