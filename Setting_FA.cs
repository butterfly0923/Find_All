using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000035 RID: 53
public class Setting_FA : MonoBehaviour
{
	// Token: 0x0600017A RID: 378 RVA: 0x000091C4 File Offset: 0x000073C4
	private void OnEnable()
	{
		this.slider_value_max_FPS.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_max_FPS));
		this.slider_value_glare.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_glare));
		this.toggle_helper.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_helper));
		this.toggle_next_card.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_next_card));
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00009244 File Offset: 0x00007444
	private void OnDisable()
	{
		this.slider_value_max_FPS.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_max_FPS));
		this.slider_value_glare.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_glare));
		this.toggle_helper.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_helper));
		this.toggle_next_card.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_next_card));
	}

	// Token: 0x0600017C RID: 380 RVA: 0x000092C1 File Offset: 0x000074C1
	private void Start()
	{
		this.load_setting_value();
	}

	// Token: 0x0600017D RID: 381 RVA: 0x000092CC File Offset: 0x000074CC
	private void load_setting_value()
	{
		this.slider_value_max_FPS.value = (float)SL_Data.d_Setting.Max_FPS;
		this.slider_value_glare.value = SL_Data.d_Setting.Glare;
		this.toggle_helper.isOn = SL_Data.d_Setting.Helper;
		this.toggle_next_card.isOn = SL_Data.d_Setting.Next_Card;
	}

	// Token: 0x0600017E RID: 382 RVA: 0x0000932E File Offset: 0x0000752E
	public void update_slider_max_FPS(float value)
	{
		Setting_st_data.Update_TMP(value);
	}

	// Token: 0x0600017F RID: 383 RVA: 0x00009336 File Offset: 0x00007536
	public void update_slider_glare(float value)
	{
		Setting_st_data.Update_Glare_Value(value);
	}

	// Token: 0x06000180 RID: 384 RVA: 0x0000933E File Offset: 0x0000753E
	public void update_slider_camera_speed(float value)
	{
		SL_Data.d_Setting.Speed_Camera = value;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x0000934B File Offset: 0x0000754B
	public void update_toggle_helper(bool value)
	{
		this.toggle_helper.isOn = value;
		SL_Data.d_Setting.Helper = this.toggle_helper.isOn;
	}

	// Token: 0x06000182 RID: 386 RVA: 0x0000936E File Offset: 0x0000756E
	public void update_toggle_next_card(bool value)
	{
		this.toggle_next_card.isOn = value;
		SL_Data.d_Setting.Next_Card = this.toggle_next_card.isOn;
	}

	// Token: 0x0400018E RID: 398
	[SerializeField]
	private Slider slider_value_max_FPS;

	// Token: 0x0400018F RID: 399
	[SerializeField]
	private Slider slider_value_glare;

	// Token: 0x04000190 RID: 400
	[SerializeField]
	private Slider slider_value_camera_speed;

	// Token: 0x04000191 RID: 401
	[SerializeField]
	private TMP_Text text_FPS;

	// Token: 0x04000192 RID: 402
	[SerializeField]
	private Toggle toggle_helper;

	// Token: 0x04000193 RID: 403
	[SerializeField]
	private Toggle toggle_next_card;
}
