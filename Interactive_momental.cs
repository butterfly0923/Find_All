using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x0200007E RID: 126
public class Interactive_momental : Interactive
{
	// Token: 0x0600034A RID: 842 RVA: 0x0001045E File Offset: 0x0000E65E
	public override void Set(Stady_Find stady_value, int index_value, bool load_status_value, bool first_status_value = false)
	{
		base.Set(stady_value, index_value, load_status_value, first_status_value);
		this.open_stady_1.start_set(this);
		this.closed_stady_2.start_set(this);
		this.set_materials();
		this.update_stady();
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0001048F File Offset: 0x0000E68F
	private void Start()
	{
		this.curve_alpha = Level_Data.st.alpha_curve_interactive_momental;
		Debug.Log(string.Format("Start - {0} - {1}", base.gameObject.name, this.current_status));
	}

	// Token: 0x0600034C RID: 844 RVA: 0x000104C8 File Offset: 0x0000E6C8
	private void set_materials()
	{
		this.open_stady_materials = new List<Material>();
		this.closed_stady_materials = new List<Material>();
		List<SpriteRenderer> list = this.open_stady_1.RT_sprite();
		List<SpriteRenderer> list2 = this.closed_stady_2.RT_sprite();
		for (int i = 0; i < list.Count; i++)
		{
			this.open_stady_materials.Add(list[i].material);
		}
		for (int j = 0; j < list2.Count; j++)
		{
			this.closed_stady_materials.Add(list2[j].material);
		}
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00010554 File Offset: 0x0000E754
	public override void Click_Collider_object(GameObject go_value)
	{
		this.used = true;
		if (this.helper_open != null)
		{
			this.helper_open.GetComponent<Open_door_point>().off_all_sprite();
		}
		if (this.open_stady_1.Click_object.Any((GameObject t) => t == go_value))
		{
			this.current_status = false;
		}
		if (this.closed_stady_2.Click_object.Any((GameObject t) => t == go_value))
		{
			this.current_status = true;
		}
		base.StartCoroutine(this.IE_update_interactive());
	}

	// Token: 0x0600034E RID: 846 RVA: 0x000105EC File Offset: 0x0000E7EC
	private void update_stady()
	{
		this.open_stady_1.on_off(this.current_status);
		this.closed_stady_2.on_off(!this.current_status);
		this.set_materials();
		for (int i = 0; i < this.open_stady_materials.Count; i++)
		{
			this.open_stady_materials[i].SetFloat("_Alpha", (float)(this.current_status ? 1 : 0));
		}
		for (int j = 0; j < this.closed_stady_materials.Count; j++)
		{
			this.closed_stady_materials[j].SetFloat("_Alpha", (float)(this.current_status ? 0 : 1));
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00010696 File Offset: 0x0000E896
	private IEnumerator IE_update_interactive()
	{
		this.open_stady_1.on_off_start();
		this.closed_stady_2.on_off_start();
		if (this.current_status)
		{
			float value_lerp = 0f;
			while (value_lerp < 1f)
			{
				value_lerp += Time.deltaTime * this.speed_alpha;
				for (int i = 0; i < this.open_stady_materials.Count; i++)
				{
					this.open_stady_materials[i].SetFloat("_Alpha", this.curve_alpha.Evaluate(Mathf.Lerp(0f, 1f, value_lerp)));
				}
				for (int j = 0; j < this.closed_stady_materials.Count; j++)
				{
					this.closed_stady_materials[j].SetFloat("_Alpha", this.curve_alpha.Evaluate(Mathf.Lerp(1f, 0f, value_lerp)));
				}
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
		else
		{
			float value_lerp = 1f;
			while (value_lerp > 0f)
			{
				value_lerp -= Time.deltaTime * this.speed_alpha;
				for (int k = 0; k < this.open_stady_materials.Count; k++)
				{
					this.open_stady_materials[k].SetFloat("_Alpha", this.curve_alpha.Evaluate(Mathf.Lerp(0f, 1f, value_lerp)));
				}
				for (int l = 0; l < this.closed_stady_materials.Count; l++)
				{
					this.closed_stady_materials[l].SetFloat("_Alpha", this.curve_alpha.Evaluate(Mathf.Lerp(1f, 0f, value_lerp)));
				}
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
		this.open_stady_1.on_off_end(this.current_status);
		this.closed_stady_2.on_off_end(!this.current_status);
		base.Update_data();
		yield break;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x000106A8 File Offset: 0x0000E8A8
	public ValueTuple<List<Transform>, List<Item_Main>> RT_data_interactive_momental()
	{
		List<Transform> list = new List<Transform>();
		List<Item_Main> item = this.open_stady_1.RT_item_find();
		List<Interactive_object> list2 = this.closed_stady_2.RT_interactive_objects();
		for (int i = 0; i < list2.Count; i++)
		{
			list.Add(list2[i].gameObject.transform);
		}
		return new ValueTuple<List<Transform>, List<Item_Main>>(list, item);
	}

	// Token: 0x040003F8 RID: 1016
	[SerializeField]
	private Struct_Interactive.Momental_objects open_stady_1;

	// Token: 0x040003F9 RID: 1017
	[SerializeField]
	private Struct_Interactive.Momental_objects closed_stady_2;

	// Token: 0x040003FA RID: 1018
	private float speed_alpha = 8f;

	// Token: 0x040003FB RID: 1019
	private AnimationCurve curve_alpha;

	// Token: 0x040003FC RID: 1020
	[SerializeField]
	private List<Material> open_stady_materials;

	// Token: 0x040003FD RID: 1021
	[SerializeField]
	private List<Material> closed_stady_materials;

	// Token: 0x040003FE RID: 1022
	public GameObject helper_open;
}
