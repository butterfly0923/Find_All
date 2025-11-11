using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000028 RID: 40
public class UI_Move_Up_Down : MonoBehaviour
{
	// Token: 0x060000FF RID: 255 RVA: 0x000071B8 File Offset: 0x000053B8
	private void OnEnable()
	{
		Events_Menu_UI.Puzzle_stady_on_off = (Action<bool, bool>)Delegate.Combine(Events_Menu_UI.Puzzle_stady_on_off, new Action<bool, bool>(this.Puzzle_event_on_off));
		Events_Menu_UI.End_Level = (Action<int>)Delegate.Combine(Events_Menu_UI.End_Level, new Action<int>(this.UI_Off_Level_end));
	}

	// Token: 0x06000100 RID: 256 RVA: 0x00007208 File Offset: 0x00005408
	private void OnDisable()
	{
		Events_Menu_UI.Puzzle_stady_on_off = (Action<bool, bool>)Delegate.Remove(Events_Menu_UI.Puzzle_stady_on_off, new Action<bool, bool>(this.Puzzle_event_on_off));
		Events_Menu_UI.End_Level = (Action<int>)Delegate.Remove(Events_Menu_UI.End_Level, new Action<int>(this.UI_Off_Level_end));
	}

	// Token: 0x06000101 RID: 257 RVA: 0x00007255 File Offset: 0x00005455
	private void Awake()
	{
		this.this_rectTransform = base.GetComponent<RectTransform>();
		this.start_setting_position(this.start_state_UI);
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0000726F File Offset: 0x0000546F
	protected void Start()
	{
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00007274 File Offset: 0x00005474
	protected void start_setting_position(bool On_Off)
	{
		this.off = On_Off;
		this.on = !On_Off;
		this.lerp_position = (float)(this.start_state_UI ? 1 : 0);
		this.this_rectTransform.localPosition = Vector3.Lerp(this.OFF_position.localPosition, this.ON_position.localPosition, this.curve_on.Evaluate(this.lerp_position));
		if (On_Off)
		{
			UnityEvent on_Start_Event = this.On_Start_Event;
			if (on_Start_Event != null)
			{
				on_Start_Event.Invoke();
			}
			UnityEvent on_Finish_Event = this.On_Finish_Event;
			if (on_Finish_Event != null)
			{
				on_Finish_Event.Invoke();
			}
		}
		else
		{
			UnityEvent off_Start_Event = this.Off_Start_Event;
			if (off_Start_Event != null)
			{
				off_Start_Event.Invoke();
			}
			UnityEvent off_Finish_Event = this.Off_Finish_Event;
			if (off_Finish_Event != null)
			{
				off_Finish_Event.Invoke();
			}
		}
		this.Button_enabled(On_Off);
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000732C File Offset: 0x0000552C
	protected void Puzzle_event_on_off(bool on_off, bool start_update)
	{
		if (this.Puzzle_event)
		{
			if (start_update)
			{
				this.start_state_UI = on_off;
				this.start_setting_position(on_off);
				return;
			}
			if (on_off)
			{
				this.UI_On();
				return;
			}
			this.UI_Off();
		}
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00007358 File Offset: 0x00005558
	public void UI_Visible_ON_OFF()
	{
		this.start_state_UI = !this.start_state_UI;
		if (this.void_coroutine != null)
		{
			base.StopCoroutine(this.void_coroutine);
		}
		base.StartCoroutine(this.void_coroutine = (this.start_state_UI ? this.UI_on_cor() : this.UI_off_cor()));
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000073B0 File Offset: 0x000055B0
	protected void Button_enabled(bool on_off)
	{
		if (this.Buttons_on_off != null)
		{
			Button[] buttons_on_off = this.Buttons_on_off;
			for (int i = 0; i < buttons_on_off.Length; i++)
			{
				buttons_on_off[i].interactable = on_off;
			}
		}
	}

	// Token: 0x06000107 RID: 263 RVA: 0x000073E4 File Offset: 0x000055E4
	public virtual void UI_On()
	{
		if (!this.start_state_UI)
		{
			this.start_state_UI = true;
			base.StartCoroutine(this.void_coroutine = this.UI_on_cor());
		}
	}

	// Token: 0x06000108 RID: 264 RVA: 0x00007418 File Offset: 0x00005618
	public virtual void UI_On_Menu()
	{
		if (!this.start_state_UI)
		{
			this.start_state_UI = true;
			base.StartCoroutine(this.void_coroutine = this.UI_on_cor_menu());
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0000744C File Offset: 0x0000564C
	public void UI_Off()
	{
		if (this.start_state_UI)
		{
			this.start_state_UI = false;
			base.StartCoroutine(this.void_coroutine = this.UI_off_cor());
		}
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00007480 File Offset: 0x00005680
	public void UI_Off_Level_end(int this_level)
	{
		if (!this.Next_level_map_event)
		{
			base.StartCoroutine(this.UI_off_cor_level_end());
			return;
		}
		GameObject gameObject = base.gameObject;
		Debug.Log("<color=red>" + gameObject.name + " ON!!! </color>", gameObject);
		base.StartCoroutine(this.UI_next_level_frame_On());
	}

	// Token: 0x0600010B RID: 267 RVA: 0x000074D2 File Offset: 0x000056D2
	private IEnumerator UI_next_level_frame_On()
	{
		yield return new WaitForSeconds(1f);
		base.StartCoroutine(this.UI_on_cor());
		this.lerp_position = 0f;
		yield break;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x000074E1 File Offset: 0x000056E1
	protected virtual IEnumerator UI_on_cor()
	{
		Debug.Log(base.gameObject.name + " on_cor");
		this.curve_move = (this.move ? this.curve_move : this.curve_on);
		this.move = true;
		this.off = true;
		this.on = false;
		float speed = this.fixed_time / this.time_on * SL_Data.d_Setting.Speed_UI;
		yield return new WaitForFixedUpdate();
		UnityEvent on_Start_Event = this.On_Start_Event;
		if (on_Start_Event != null)
		{
			on_Start_Event.Invoke();
		}
		this.Button_enabled(true);
		Debug.Log(base.gameObject.name + " on_cor_1");
		while (!this.on)
		{
			this.lerp_position += speed;
			if (this.lerp_position >= 1f)
			{
				this.lerp_position = 1f;
				this.on = true;
				this.off = false;
				this.move = false;
			}
			if ((!Status_All.Level_Complite && !this.Next_level_map_event) || (Status_All.Level_Complite && this.Next_level_map_event))
			{
				this.this_rectTransform.localPosition = Vector3.Lerp(this.OFF_position.localPosition, this.ON_position.localPosition, this.curve_move.Evaluate(this.lerp_position));
			}
			yield return new WaitForFixedUpdate();
		}
		Debug.Log(base.gameObject.name + " on_cor_2");
		UnityEvent on_Finish_Event = this.On_Finish_Event;
		if (on_Finish_Event != null)
		{
			on_Finish_Event.Invoke();
		}
		if (!Sa_IS.Puzzle_open)
		{
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		}
		Debug.Log(string.Format("Sa_IS.input_Main.Game_Play -{0}", SL_Data.d_Setting.Tutorial_Game));
		if (!SL_Data.d_Setting.Tutorial_Game)
		{
			Debug.Log(string.Format("SL_Data.d_Setting.Tutorial_Game -{0}", SL_Data.d_Setting.Tutorial_Game));
			SL_Data.d_Setting.Tutorial_Game = true;
			SL_Data.st.Save_Setting();
			Action open_Tutorial_Game = Events_Menu_UI.Open_Tutorial_Game;
			if (open_Tutorial_Game != null)
			{
				open_Tutorial_Game();
			}
		}
		Debug.Log(base.gameObject.name + " on_cor_3");
		yield break;
	}

	// Token: 0x0600010D RID: 269 RVA: 0x000074F0 File Offset: 0x000056F0
	protected virtual IEnumerator UI_on_cor_menu()
	{
		this.curve_move = (this.move ? this.curve_move : this.curve_on);
		this.move = true;
		this.off = true;
		this.on = false;
		float speed = this.fixed_time / this.time_on * SL_Data.d_Setting.Speed_UI;
		yield return new WaitForFixedUpdate();
		UnityEvent on_Start_Event = this.On_Start_Event;
		if (on_Start_Event != null)
		{
			on_Start_Event.Invoke();
		}
		this.Button_enabled(true);
		while (!this.on)
		{
			this.lerp_position += speed;
			if (this.lerp_position >= 1f)
			{
				this.lerp_position = 1f;
				this.on = true;
				this.off = false;
				this.move = false;
			}
			if (!Status_All.Level_Complite)
			{
				this.this_rectTransform.localPosition = Vector3.Lerp(this.OFF_position.localPosition, this.ON_position.localPosition, this.curve_move.Evaluate(this.lerp_position));
			}
			yield return new WaitForFixedUpdate();
		}
		UnityEvent on_Finish_Event = this.On_Finish_Event;
		if (on_Finish_Event != null)
		{
			on_Finish_Event.Invoke();
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		yield break;
	}

	// Token: 0x0600010E RID: 270 RVA: 0x000074FF File Offset: 0x000056FF
	protected virtual IEnumerator UI_off_cor()
	{
		this.curve_move = (this.move ? this.curve_move : this.curve_off);
		this.move = true;
		this.off = false;
		this.on = true;
		float speed = this.fixed_time / this.time_off * SL_Data.d_Setting.Speed_UI;
		UnityEvent off_Start_Event = this.Off_Start_Event;
		if (off_Start_Event != null)
		{
			off_Start_Event.Invoke();
		}
		this.Button_enabled(false);
		while (!this.off)
		{
			this.lerp_position -= speed;
			if (this.lerp_position <= 0f)
			{
				this.lerp_position = 0f;
				this.on = false;
				this.off = true;
				this.move = false;
			}
			if ((!Status_All.Level_Complite && !this.Next_level_map_event) || (Status_All.Level_Complite && this.Next_level_map_event))
			{
				this.this_rectTransform.localPosition = Vector3.Lerp(this.OFF_position.localPosition, this.ON_position.localPosition, this.curve_move.Evaluate(this.lerp_position));
			}
			yield return new WaitForFixedUpdate();
		}
		UnityEvent off_Finish_Event = this.Off_Finish_Event;
		if (off_Finish_Event != null)
		{
			off_Finish_Event.Invoke();
		}
		yield break;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x0000750E File Offset: 0x0000570E
	protected virtual IEnumerator UI_off_cor_level_end()
	{
		this.curve_move = (this.move ? this.curve_move : this.curve_off);
		this.move = true;
		this.off = false;
		this.on = true;
		float speed = this.fixed_time / this.time_off * SL_Data.d_Setting.Speed_UI;
		UnityEvent off_Start_Event = this.Off_Start_Event;
		if (off_Start_Event != null)
		{
			off_Start_Event.Invoke();
		}
		this.Button_enabled(false);
		while (!this.off)
		{
			this.lerp_position -= speed;
			if (this.lerp_position <= 0f)
			{
				this.lerp_position = 0f;
				this.on = false;
				this.off = true;
				this.move = false;
			}
			this.this_rectTransform.localPosition = Vector3.Lerp(this.OFF_position.localPosition, this.ON_position.localPosition, this.curve_move.Evaluate(this.lerp_position));
			yield return new WaitForFixedUpdate();
		}
		UnityEvent off_Finish_Event = this.Off_Finish_Event;
		if (off_Finish_Event != null)
		{
			off_Finish_Event.Invoke();
		}
		yield break;
	}

	// Token: 0x06000110 RID: 272 RVA: 0x0000751D File Offset: 0x0000571D
	private IEnumerator UI_on_off_cor(bool on_off)
	{
		if (!this.move)
		{
			this.curve_move = (on_off ? this.curve_on : this.curve_off);
		}
		this.move = true;
		this.off = !on_off;
		this.on = on_off;
		float speed = on_off ? (this.fixed_time / this.time_on * SL_Data.d_Setting.Speed_UI) : (-this.fixed_time / this.time_off * SL_Data.d_Setting.Speed_UI);
		if (on_off)
		{
			UnityEvent on_Start_Event = this.On_Start_Event;
			if (on_Start_Event != null)
			{
				on_Start_Event.Invoke();
			}
		}
		else
		{
			UnityEvent off_Start_Event = this.Off_Start_Event;
			if (off_Start_Event != null)
			{
				off_Start_Event.Invoke();
			}
		}
		while (on_off ? this.on : this.off)
		{
			this.lerp_position += speed;
			if (on_off ? (this.lerp_position >= 1f) : (this.lerp_position <= 0f))
			{
				this.lerp_position = (float)(on_off ? 1 : 0);
				this.on = on_off;
				this.off = !on_off;
				this.move = false;
			}
			this.this_rectTransform.localPosition = Vector3.Lerp(this.OFF_position.localPosition, this.ON_position.localPosition, on_off ? this.curve_on.Evaluate(this.lerp_position) : this.curve_off.Evaluate(this.lerp_position));
			yield return new WaitForFixedUpdate();
		}
		if (on_off)
		{
			UnityEvent on_Finish_Event = this.On_Finish_Event;
			if (on_Finish_Event != null)
			{
				on_Finish_Event.Invoke();
			}
		}
		else
		{
			UnityEvent off_Finish_Event = this.Off_Finish_Event;
			if (off_Finish_Event != null)
			{
				off_Finish_Event.Invoke();
			}
		}
		yield break;
	}

	// Token: 0x0400010F RID: 271
	[Header("Позиция On:")]
	[SerializeField]
	protected RectTransform ON_position;

	// Token: 0x04000110 RID: 272
	[Header("Позиция Off:")]
	[SerializeField]
	protected RectTransform OFF_position;

	// Token: 0x04000111 RID: 273
	[Header("Скорость включения (выдвигания) панели в секундах:")]
	[SerializeField]
	protected float time_on;

	// Token: 0x04000112 RID: 274
	[Header("График скорости включения панели:")]
	[SerializeField]
	protected AnimationCurve curve_on;

	// Token: 0x04000113 RID: 275
	[Header("Скорость выключения (задвигания) панели в секундах:")]
	[SerializeField]
	protected float time_off;

	// Token: 0x04000114 RID: 276
	[Header("График скорости выключения панели:")]
	[SerializeField]
	protected AnimationCurve curve_off;

	// Token: 0x04000115 RID: 277
	[Header("ВКЛЮЧЕНИЕ:")]
	[Header("События при начале включения:")]
	public UnityEvent On_Start_Event;

	// Token: 0x04000116 RID: 278
	public UnityEvent On_Start_Event_on_Gamepad;

	// Token: 0x04000117 RID: 279
	[Header("События в конце включения:")]
	public UnityEvent On_Finish_Event;

	// Token: 0x04000118 RID: 280
	[Header("ВЫКЛЮЧЕНИЕ:")]
	[Header("События при начале выключения:")]
	public UnityEvent Off_Start_Event;

	// Token: 0x04000119 RID: 281
	[Header("События в конце выключения:")]
	public UnityEvent Off_Finish_Event;

	// Token: 0x0400011A RID: 282
	[Header("Кнопки включаются/выключаются начале включения/выключения:")]
	public Button[] Buttons_on_off;

	// Token: 0x0400011B RID: 283
	[Header("Начальное состояние UI элемента:")]
	[SerializeField]
	protected bool start_state_UI;

	// Token: 0x0400011C RID: 284
	[Header("Эвент пазла:")]
	[SerializeField]
	private bool Puzzle_event;

	// Token: 0x0400011D RID: 285
	[Header("Кнопка следующий уровень/карта:")]
	[SerializeField]
	private bool Next_level_map_event;

	// Token: 0x0400011E RID: 286
	protected RectTransform this_rectTransform;

	// Token: 0x0400011F RID: 287
	protected float lerp_position;

	// Token: 0x04000120 RID: 288
	protected bool off;

	// Token: 0x04000121 RID: 289
	protected bool on;

	// Token: 0x04000122 RID: 290
	protected bool move;

	// Token: 0x04000123 RID: 291
	protected AnimationCurve curve_move;

	// Token: 0x04000124 RID: 292
	protected float fixed_time = 0.02f;

	// Token: 0x04000125 RID: 293
	protected IEnumerator void_coroutine;
}
