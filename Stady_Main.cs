using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200008E RID: 142
public class Stady_Main : MonoBehaviour
{
	// Token: 0x060003BF RID: 959 RVA: 0x00012D00 File Offset: 0x00010F00
	public virtual void Awake_set()
	{
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00012D02 File Offset: 0x00010F02
	public virtual void Set_play(int level_value, int stady_value, int count_max_value)
	{
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x00012D04 File Offset: 0x00010F04
	public virtual void Set_complite(int level_value, int stady_value)
	{
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00012D06 File Offset: 0x00010F06
	public void Set_Camera_position()
	{
		Debug.Log("!!!!!!!!!!!!!!!Set_Camera_position()!!!!!!!!!!!!!!");
		Zone_manager.st.Update_map_zone(this.zone_left_down.position, this.zone_right_up.position);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00012D32 File Offset: 0x00010F32
	public virtual void Help()
	{
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00012D34 File Offset: 0x00010F34
	public virtual void next_group_find(Enums_Localization.Items_E item_Name_v)
	{
		SL_Data.st.Save_Game();
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x00012D40 File Offset: 0x00010F40
	public virtual void TEST()
	{
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x00012D44 File Offset: 0x00010F44
	protected void Set_data(int level_value, int stady_value)
	{
		Debug.Log(string.Concat(new string[]
		{
			"protected void Set_data(int ",
			level_value.ToString(),
			", int ",
			stady_value.ToString(),
			")"
		}));
		this.current_level = level_value;
		this.current_stady = stady_value;
		this.Load_data();
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x00012DA1 File Offset: 0x00010FA1
	protected void Complite_stady()
	{
		base.StartCoroutine(this.IE_Stady_Complite());
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x00012DB0 File Offset: 0x00010FB0
	private IEnumerator IE_Stady_Complite()
	{
		yield return new WaitForSeconds(1f);
		Level_Data.st.Stady_Complite(this);
		yield break;
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00012DC0 File Offset: 0x00010FC0
	protected void Load_data()
	{
		this.load_data_object(ref this.data_main, ref SL_Data.d_Game.sl_add);
		this.load_data_object(ref this.data_details, ref SL_Data.d_Game.sl_details);
		this.load_data_object(ref this.data_interactive, ref SL_Data.d_Game.sl_interactive);
		this.load_data_object(ref this.data_interactive_use, ref SL_Data.d_Game.sl_interactive_use);
		this.load_data_object(ref this.data_active, ref SL_Data.d_Game.sl_active);
		this.load_data_object(ref this.data_complite, ref SL_Data.d_Game.sl_complite);
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00012E54 File Offset: 0x00011054
	protected void Save_data()
	{
		this.save_data_object(ref this.data_main, ref SL_Data.d_Game.sl_add);
		this.save_data_object(ref this.data_details, ref SL_Data.d_Game.sl_details);
		this.save_data_object(ref this.data_interactive, ref SL_Data.d_Game.sl_interactive);
		this.save_data_object(ref this.data_interactive_use, ref SL_Data.d_Game.sl_interactive_use);
		this.save_data_object(ref this.data_active, ref SL_Data.d_Game.sl_active);
		this.save_data_object(ref this.data_complite, ref SL_Data.d_Game.sl_complite);
		SL_Data.st.Save_Game();
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00012EF0 File Offset: 0x000110F0
	private void load_data_object(ref bool[,] data_value, ref bool[,,,] sl_value)
	{
		data_value = new bool[sl_value.GetLength(2), SL_Data.d_Game.sl_details.GetLength(3)];
		for (int i = 0; i < data_value.GetLength(0); i++)
		{
			for (int j = 0; j < data_value.GetLength(1); j++)
			{
				data_value[i, j] = sl_value[this.current_level, this.current_stady, i, j];
			}
		}
	}

	// Token: 0x060003CC RID: 972 RVA: 0x00012F60 File Offset: 0x00011160
	private void save_data_object(ref bool[,] data_value, ref bool[,,,] sl_value)
	{
		for (int i = 0; i < data_value.GetLength(0); i++)
		{
			for (int j = 0; j < data_value.GetLength(1); j++)
			{
				sl_value[this.current_level, this.current_stady, i, j] = data_value[i, j];
			}
		}
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00012FB4 File Offset: 0x000111B4
	private void load_data_object(ref bool[] data_value, ref bool[,,] sl_value)
	{
		data_value = new bool[sl_value.GetLength(2)];
		for (int i = 0; i < data_value.Length; i++)
		{
			data_value[i] = sl_value[this.current_level, this.current_stady, i];
		}
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00012FF8 File Offset: 0x000111F8
	private void save_data_object(ref bool[] data_value, ref bool[,,] sl_value)
	{
		for (int i = 0; i < data_value.Length; i++)
		{
			sl_value[this.current_level, this.current_stady, i] = data_value[i];
		}
	}

	// Token: 0x060003CF RID: 975 RVA: 0x0001302C File Offset: 0x0001122C
	private void load_data_object(ref int[] data_value, ref int[,,] sl_value)
	{
		data_value = new int[sl_value.GetLength(2)];
		for (int i = 0; i < data_value.Length; i++)
		{
			data_value[i] = sl_value[this.current_level, this.current_stady, i];
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x00013070 File Offset: 0x00011270
	private void save_data_object(ref int[] data_value, ref int[,,] sl_value)
	{
		for (int i = 0; i < data_value.Length; i++)
		{
			sl_value[this.current_level, this.current_stady, i] = data_value[i];
		}
	}

	// Token: 0x04000437 RID: 1079
	[SerializeField]
	public Transform camera_position;

	// Token: 0x04000438 RID: 1080
	[SerializeField]
	public Transform zone_left_down;

	// Token: 0x04000439 RID: 1081
	[SerializeField]
	public Transform zone_right_up;

	// Token: 0x0400043A RID: 1082
	[Header("Данные для просмотра (тест):")]
	[SerializeField]
	protected int current_level;

	// Token: 0x0400043B RID: 1083
	[SerializeField]
	protected int current_stady;

	// Token: 0x0400043C RID: 1084
	[SerializeField]
	protected int[] data_main;

	// Token: 0x0400043D RID: 1085
	[SerializeField]
	protected bool[] data_interactive;

	// Token: 0x0400043E RID: 1086
	[SerializeField]
	protected bool[] data_interactive_use;

	// Token: 0x0400043F RID: 1087
	[SerializeField]
	protected bool[] data_active;

	// Token: 0x04000440 RID: 1088
	[SerializeField]
	protected bool[] data_complite;

	// Token: 0x04000441 RID: 1089
	protected bool[,] data_details;
}
