using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200007F RID: 127
public class Interactive_move_line : Interactive
{
	// Token: 0x06000352 RID: 850 RVA: 0x00010715 File Offset: 0x0000E915
	public override void Set(Stady_Find stady_value, int index_value, bool load_status_value, bool first_status_value = false)
	{
		base.Set(stady_value, index_value, load_status_value, first_status_value);
		this.start_set_objects();
		this.update_position_objects((float)(this.current_status ? 1 : 0));
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0001073B File Offset: 0x0000E93B
	public override void Click_Collider_object(GameObject go_value)
	{
		if (this.coroutine == null)
		{
			this.coroutine = base.StartCoroutine(this.IE_Move());
		}
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00010757 File Offset: 0x0000E957
	private IEnumerator IE_Move()
	{
		float start = (float)(this.current_status ? 1 : 0);
		float end = (float)(this.current_status ? 0 : 1);
		float value = 0f;
		while (value < 1f)
		{
			value += Time.deltaTime * this.multiply_speed;
			this.update_position_objects(Mathf.Lerp(start, end, value));
			yield return new WaitForSeconds(Time.deltaTime);
		}
		this.current_status = !this.current_status;
		base.Update_data();
		this.coroutine = null;
		yield break;
	}

	// Token: 0x06000355 RID: 853 RVA: 0x00010768 File Offset: 0x0000E968
	private void start_set_objects()
	{
		for (int i = 0; i < this.click_objects.Length; i++)
		{
			this.click_objects[i].start_set(this);
		}
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0001079A File Offset: 0x0000E99A
	public override bool Check_click()
	{
		return this.coroutine == null;
	}

	// Token: 0x06000357 RID: 855 RVA: 0x000107A8 File Offset: 0x0000E9A8
	private void update_position_objects(float value)
	{
		for (int i = 0; i < this.click_objects.Length; i++)
		{
			this.click_objects[i].update_position(value);
		}
	}

	// Token: 0x040003FF RID: 1023
	[Header("Интерактивные объекты:")]
	[Tooltip("Объекты которые будут перемещаться по прямой относительно состояния, последнии 3 параметра настраиваются автоматически")]
	[SerializeField]
	private Struct_Interactive.Move_line_object[] click_objects;

	// Token: 0x04000400 RID: 1024
	[SerializeField]
	private float multiply_speed = 1f;

	// Token: 0x04000401 RID: 1025
	private Coroutine coroutine;
}
