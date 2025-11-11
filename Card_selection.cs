using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x0200009B RID: 155
public class Card_selection : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
{
	// Token: 0x0600041F RID: 1055 RVA: 0x000141C7 File Offset: 0x000123C7
	public void Awake_setting(Card_Move_SO card_Move_SO_v, Card_mover card_Mover_v)
	{
		this.card_Move_SO = card_Move_SO_v;
		this.card_Mover = card_Mover_v;
		this.rectTransform = base.GetComponent<RectTransform>();
		base.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x000141F3 File Offset: 0x000123F3
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnMouseEnter()");
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_size_plus());
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x00014225 File Offset: 0x00012425
	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnMouseExit()");
		if (this.coroutine != null)
		{
			base.StopCoroutine(this.coroutine);
		}
		this.coroutine = base.StartCoroutine(this.IE_size_normal());
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x00014258 File Offset: 0x00012458
	public void OnPointerClick(PointerEventData eventData)
	{
		if (this.click_enabled)
		{
			this.card_Mover.select_this_card();
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.coroutine = base.StartCoroutine(this.IE_size_normal());
			Sa_IS.Active_Input_map(Sa_IS.input_Main.am_play, true);
		}
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x000142B3 File Offset: 0x000124B3
	public void click_enabled_on_off(bool value_v)
	{
		this.click_enabled = value_v;
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x000142BC File Offset: 0x000124BC
	private IEnumerator IE_size_plus()
	{
		while (this.curve_value < 1f)
		{
			this.curve_value += this.card_Move_SO.Speed_value_update_size * Time.deltaTime;
			this.rectTransform.localScale = new Vector3(this.card_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), this.card_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), 1f);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x000142CB File Offset: 0x000124CB
	private IEnumerator IE_size_normal()
	{
		while (this.curve_value > 0f)
		{
			this.curve_value -= this.card_Move_SO.Speed_value_update_size * Time.deltaTime;
			this.rectTransform.localScale = new Vector3(this.card_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), this.card_Move_SO.Scale_multiply_curve.Evaluate(this.curve_value), 1f);
			yield return new WaitForSeconds(Time.deltaTime);
		}
		yield break;
	}

	// Token: 0x04000476 RID: 1142
	private Card_mover card_Mover;

	// Token: 0x04000477 RID: 1143
	private Card_Move_SO card_Move_SO;

	// Token: 0x04000478 RID: 1144
	private RectTransform rectTransform;

	// Token: 0x04000479 RID: 1145
	private float curve_value;

	// Token: 0x0400047A RID: 1146
	private Coroutine coroutine;

	// Token: 0x0400047B RID: 1147
	private bool click_enabled;
}
