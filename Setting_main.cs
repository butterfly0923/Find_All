using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x020000AF RID: 175
public class Setting_main : MonoBehaviour
{
	// Token: 0x060004ED RID: 1261 RVA: 0x00017FBC File Offset: 0x000161BC
	private void OnEnable()
	{
		this.slider_FPS.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_FPS));
		this.slider_glare.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_glare));
		this.slider_camera_speed.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_camera_speed));
		this.slider_music.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_value_music));
		this.slider_sound.onValueChanged.AddListener(new UnityAction<float>(this.update_slider_value_sound));
		this.toggle_helper.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_helper));
		this.toggle_next_card.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_next_card));
		this.toggle_timer.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_timer));
		this.toggle_audio_item_find.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_audio_item_find));
		this.toggle_audio_group_find.onValueChanged.AddListener(new UnityAction<bool>(this.update_toggle_audio_group_find));
		this.button_exit_setting.onClick.AddListener(new UnityAction(this.update_exit_setting));
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x00018100 File Offset: 0x00016300
	private void OnDisable()
	{
		this.slider_FPS.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_FPS));
		this.slider_glare.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_glare));
		this.slider_camera_speed.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_camera_speed));
		this.slider_music.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_value_music));
		this.slider_sound.onValueChanged.RemoveListener(new UnityAction<float>(this.update_slider_value_sound));
		this.toggle_helper.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_helper));
		this.toggle_next_card.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_next_card));
		this.toggle_timer.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_timer));
		this.toggle_audio_item_find.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_audio_item_find));
		this.toggle_audio_group_find.onValueChanged.RemoveListener(new UnityAction<bool>(this.update_toggle_audio_group_find));
		this.button_exit_setting.onClick.RemoveListener(new UnityAction(this.update_exit_setting));
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x00018241 File Offset: 0x00016441
	private void Start()
	{
		this.load_setting_value();
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x0001824C File Offset: 0x0001644C
	private void load_setting_value()
	{
		this.slider_FPS.value = (float)SL_Data.d_Setting.Max_FPS;
		this.slider_glare.value = SL_Data.d_Setting.Glare;
		this.slider_camera_speed.value = SL_Data.d_Setting.Speed_Camera;
		this.slider_music.value = SL_Data.d_Setting.Music_Mixer;
		this.slider_sound.value = SL_Data.d_Setting.Sound_Mixer;
		this.toggle_helper.isOn = SL_Data.d_Setting.Helper;
		this.toggle_next_card.isOn = SL_Data.d_Setting.Next_Card;
		this.toggle_timer.isOn = SL_Data.d_Setting.Timer_On;
		this.toggle_audio_item_find.isOn = SL_Data.d_Setting.Sound_Item_Find;
		this.toggle_audio_group_find.isOn = SL_Data.d_Setting.Sound_Group_Find;
		this.update_slider_FPS((float)SL_Data.d_Setting.Max_FPS);
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x0001833D File Offset: 0x0001653D
	private void update_slider_FPS(float value)
	{
		Setting_st_data.Update_TMP(value);
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x00018345 File Offset: 0x00016545
	private void update_slider_glare(float value)
	{
		Setting_st_data.Update_Glare_Value(value);
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x0001834D File Offset: 0x0001654D
	private void update_slider_camera_speed(float value)
	{
		SL_Data.d_Setting.Speed_Camera = value;
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x0001835A File Offset: 0x0001655A
	private void update_slider_value_music(float value)
	{
		Setting_st_data.Update_Volume_Music(value);
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x00018362 File Offset: 0x00016562
	private void update_slider_value_sound(float value)
	{
		Setting_st_data.Update_Volume_Sound(value);
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x0001836A File Offset: 0x0001656A
	private void update_toggle_helper(bool value)
	{
		Setting_st_data.Update_Helper_Status(value);
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00018372 File Offset: 0x00016572
	private void update_toggle_next_card(bool value)
	{
		Setting_st_data.Update_Select_Hext_Card_Status(value);
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x0001837A File Offset: 0x0001657A
	private void update_toggle_timer(bool value)
	{
		Setting_st_data.Update_Select_Timer_Status(value);
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x00018382 File Offset: 0x00016582
	private void update_toggle_audio_item_find(bool value)
	{
		Setting_st_data.Update_Audio_Item_Find(value);
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x0001838A File Offset: 0x0001658A
	private void update_toggle_audio_group_find(bool value)
	{
		Setting_st_data.Update_Audio_Group_Find(value);
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00018392 File Offset: 0x00016592
	private void update_exit_setting()
	{
		SL_Data.st.Save_Setting();
	}

	// Token: 0x04000550 RID: 1360
	[SerializeField]
	private Slider slider_FPS;

	// Token: 0x04000551 RID: 1361
	[SerializeField]
	private Slider slider_glare;

	// Token: 0x04000552 RID: 1362
	[SerializeField]
	private Slider slider_camera_speed;

	// Token: 0x04000553 RID: 1363
	[SerializeField]
	private Slider slider_music;

	// Token: 0x04000554 RID: 1364
	[SerializeField]
	private Slider slider_sound;

	// Token: 0x04000555 RID: 1365
	[SerializeField]
	private Toggle toggle_helper;

	// Token: 0x04000556 RID: 1366
	[SerializeField]
	private Toggle toggle_next_card;

	// Token: 0x04000557 RID: 1367
	[SerializeField]
	private Toggle toggle_timer;

	// Token: 0x04000558 RID: 1368
	[SerializeField]
	private Toggle toggle_audio_item_find;

	// Token: 0x04000559 RID: 1369
	[SerializeField]
	private Toggle toggle_audio_group_find;

	// Token: 0x0400055A RID: 1370
	[SerializeField]
	private Button button_exit_setting;
}
