using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x0200006E RID: 110
public class Help_find_item_manager : MonoBehaviour
{
	// Token: 0x060002D9 RID: 729 RVA: 0x0000E450 File Offset: 0x0000C650
	private void Start()
	{
		this.button_help.interactable = false;
		base.StartCoroutine(this.update_time_help_level());
		this.Enabled_helper();
	}

	// Token: 0x060002DA RID: 730 RVA: 0x0000E474 File Offset: 0x0000C674
	private void OnEnable()
	{
		EA.Help_end_item_find_complite = (Action)Delegate.Combine(EA.Help_end_item_find_complite, new Action(this.Help_Item_Find_Complite));
		this.button_help.onClick.AddListener(new UnityAction(this.Help_button_down));
		Setting_st_data.helper_update = (Action)Delegate.Combine(Setting_st_data.helper_update, new Action(this.Enabled_helper));
	}

	// Token: 0x060002DB RID: 731 RVA: 0x0000E4E0 File Offset: 0x0000C6E0
	private void OnDisable()
	{
		EA.Help_end_item_find_complite = (Action)Delegate.Remove(EA.Help_end_item_find_complite, new Action(this.Help_Item_Find_Complite));
		this.button_help.onClick.RemoveListener(new UnityAction(this.Help_button_down));
		Setting_st_data.helper_update = (Action)Delegate.Remove(Setting_st_data.helper_update, new Action(this.Enabled_helper));
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0000E54C File Offset: 0x0000C74C
	private void Enabled_helper()
	{
		bool helper = SL_Data.d_Setting.Helper;
		this.frame.enabled = helper;
		for (int i = 0; i < this.all_go.Length; i++)
		{
			this.all_go[i].SetActive(helper);
		}
	}

	// Token: 0x060002DD RID: 733 RVA: 0x0000E594 File Offset: 0x0000C794
	private void Reset_level_and_help(int I)
	{
		SL_Data.d_Game.Time_Help_level = 0f;
		this.Update_timer_text();
		this.button_help.interactable = false;
		this.Help_complite = false;
		this.text_time_minuts.enabled = true;
		this.text_time_middle.enabled = true;
		this.text_time_second.enabled = true;
	}

	// Token: 0x060002DE RID: 734 RVA: 0x0000E5ED File Offset: 0x0000C7ED
	private IEnumerator update_time_help_level()
	{
		for (;;)
		{
			if (!this.Help_complite && (Sa_IS.input_Main.am_play.enabled || Sa_IS.input_Main.Card_variant.enabled))
			{
				SL_Data.d_Game.Time_Help_level += 1f;
				if (SL_Data.d_Game.Time_Help_level >= this.Time_help_ON)
				{
					this.Help_enabled(true);
				}
				else
				{
					this.Update_timer_text();
				}
			}
			yield return new WaitForSeconds(1f);
		}
		yield break;
	}

	// Token: 0x060002DF RID: 735 RVA: 0x0000E5FC File Offset: 0x0000C7FC
	private void Help_Item_Find_Complite()
	{
		this.Help_enabled(false);
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x0000E608 File Offset: 0x0000C808
	private void Help_enabled(bool flag)
	{
		this.Update_timer_text();
		if (flag)
		{
			this.button_help.interactable = true;
			this.Help_complite = true;
			this.text_time_minuts.enabled = false;
			this.text_time_middle.enabled = false;
			this.text_time_second.enabled = false;
			return;
		}
		this.button_help.interactable = false;
		this.Help_complite = false;
		this.text_time_minuts.enabled = true;
		this.text_time_middle.enabled = true;
		this.text_time_second.enabled = true;
		SL_Data.d_Game.Time_Help_level = 0f;
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x0000E69C File Offset: 0x0000C89C
	public void Help_button_up_down(bool value_v)
	{
		if (!value_v)
		{
			this.button_help.interactable = false;
			return;
		}
		if (SL_Data.d_Game.Time_Help_level >= this.Time_help_ON)
		{
			this.Help_enabled(true);
			return;
		}
		this.button_help.interactable = false;
		this.Help_complite = false;
		this.text_time_minuts.enabled = true;
		this.text_time_middle.enabled = true;
		this.text_time_second.enabled = true;
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x0000E70C File Offset: 0x0000C90C
	private void Update_timer_text()
	{
		float num = this.Time_help_ON - SL_Data.d_Game.Time_Help_level;
		num = ((num <= 0f) ? 0f : num);
		this.Timer_text_minuts = Time_converter.FormatMinuts_do_10(num);
		this.Timer_text_middle = ":";
		this.Timer_text_seconds = Time_converter.FormatSeconds(num);
		this.text_time_minuts.text = this.Timer_text_minuts;
		this.text_time_middle.text = this.Timer_text_middle;
		this.text_time_second.text = this.Timer_text_seconds;
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x0000E794 File Offset: 0x0000C994
	public void Help_button_down()
	{
		Achievement_manager.st.Achievement_Help();
		Action help_button_down = EA.Help_button_down;
		if (help_button_down != null)
		{
			help_button_down();
		}
		this.button_help.interactable = false;
		this.text_time_minuts.enabled = false;
		this.text_time_middle.enabled = false;
		this.text_time_second.enabled = false;
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x0000E7EC File Offset: 0x0000C9EC
	private void Help_window_destroy()
	{
		this.Help_complite = false;
		this.text_time_minuts.enabled = true;
		this.text_time_middle.enabled = true;
		this.text_time_second.enabled = true;
		SL_Data.d_Game.Time_Help_level = 0f;
		this.Update_timer_text();
	}

	// Token: 0x040003A5 RID: 933
	[SerializeField]
	private bool Help_complite;

	// Token: 0x040003A6 RID: 934
	[SerializeField]
	private int Actual_level;

	// Token: 0x040003A7 RID: 935
	[SerializeField]
	private TMP_Text text_time_minuts;

	// Token: 0x040003A8 RID: 936
	[SerializeField]
	private TMP_Text text_time_middle;

	// Token: 0x040003A9 RID: 937
	[SerializeField]
	private TMP_Text text_time_second;

	// Token: 0x040003AA RID: 938
	[SerializeField]
	private float Time_help_ON;

	// Token: 0x040003AB RID: 939
	[SerializeField]
	private Button button_help;

	// Token: 0x040003AC RID: 940
	[SerializeField]
	private string Timer_text_minuts;

	// Token: 0x040003AD RID: 941
	[SerializeField]
	private string Timer_text_middle;

	// Token: 0x040003AE RID: 942
	[SerializeField]
	private string Timer_text_seconds;

	// Token: 0x040003AF RID: 943
	[SerializeField]
	private Image frame;

	// Token: 0x040003B0 RID: 944
	[SerializeField]
	private GameObject[] all_go;
}
