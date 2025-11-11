using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x0200002F RID: 47
public class Puzzle_Segment : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
	// Token: 0x06000141 RID: 321 RVA: 0x00007E04 File Offset: 0x00006004
	public void Awake_setting(Puzzle_Manager main_v)
	{
		this.puzzle_Manager_main = main_v;
		this.this_transform = base.GetComponent<RectTransform>();
		this.finish_position = this.this_transform.localPosition;
		this.scrolling = Sa_IS.input_Main.Main.Scrolling;
		this.QE_scrolling = Sa_IS.input_Main.Puzzle_Play.QE_rotate;
		this.segment_image = base.GetComponent<Image>();
		Transform child = base.transform.GetChild(0);
		this.segment_complite_image = ((child != null) ? child.transform.GetComponent<Image>() : null);
		this.segment_complite_image.color = new Color(1f, 1f, 1f, 0f);
		this.segment_image.color = new Color(1f, 1f, 1f, 0f);
		this.segment_complite_image.raycastTarget = false;
		this.segment_image.alphaHitTestMinimumThreshold = 0.5f;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00007EF8 File Offset: 0x000060F8
	private void OnEnable()
	{
		this.QE_scrolling.started += this.QE_rotate_start;
		this.QE_scrolling.canceled += this.QE_rotate_stop;
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00007F28 File Offset: 0x00006128
	private void OnDisable()
	{
		this.QE_scrolling.started -= this.QE_rotate_start;
		this.QE_scrolling.canceled -= this.QE_rotate_stop;
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00007F58 File Offset: 0x00006158
	public void Load_Status(bool status_v, Vector2 zone_v, bool left_right_v)
	{
		if (status_v)
		{
			this.this_transform.localPosition = this.finish_position;
			this.this_transform.SetAsFirstSibling();
			this.finish = true;
			this.segment_image.raycastTarget = false;
			return;
		}
		this.Z_rotate = (float)Random.Range(0, 36) * 10f;
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = this.Multiply_max_y * num;
		if (left_right_v)
		{
			float x = Random.Range(-num2, zone_v.x - 100f);
			this.this_transform.localPosition = new Vector3(x, Random.Range(-this.Multiply_max_y, this.Multiply_max_y), 0f);
			this.this_transform.eulerAngles = new Vector3(0f, 0f, this.Z_rotate);
			return;
		}
		float x2 = Random.Range(num2, zone_v.x + 100f);
		this.this_transform.localPosition = new Vector3(x2, Random.Range(-this.Multiply_max_y, this.Multiply_max_y), 0f);
		this.this_transform.eulerAngles = new Vector3(0f, 0f, this.Z_rotate);
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0000807F File Offset: 0x0000627F
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnMouseEnter()");
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0000808B File Offset: 0x0000628B
	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnMouseExit()");
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00008098 File Offset: 0x00006298
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!this.mover && !this.open_closed && this.puzzle_Manager_main.Move_new_segment(this) && !this.finish)
		{
			this.this_transform.SetAsLastSibling();
			this.curcor_position_down = Mouse.current.position.ReadValue();
			this.position_this = this.this_transform.localPosition;
			this.mover = true;
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_Move_and_Rotation());
			if (this.rotate_qe_coroutine != null)
			{
				base.StopCoroutine(this.rotate_qe_coroutine);
			}
		}
	}

	// Token: 0x06000148 RID: 328 RVA: 0x00008148 File Offset: 0x00006348
	public void Segment_down()
	{
		if (!this.finish)
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			if (this.rotate_qe_coroutine != null)
			{
				base.StopCoroutine(this.rotate_qe_coroutine);
			}
			this.Test_Finish_position();
			base.StartCoroutine(this.end_down_segment());
		}
		if (SL_Data.st.god_mod)
		{
			this.finish = true;
			this.segment_image.raycastTarget = false;
			base.StartCoroutine(this.IE_finish_detal_position());
		}
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000081C4 File Offset: 0x000063C4
	private IEnumerator end_down_segment()
	{
		yield return new WaitForEndOfFrame();
		this.mover = false;
		yield break;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x000081D3 File Offset: 0x000063D3
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000081D5 File Offset: 0x000063D5
	private void QE_rotate_start(InputAction.CallbackContext value)
	{
		if (this.mover)
		{
			this.rotate_qe_coroutine = base.StartCoroutine(this.IE_rotate_segment(value));
		}
	}

	// Token: 0x0600014C RID: 332 RVA: 0x000081F2 File Offset: 0x000063F2
	private void QE_rotate_stop(InputAction.CallbackContext value)
	{
		if (this.mover && this.rotate_qe_coroutine != null)
		{
			base.StopCoroutine(this.rotate_qe_coroutine);
		}
	}

	// Token: 0x0600014D RID: 333 RVA: 0x00008210 File Offset: 0x00006410
	private IEnumerator IE_rotate_segment(InputAction.CallbackContext value)
	{
		int I = 0;
		if (value.ReadValue<float>() > 0f)
		{
			this.Z_rotate -= 10f;
		}
		else if (value.ReadValue<float>() < 0f)
		{
			this.Z_rotate += 10f;
		}
		yield return new WaitForSeconds(0.3f);
		while (I < 10)
		{
			I++;
			if (value.ReadValue<float>() > 0f)
			{
				this.Z_rotate -= 10f;
			}
			else if (value.ReadValue<float>() < 0f)
			{
				this.Z_rotate += 10f;
			}
			yield return new WaitForSeconds(0.1f);
		}
		for (;;)
		{
			if (value.ReadValue<float>() > 0f)
			{
				this.Z_rotate -= 10f;
			}
			else if (value.ReadValue<float>() < 0f)
			{
				this.Z_rotate += 10f;
			}
			yield return new WaitForSeconds(0.05f);
		}
		yield break;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00008226 File Offset: 0x00006426
	private IEnumerator IE_Move_and_Rotation()
	{
		float screen_multiply = 1080f / (float)Screen.height;
		Debug.Log(string.Format("Мультиплай - {0}", screen_multiply));
		while (this.mover)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			if (Mouse.current.scroll.ReadValue().y > 0f)
			{
				this.Z_rotate += 10f;
			}
			else if (Mouse.current.scroll.ReadValue().y < 0f)
			{
				this.Z_rotate -= 10f;
			}
			Vector2 a = Mouse.current.position.ReadValue();
			this.this_transform.localPosition = this.position_this - this.curcor_position_down * (this.Multiply_position * screen_multiply) + a * (this.Multiply_position * screen_multiply);
			this.this_transform.localRotation = Quaternion.Euler(0f, 0f, this.Z_rotate);
		}
		yield break;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00008238 File Offset: 0x00006438
	private void Test_Finish_position()
	{
		Debug.Log(string.Format("Угол поворота - {0}", this.this_transform.localRotation.eulerAngles.z));
		Debug.Log(string.Format("{0} -- {1}", this.finish_position, this.this_transform.localPosition));
		if (Vector3.Distance(this.finish_position, this.this_transform.localPosition) < 60f && (this.this_transform.localRotation.eulerAngles.z < 13f || this.this_transform.localRotation.eulerAngles.z > 347f))
		{
			Debug.Log("ДЕТАЛЬ НА МЕСТО");
			this.finish = true;
			this.segment_image.raycastTarget = false;
			base.StartCoroutine(this.IE_finish_detal_position());
			return;
		}
		Debug.Log(string.Format("this_transform.localPosition.y - {0}", this.this_transform.localPosition.y));
		if (this.this_transform.localPosition.y > this.Multiply_max_y)
		{
			this.this_transform.localPosition = new Vector3(this.this_transform.localPosition.x, this.Multiply_max_y, this.this_transform.localPosition.z);
		}
		else if (this.this_transform.localPosition.y < -this.Multiply_max_y)
		{
			this.this_transform.localPosition = new Vector3(this.this_transform.localPosition.x, -this.Multiply_max_y, this.this_transform.localPosition.z);
		}
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = this.Multiply_max_y * num;
		if (this.this_transform.localPosition.x > num2)
		{
			this.this_transform.localPosition = new Vector3(num2, this.this_transform.localPosition.y, this.this_transform.localPosition.z);
			return;
		}
		if (this.this_transform.localPosition.x < -num2)
		{
			this.this_transform.localPosition = new Vector3(-num2, this.this_transform.localPosition.y, this.this_transform.localPosition.z);
		}
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00008487 File Offset: 0x00006687
	private IEnumerator IE_finish_detal_position()
	{
		Action st_puzzle_segment_complite = Events_Menu_UI.St_puzzle_segment_complite;
		if (st_puzzle_segment_complite != null)
		{
			st_puzzle_segment_complite();
		}
		base.StartCoroutine(this.IE_finish_color());
		float value = 0f;
		float Z_finish = (float)((this.this_transform.localRotation.eulerAngles.z < 180f) ? 0 : 360);
		Vector3 finish_start_position = this.this_transform.localPosition;
		float Z_finish_start_angle = this.this_transform.localRotation.eulerAngles.z;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_finish * SL_Data.d_Setting.Speed_cards_UI;
			this.this_transform.localPosition = Vector3.Lerp(finish_start_position, this.finish_position, value);
			this.this_transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(Z_finish_start_angle, Z_finish, value));
		}
		this.this_transform.SetAsFirstSibling();
		yield break;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x00008496 File Offset: 0x00006696
	private IEnumerator IE_finish_color()
	{
		this.puzzle_Manager_main.Puzzle_Segment_Complite(this);
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_color * SL_Data.d_Setting.Speed_cards_UI;
			this.segment_complite_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
		}
		value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_color * SL_Data.d_Setting.Speed_cards_UI;
			this.segment_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
		}
		yield break;
	}

	// Token: 0x06000152 RID: 338 RVA: 0x000084A5 File Offset: 0x000066A5
	public bool Return_Finish_segment()
	{
		return this.finish;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x000084AD File Offset: 0x000066AD
	public void Segment_On_Off(bool on_off)
	{
		base.StartCoroutine(this.IE_Puzzle_segment_On_Off(on_off));
	}

	// Token: 0x06000154 RID: 340 RVA: 0x000084BD File Offset: 0x000066BD
	private IEnumerator IE_Puzzle_segment_On_Off(bool on_off)
	{
		if (on_off)
		{
			Debug.Log(string.Format("this_transform.localPosition.y - {0}", this.this_transform.localPosition.y));
			if (this.this_transform.localPosition.y > this.Multiply_max_y)
			{
				this.this_transform.localPosition = new Vector3(this.this_transform.localPosition.x, this.Multiply_max_y, this.this_transform.localPosition.z);
			}
			else if (this.this_transform.localPosition.y < -this.Multiply_max_y)
			{
				this.this_transform.localPosition = new Vector3(this.this_transform.localPosition.x, -this.Multiply_max_y, this.this_transform.localPosition.z);
			}
			float num = (float)Screen.width / (float)Screen.height;
			float num2 = this.Multiply_max_y * num;
			if (this.this_transform.localPosition.x > num2)
			{
				this.this_transform.localPosition = new Vector3(num2, this.this_transform.localPosition.y, this.this_transform.localPosition.z);
			}
			else if (this.this_transform.localPosition.x < -num2)
			{
				this.this_transform.localPosition = new Vector3(-num2, this.this_transform.localPosition.y, this.this_transform.localPosition.z);
			}
		}
		this.open_closed = true;
		float value = 0f;
		if (on_off)
		{
			if (this.finish)
			{
				this.segment_image.color = new Color(1f, 1f, 1f, 0f);
				value = 0f;
				while (value < 1f)
				{
					value += Time.deltaTime * this.speed_color_on_off * SL_Data.d_Setting.Speed_cards_UI;
					this.segment_complite_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
					yield return new WaitForSeconds(Time.deltaTime);
				}
			}
			else
			{
				this.segment_complite_image.color = new Color(1f, 1f, 1f, 0f);
				value = 0f;
				while (value < 1f)
				{
					value += Time.deltaTime * this.speed_color_on_off * SL_Data.d_Setting.Speed_cards_UI;
					this.segment_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
					yield return new WaitForSeconds(Time.deltaTime);
				}
				if (this.mover)
				{
					this.Segment_down();
				}
			}
		}
		else if (this.finish)
		{
			this.segment_image.color = new Color(1f, 1f, 1f, 0f);
			value = 0f;
			while (value < 1f)
			{
				value += Time.deltaTime * this.speed_color_on_off * SL_Data.d_Setting.Speed_cards_UI;
				this.segment_complite_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
				yield return new WaitForSeconds(Time.deltaTime);
			}
		}
		else
		{
			this.segment_complite_image.color = new Color(1f, 1f, 1f, 0f);
			value = 0f;
			while (value < 1f)
			{
				value += Time.deltaTime * this.speed_color_on_off * SL_Data.d_Setting.Speed_cards_UI;
				this.segment_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
				yield return new WaitForSeconds(Time.deltaTime);
			}
			if (this.mover)
			{
				this.Segment_down();
			}
		}
		this.open_closed = false;
		yield break;
	}

	// Token: 0x04000153 RID: 339
	private Image segment_image;

	// Token: 0x04000154 RID: 340
	private Image segment_complite_image;

	// Token: 0x04000155 RID: 341
	private Puzzle_Manager puzzle_Manager_main;

	// Token: 0x04000156 RID: 342
	[SerializeField]
	private RectTransform this_transform;

	// Token: 0x04000157 RID: 343
	[SerializeField]
	private Vector2 position_this;

	// Token: 0x04000158 RID: 344
	[SerializeField]
	private Vector2 curcor_position_down;

	// Token: 0x04000159 RID: 345
	[SerializeField]
	private bool open_closed;

	// Token: 0x0400015A RID: 346
	[SerializeField]
	private bool mover;

	// Token: 0x0400015B RID: 347
	[SerializeField]
	private bool finish;

	// Token: 0x0400015C RID: 348
	[SerializeField]
	private InputAction scrolling;

	// Token: 0x0400015D RID: 349
	[SerializeField]
	private InputAction QE_scrolling;

	// Token: 0x0400015E RID: 350
	[SerializeField]
	private float Z_rotate;

	// Token: 0x0400015F RID: 351
	[SerializeField]
	private Vector3 finish_position;

	// Token: 0x04000160 RID: 352
	[SerializeField]
	private float speed_finish = 4f;

	// Token: 0x04000161 RID: 353
	[SerializeField]
	private float speed_color = 2f;

	// Token: 0x04000162 RID: 354
	[SerializeField]
	private float speed_color_on_off = 4f;

	// Token: 0x04000163 RID: 355
	[SerializeField]
	private float Multiply_position = 2.86f;

	// Token: 0x04000164 RID: 356
	[SerializeField]
	private float Multiply_max_y = 1300f;

	// Token: 0x04000165 RID: 357
	private Coroutine rotate_qe_coroutine;

	// Token: 0x04000166 RID: 358
	private Coroutine coroutine;
}
