using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A2 RID: 162
public class UI_Panel_Alpha : MonoBehaviour
{
	// Token: 0x0600049B RID: 1179 RVA: 0x00015D27 File Offset: 0x00013F27
	private void Awake()
	{
		this.go_update(this.start_status);
		this.button_update(this.start_status);
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x00015D44 File Offset: 0x00013F44
	private void go_update(bool on_off)
	{
		this.main_go.SetActive(on_off);
		if (this.black_front)
		{
			this.black_front.enabled = on_off;
		}
		foreach (Image image in this.images_on_off)
		{
			if (image != null)
			{
				image.enabled = on_off;
			}
		}
		foreach (TMP_Text tmp_Text in this.text_on_off)
		{
			if (tmp_Text != null)
			{
				tmp_Text.enabled = on_off;
			}
		}
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00015DCC File Offset: 0x00013FCC
	private void button_update(bool on_off)
	{
		foreach (Button button in this.buttons_on_off)
		{
			if (button != null)
			{
				button.interactable = on_off;
			}
		}
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x00015E02 File Offset: 0x00014002
	public IEnumerator IE_Panel_On()
	{
		Debug.Log(base.gameObject.name + "Начало корутины - IE_Panel_On");
		this.go_update(true);
		this.button_update(false);
		float speed_data = SL_Data.d_Setting.Speed_UI;
		if (SL_Data.d_Setting.Momental_speed_UI)
		{
			foreach (Image image in this.images_on_off)
			{
				if (!(image == null))
				{
					Color color = image.color;
					color.a = 1f;
					image.color = color;
				}
			}
			foreach (TMP_Text tmp_Text in this.text_on_off)
			{
				if (!(tmp_Text == null))
				{
					Color color2 = tmp_Text.color;
					color2.a = 1f;
					tmp_Text.color = color2;
				}
			}
			if (this.black_front)
			{
				this.black_front.color = new Color(this.black_front.color.r, this.black_front.color.g, this.black_front.color.b, this.curve_alpha_black_front.Evaluate(1f));
			}
		}
		else
		{
			float value_lerp = 0f;
			while (value_lerp < 1f)
			{
				value_lerp += Time.deltaTime * this.speed_on * speed_data;
				foreach (Image image2 in this.images_on_off)
				{
					if (!(image2 == null))
					{
						Color color3 = image2.color;
						color3.a = this.curve_on.Evaluate(value_lerp);
						image2.color = color3;
					}
				}
				foreach (TMP_Text tmp_Text2 in this.text_on_off)
				{
					if (!(tmp_Text2 == null))
					{
						Color color4 = tmp_Text2.color;
						color4.a = this.curve_on.Evaluate(value_lerp);
						tmp_Text2.color = color4;
					}
				}
				if (this.black_front)
				{
					this.black_front.color = new Color(this.black_front.color.r, this.black_front.color.g, this.black_front.color.b, this.curve_alpha_black_front.Evaluate(value_lerp));
				}
				yield return new WaitForSeconds(Time.deltaTime);
			}
			foreach (Image image3 in this.images_on_off)
			{
				if (!(image3 == null))
				{
					Color color5 = image3.color;
					color5.a = 1f;
					image3.color = color5;
				}
			}
			foreach (TMP_Text tmp_Text3 in this.text_on_off)
			{
				if (!(tmp_Text3 == null))
				{
					Color color6 = tmp_Text3.color;
					color6.a = 1f;
					tmp_Text3.color = color6;
				}
			}
		}
		this.button_update(true);
		Debug.Log(base.gameObject.name + "Конец корутины - IE_Panel_On");
		yield break;
	}

	// Token: 0x0600049F RID: 1183 RVA: 0x00015E11 File Offset: 0x00014011
	public IEnumerator IE_Panel_Off()
	{
		Debug.Log(base.gameObject.name + "Начало корутины - IE_Panel_Off");
		this.go_update(true);
		this.button_update(false);
		float speed_data = SL_Data.d_Setting.Speed_UI;
		if (SL_Data.d_Setting.Momental_speed_UI)
		{
			foreach (Image image in this.images_on_off)
			{
				if (!(image == null))
				{
					Color color = image.color;
					color.a = 0f;
					image.color = color;
				}
			}
			foreach (TMP_Text tmp_Text in this.text_on_off)
			{
				if (!(tmp_Text == null))
				{
					Color color2 = tmp_Text.color;
					color2.a = 0f;
					tmp_Text.color = color2;
				}
			}
			if (this.black_front)
			{
				this.black_front.color = new Color(this.black_front.color.r, this.black_front.color.g, this.black_front.color.b, this.curve_alpha_black_front.Evaluate(0f));
			}
		}
		else
		{
			float value_lerp = 1f;
			while (value_lerp > 0f)
			{
				value_lerp -= Time.deltaTime * this.speed_off * speed_data;
				foreach (Image image2 in this.images_on_off)
				{
					if (!(image2 == null))
					{
						Color color3 = image2.color;
						color3.a = this.curve_off.Evaluate(value_lerp);
						image2.color = color3;
					}
				}
				foreach (TMP_Text tmp_Text2 in this.text_on_off)
				{
					if (!(tmp_Text2 == null))
					{
						Color color4 = tmp_Text2.color;
						color4.a = this.curve_off.Evaluate(value_lerp);
						tmp_Text2.color = color4;
					}
				}
				if (this.black_front)
				{
					this.black_front.color = new Color(this.black_front.color.r, this.black_front.color.g, this.black_front.color.b, this.curve_alpha_black_front.Evaluate(value_lerp));
				}
				yield return new WaitForSeconds(Time.deltaTime);
			}
			foreach (Image image3 in this.images_on_off)
			{
				if (!(image3 == null))
				{
					Color color5 = image3.color;
					color5.a = 0f;
					image3.color = color5;
				}
			}
			foreach (TMP_Text tmp_Text3 in this.text_on_off)
			{
				if (!(tmp_Text3 == null))
				{
					Color color6 = tmp_Text3.color;
					color6.a = 0f;
					tmp_Text3.color = color6;
				}
			}
		}
		this.go_update(false);
		Debug.Log(base.gameObject.name + "Конец корутины - IE_Panel_Off");
		yield break;
	}

	// Token: 0x040004B5 RID: 1205
	[Header("Основной объект:")]
	[SerializeField]
	private GameObject main_go;

	// Token: 0x040004B6 RID: 1206
	[Header("Скорость перемещения появления/исчезновения:")]
	[SerializeField]
	private float speed_on;

	// Token: 0x040004B7 RID: 1207
	[SerializeField]
	private float speed_off;

	// Token: 0x040004B8 RID: 1208
	[Header("Графики прозрачности при появлении/исчезновении:")]
	[SerializeField]
	private AnimationCurve curve_on;

	// Token: 0x040004B9 RID: 1209
	[SerializeField]
	private AnimationCurve curve_off;

	// Token: 0x040004BA RID: 1210
	[Header("Изображения для появление/исчезновения:")]
	[SerializeField]
	private Image[] images_on_off;

	// Token: 0x040004BB RID: 1211
	[Header("Все кнопки для вкл/выкл:")]
	[SerializeField]
	private Button[] buttons_on_off;

	// Token: 0x040004BC RID: 1212
	[Header("Изображения для появление/исчезновения:")]
	[SerializeField]
	private TMP_Text[] text_on_off;

	// Token: 0x040004BD RID: 1213
	[Header("Затемняющий задний фон:")]
	[SerializeField]
	private Image black_front;

	// Token: 0x040004BE RID: 1214
	[SerializeField]
	private AnimationCurve curve_alpha_black_front;

	// Token: 0x040004BF RID: 1215
	[Header("Начальное состояние интерфейса:")]
	[SerializeField]
	private bool start_status;
}
