using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000072 RID: 114
public class Find_event_main : MonoBehaviour
{
	// Token: 0x060002F6 RID: 758 RVA: 0x0000F1E0 File Offset: 0x0000D3E0
	public virtual void Set_Awake(Stady_Find stady_find_value)
	{
		this.stady_find = stady_find_value;
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			this.objects_Color_Time[i].Set_objects_group(this.all_delay_time, this.all_delay_time_setting);
		}
		if (this.Check_event_complite())
		{
			this.Load_White_Color();
		}
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x0000F234 File Offset: 0x0000D434
	[ContextMenu("Set_Color_object")]
	public virtual void Set_Color_object()
	{
		Debug.Log("Этот", this);
		this.objects_Color_Time = new Struct_Level.Objects_Color_Time[this.parent_objects_Color_Time.Length];
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			List<Transform> list = new List<Transform>(this.parent_objects_Color_Time[i].GetComponentsInChildren<Transform>());
			List<GameObject> list2 = new List<GameObject>();
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].GetComponent<Marker_spine_items>() == null)
				{
					list2.Add(list[j].gameObject);
				}
			}
			this.objects_Color_Time[i].Set_group(list2.ToArray());
		}
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x0000F2D9 File Offset: 0x0000D4D9
	public virtual void Creat_Color_Parent_1()
	{
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x0000F2DB File Offset: 0x0000D4DB
	protected virtual bool Check_event_complite()
	{
		return true;
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0000F2DE File Offset: 0x0000D4DE
	public virtual void Check_event_complite_play()
	{
	}

	// Token: 0x060002FB RID: 763 RVA: 0x0000F2E0 File Offset: 0x0000D4E0
	public void Load_White_Color()
	{
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			this.objects_Color_Time[i].Load_White_Color();
		}
		if (!this.load_start_individual)
		{
			UnityEvent unityEvent = this.start_event_complite;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}
		else
		{
			UnityEvent unityEvent2 = this.load_start_event_complite;
			if (unityEvent2 != null)
			{
				unityEvent2.Invoke();
			}
		}
		if (!this.load_end_individual)
		{
			UnityEvent unityEvent3 = this.end_event_complite;
			if (unityEvent3 == null)
			{
				return;
			}
			unityEvent3.Invoke();
			return;
		}
		else
		{
			UnityEvent unityEvent4 = this.load_end_event_complite;
			if (unityEvent4 == null)
			{
				return;
			}
			unityEvent4.Invoke();
			return;
		}
	}

	// Token: 0x060002FC RID: 764 RVA: 0x0000F366 File Offset: 0x0000D566
	public void Update_White_Color()
	{
		base.StartCoroutine(this.IE_White_Color());
	}

	// Token: 0x060002FD RID: 765 RVA: 0x0000F375 File Offset: 0x0000D575
	private IEnumerator IE_White_Color()
	{
		UnityEvent unityEvent = this.start_event_complite;
		if (unityEvent != null)
		{
			unityEvent.Invoke();
		}
		int num;
		for (int i = 0; i < this.objects_Color_Time.Length; i = num + 1)
		{
			this.objects_Color_Time[i].Update_White_Color(this.speed_color_update);
			yield return new WaitForSeconds(this.all_delay_time_setting ? this.all_delay_time : 0f);
			num = i;
		}
		UnityEvent unityEvent2 = this.end_event_complite;
		if (unityEvent2 != null)
		{
			unityEvent2.Invoke();
		}
		yield break;
	}

	// Token: 0x060002FE RID: 766 RVA: 0x0000F384 File Offset: 0x0000D584
	public virtual void Unity_Editor_Awake()
	{
		List<Transform> list = new List<Transform>();
		Vector3 vector = default(Vector3);
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			for (int j = 0; j < this.objects_Color_Time[i].go_color_sprite.Length; j++)
			{
				list.Add(this.objects_Color_Time[i].go_color_sprite[j].transform);
			}
		}
		foreach (Transform transform in list)
		{
			vector += transform.position;
		}
		vector /= (float)list.Count;
		Object.Instantiate<GameObject>(Level_Data.st.button_collider_find_stady, base.transform, false).transform.position = vector;
		List<GameObject> list2 = new List<GameObject>();
		for (int k = 0; k < this.objects_Color_Time.Length; k++)
		{
			for (int l = 0; l < this.objects_Color_Time[k].go_color_sprite.Length; l++)
			{
				list2.Add(this.objects_Color_Time[k].go_color_sprite[l]);
			}
		}
	}

	// Token: 0x060002FF RID: 767 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
	public void Re_test_color()
	{
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			this.objects_Color_Time[i].Test_color();
		}
		base.StartCoroutine(this.IE_test_Update_White_Color());
	}

	// Token: 0x06000300 RID: 768 RVA: 0x0000F506 File Offset: 0x0000D706
	private IEnumerator IE_test_Update_White_Color()
	{
		yield return new WaitForSeconds(0.1f);
		this.Update_White_Color();
		yield break;
	}

	// Token: 0x06000301 RID: 769 RVA: 0x0000F518 File Offset: 0x0000D718
	[ContextMenu("Clear_object_null")]
	public void Clear_object_null()
	{
		for (int i = 0; i < this.objects_Color_Time.Length; i++)
		{
			List<GameObject> list = new List<GameObject>();
			for (int j = 0; j < this.objects_Color_Time[i].go_color_sprite.Length; j++)
			{
				if (this.objects_Color_Time[i].go_color_sprite[j] != null)
				{
					list.Add(this.objects_Color_Time[i].go_color_sprite[j]);
				}
			}
			if (this.objects_Color_Time[i].go_color_sprite.Length != list.Count)
			{
				this.objects_Color_Time[i].go_color_sprite = list.ToArray();
			}
		}
	}

	// Token: 0x040003BA RID: 954
	[Header("Родительские объекты групп:")]
	[SerializeField]
	protected GameObject[] parent_objects_Color_Time;

	// Token: 0x040003BB RID: 955
	[Header("Группы объектов для закрашивания:")]
	[SerializeField]
	protected Struct_Level.Objects_Color_Time[] objects_Color_Time;

	// Token: 0x040003BC RID: 956
	[Header("Общая настройка времени закрашивания:")]
	[SerializeField]
	protected bool all_delay_time_setting;

	// Token: 0x040003BD RID: 957
	[SerializeField]
	protected float all_delay_time;

	// Token: 0x040003BE RID: 958
	[Header("Скорость закрашивания объектов (стандарт 30):")]
	[SerializeField]
	protected float speed_color_update = 30f;

	// Token: 0x040003BF RID: 959
	[Header("Событие при начале закрашивания:")]
	[SerializeField]
	protected UnityEvent start_event_complite;

	// Token: 0x040003C0 RID: 960
	[Header("Событие при окончании закрашивания:")]
	[SerializeField]
	protected UnityEvent end_event_complite;

	// Token: 0x040003C1 RID: 961
	[Header("Индивидуальное событие (начальное) при загрузке:")]
	[SerializeField]
	protected bool load_start_individual;

	// Token: 0x040003C2 RID: 962
	[SerializeField]
	protected UnityEvent load_start_event_complite;

	// Token: 0x040003C3 RID: 963
	[Header("Индивидуальное событие (конечное) при загрузке:")]
	[SerializeField]
	protected bool load_end_individual;

	// Token: 0x040003C4 RID: 964
	[SerializeField]
	protected UnityEvent load_end_event_complite;

	// Token: 0x040003C5 RID: 965
	protected Stady_Find stady_find;
}
