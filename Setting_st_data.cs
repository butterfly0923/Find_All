using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

// Token: 0x020000B0 RID: 176
public static class Setting_st_data
{
	// Token: 0x060004FD RID: 1277 RVA: 0x000183A6 File Offset: 0x000165A6
	public static void Set_Glare_Camera(SpriteRenderer sprite_value, AnimationCurve curve_value)
	{
		Setting_st_data.glare_camera = sprite_value;
		Setting_st_data.glare_curve = curve_value;
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x000183B4 File Offset: 0x000165B4
	public static void Update_Glare_Value(float value)
	{
		SL_Data.d_Setting.Glare = value;
		Color color = Setting_st_data.glare_camera.color;
		color.a = Setting_st_data.glare_curve.Evaluate(value);
		Setting_st_data.glare_camera.color = color;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x000183F4 File Offset: 0x000165F4
	public static void Set_FPS(TMP_Text value)
	{
		Setting_st_data.FPS_count = value;
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x000183FC File Offset: 0x000165FC
	public static void Update_TMP(float value)
	{
		Debug.Log("Обновление частоты кадров - " + Mathf.RoundToInt(value).ToString());
		SL_Data.d_Setting.Max_FPS = Mathf.RoundToInt(value);
		Application.targetFrameRate = SL_Data.d_Setting.Max_FPS;
		Setting_st_data.FPS_count.text = (SL_Data.d_Setting.Max_FPS.ToString() ?? "");
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x00018467 File Offset: 0x00016667
	public static void Set_Mixer_Group(AudioMixerGroup sound_group_value, AudioMixerGroup music_group_value, AudioMixerGroup voice_group_value, AnimationCurve volume_curve_value)
	{
		Setting_st_data.sound_group = sound_group_value;
		Setting_st_data.music_group = music_group_value;
		Setting_st_data.voice_group = voice_group_value;
		Setting_st_data.volume_curve = volume_curve_value;
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00018481 File Offset: 0x00016681
	public static void Update_Volume_Sound(float value)
	{
		SL_Data.d_Setting.Sound_Mixer = value;
		Setting_st_data.sound_group.audioMixer.SetFloat("Sound", Setting_st_data.volume_curve.Evaluate(value));
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x000184AE File Offset: 0x000166AE
	public static void Update_Volume_Music(float value)
	{
		SL_Data.d_Setting.Music_Mixer = value;
		Setting_st_data.music_group.audioMixer.SetFloat("Music", Setting_st_data.volume_curve.Evaluate(value));
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x000184DB File Offset: 0x000166DB
	public static void Update_Helper_Status(bool value)
	{
		Debug.Log("Обновление статуса кнопки помощи - " + value.ToString());
		SL_Data.d_Setting.Helper = value;
		Action action = Setting_st_data.helper_update;
		if (action == null)
		{
			return;
		}
		action();
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x0001850D File Offset: 0x0001670D
	public static void Update_Select_Hext_Card_Status(bool value)
	{
		Debug.Log("Обновление статуса выбора следующей карты - " + value.ToString());
		SL_Data.d_Setting.Next_Card = value;
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00018530 File Offset: 0x00016730
	public static void Update_Select_Timer_Status(bool value)
	{
		Debug.Log("Обновление статуса таймера - " + value.ToString());
		SL_Data.d_Setting.Timer_On = value;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00018553 File Offset: 0x00016753
	public static void Update_Audio_Item_Find(bool value)
	{
		SL_Data.d_Setting.Sound_Item_Find = value;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00018560 File Offset: 0x00016760
	public static void Update_Audio_Group_Find(bool value)
	{
		SL_Data.d_Setting.Sound_Group_Find = value;
	}

	// Token: 0x0400055B RID: 1371
	private static SpriteRenderer glare_camera;

	// Token: 0x0400055C RID: 1372
	private static AnimationCurve glare_curve;

	// Token: 0x0400055D RID: 1373
	private static TMP_Text FPS_count;

	// Token: 0x0400055E RID: 1374
	private static AudioMixerGroup sound_group;

	// Token: 0x0400055F RID: 1375
	private static AudioMixerGroup music_group;

	// Token: 0x04000560 RID: 1376
	private static AudioMixerGroup voice_group;

	// Token: 0x04000561 RID: 1377
	private static AnimationCurve volume_curve;

	// Token: 0x04000562 RID: 1378
	public static Action helper_update;
}
