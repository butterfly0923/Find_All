using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200002D RID: 45
public class Puzzle_Full : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerMoveHandler
{
	// Token: 0x06000120 RID: 288 RVA: 0x00007670 File Offset: 0x00005870
	public void Awake_setting(Puzzle_Manager puzzle_Manager_v)
	{
		this.rectTransform = base.GetComponent<RectTransform>();
		this.parent_rectTransform = this.rectTransform.parent.GetComponent<RectTransform>();
		this.center_puzzle_position = this.parent_rectTransform.localPosition;
		this.puzzle_Manager = puzzle_Manager_v;
		this.this_image = base.GetComponent<Image>();
		this.this_image.alphaHitTestMinimumThreshold = 0.5f;
		this.this_image.enabled = false;
	}

	// Token: 0x06000121 RID: 289 RVA: 0x000076DF File Offset: 0x000058DF
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this.click_enabled)
		{
			Debug.Log("OnMouseEnter()");
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_size_plus());
		}
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00007719 File Offset: 0x00005919
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this.click_enabled)
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_size_normal());
		}
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00007749 File Offset: 0x00005949
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.click_enabled)
		{
			this.click_enabled_on_off(false);
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			base.StartCoroutine(this.IE_move_center_down());
		}
	}

	// Token: 0x06000124 RID: 292 RVA: 0x0000777B File Offset: 0x0000597B
	public void OnPointerMove(PointerEventData eventData)
	{
		if (!this.move_mouse_puzzle && this.click_enabled)
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_size_plus());
		}
	}

	// Token: 0x06000125 RID: 293 RVA: 0x000077B3 File Offset: 0x000059B3
	public void click_enabled_on_off(bool value_v)
	{
		this.click_enabled = value_v;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x000077BC File Offset: 0x000059BC
	private IEnumerator IE_size_plus()
	{
		this.move_mouse_puzzle = true;
		while (this.curve_value < 1f)
		{
			this.curve_value += this.Puzzle_Move_SO.Speed_value_update_size * Time.deltaTime;
			this.rectTransform.localScale = new Vector3(this.Puzzle_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), this.Puzzle_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), 1f);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x000077CB File Offset: 0x000059CB
	private IEnumerator IE_size_normal()
	{
		this.move_mouse_puzzle = false;
		while (this.curve_value > 0f)
		{
			this.curve_value -= this.Puzzle_Move_SO.Speed_value_update_size * Time.deltaTime;
			this.rectTransform.localScale = new Vector3(this.Puzzle_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), this.Puzzle_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), 1f);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x000077DA File Offset: 0x000059DA
	private IEnumerator IE_move_center_down()
	{
		float value_lerp = 1f;
		while (value_lerp > 0f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value_lerp -= this.Puzzle_Move_SO.Speed_card_end * Time.deltaTime;
			this.parent_rectTransform.localPosition = Vector3.Lerp(this.end_position_select, this.center_puzzle_position, this.Puzzle_Move_SO.Curve_move_center_end.Evaluate(value_lerp));
			this.parent_rectTransform.localScale = new Vector3(this.Puzzle_Move_SO.Curve_size_center_end.Evaluate(value_lerp), this.Puzzle_Move_SO.Curve_size_center_end.Evaluate(value_lerp), 1f);
		}
		Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		UnityEvent unityEvent = this.event_puzzle_end;
		if (unityEvent != null)
		{
			unityEvent.Invoke();
		}
		this.puzzle_Manager.Complite_Puzzle_Off();
		yield break;
	}

	// Token: 0x0400012F RID: 303
	[SerializeField]
	private Card_Move_SO Puzzle_Move_SO;

	// Token: 0x04000130 RID: 304
	private RectTransform rectTransform;

	// Token: 0x04000131 RID: 305
	private RectTransform parent_rectTransform;

	// Token: 0x04000132 RID: 306
	private Image this_image;

	// Token: 0x04000133 RID: 307
	private float curve_value;

	// Token: 0x04000134 RID: 308
	private Coroutine coroutine;

	// Token: 0x04000135 RID: 309
	private Puzzle_Manager puzzle_Manager;

	// Token: 0x04000136 RID: 310
	private Vector3 center_puzzle_position;

	// Token: 0x04000137 RID: 311
	[SerializeField]
	private Vector3 end_position_select;

	// Token: 0x04000138 RID: 312
	[SerializeField]
	private UnityEvent event_puzzle_end;

	// Token: 0x04000139 RID: 313
	private bool click_enabled = true;

	// Token: 0x0400013A RID: 314
	private bool move_mouse_puzzle;
}
