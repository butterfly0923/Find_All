using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000A3 RID: 163
public class UI_Panel_Move : MonoBehaviour
{
	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060004A1 RID: 1185 RVA: 0x00015E28 File Offset: 0x00014028
	public bool Current_status
	{
		get
		{
			return this.current_status;
		}
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00015E30 File Offset: 0x00014030
	private void go_update(bool on_off)
	{
		foreach (GameObject gameObject in this.main_go)
		{
			if (gameObject != null)
			{
				gameObject.SetActive(on_off);
			}
		}
		foreach (Image image in this.images_on_off)
		{
			if (image != null)
			{
				image.enabled = on_off;
			}
		}
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x00015E94 File Offset: 0x00014094
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

	// Token: 0x060004A4 RID: 1188 RVA: 0x00015ECC File Offset: 0x000140CC
	private void Awake()
	{
		this.main_transform.localPosition = (this.start_status ? this.on_position : this.off_position);
		this.go_update(this.start_status);
		this.button_update(this.start_status);
		this.current_status = this.start_status;
		this.set_point_position();
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x00015F24 File Offset: 0x00014124
	private void set_point_position()
	{
		if (this.on_position_go)
		{
			this.on_position = this.on_position_go.transform.localPosition;
			this.on_position_go.SetActive(false);
		}
		if (this.off_position_go)
		{
			this.off_position = this.off_position_go.transform.localPosition;
			this.off_position_go.SetActive(false);
		}
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x00015F8F File Offset: 0x0001418F
	public void off_momental()
	{
		this.main_transform.localPosition = this.off_position;
		this.button_update(false);
		this.go_update(false);
		this.current_status = false;
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x00015FB7 File Offset: 0x000141B7
	public IEnumerator IE_Panel_On()
	{
		Debug.Log(base.gameObject.name + "Начало корутины - IE_Panel_On");
		this.go_update(true);
		this.button_update(false);
		float speed_data = SL_Data.d_Setting.Speed_UI;
		if (SL_Data.d_Setting.Momental_speed_UI)
		{
			this.main_transform.localPosition = this.on_position;
		}
		else
		{
			float value_lerp = 0f;
			while (value_lerp < 1f)
			{
				value_lerp += Time.deltaTime * this.speed_open * speed_data;
				this.main_transform.localPosition = Vector3.Lerp(this.off_position, this.on_position, this.curve_open.Evaluate(value_lerp));
				yield return new WaitForSeconds(Time.deltaTime);
			}
			this.main_transform.localPosition = Vector3.Lerp(this.off_position, this.on_position, this.curve_open.Evaluate(1f));
		}
		this.button_update(true);
		this.current_status = true;
		Debug.Log(base.gameObject.name + "Конец корутины - IE_Panel_On");
		yield break;
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00015FC6 File Offset: 0x000141C6
	public IEnumerator IE_Panel_Off()
	{
		Debug.Log(base.gameObject.name + "Начало корутины - IE_Panel_Off");
		this.go_update(true);
		this.button_update(false);
		float speed_data = SL_Data.d_Setting.Speed_UI;
		if (SL_Data.d_Setting.Momental_speed_UI)
		{
			this.main_transform.localPosition = this.off_position;
		}
		else
		{
			float value_lerp = 1f;
			while (value_lerp > 0f)
			{
				value_lerp -= Time.deltaTime * this.speed_closed * speed_data;
				this.main_transform.localPosition = Vector3.Lerp(this.off_position, this.on_position, this.curve_closed.Evaluate(value_lerp));
				yield return new WaitForSeconds(Time.deltaTime);
			}
			this.main_transform.localPosition = Vector3.Lerp(this.off_position, this.on_position, this.curve_closed.Evaluate(0f));
		}
		this.go_update(false);
		this.current_status = false;
		Debug.Log(base.gameObject.name + "Конец корутины - IE_Panel_Off");
		yield break;
	}

	// Token: 0x040004C0 RID: 1216
	[Header("Основной объект:")]
	[SerializeField]
	private RectTransform main_transform;

	// Token: 0x040004C1 RID: 1217
	[Header("Координаты показа:")]
	[SerializeField]
	private Vector3 on_position;

	// Token: 0x040004C2 RID: 1218
	[Header("Координаты выключенной панели:")]
	[SerializeField]
	private Vector3 off_position;

	// Token: 0x040004C3 RID: 1219
	[Header("Координаты показа:")]
	[SerializeField]
	private GameObject on_position_go;

	// Token: 0x040004C4 RID: 1220
	[Header("Координаты выключенной панели:")]
	[SerializeField]
	private GameObject off_position_go;

	// Token: 0x040004C5 RID: 1221
	[Header("Скорость перемещения открытия/закрытия:")]
	[SerializeField]
	private float speed_open;

	// Token: 0x040004C6 RID: 1222
	[SerializeField]
	private float speed_closed;

	// Token: 0x040004C7 RID: 1223
	[Header("Графики движения при открытии/закрытия:")]
	[SerializeField]
	private AnimationCurve curve_open;

	// Token: 0x040004C8 RID: 1224
	[SerializeField]
	private AnimationCurve curve_closed;

	// Token: 0x040004C9 RID: 1225
	[Header("Все объекты для вкл/выкл:")]
	[SerializeField]
	private GameObject[] main_go;

	// Token: 0x040004CA RID: 1226
	[Header("Все кнопки для вкл/выкл:")]
	[SerializeField]
	private Button[] buttons_on_off;

	// Token: 0x040004CB RID: 1227
	[Header("Изображения для появление/исчезновения:")]
	[SerializeField]
	private Image[] images_on_off;

	// Token: 0x040004CC RID: 1228
	[Header("Начальное положение интерфейса:")]
	[SerializeField]
	private bool start_status;

	// Token: 0x040004CD RID: 1229
	[Header("Текущее состояние панели:")]
	[SerializeField]
	private bool current_status;
}
