using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x02000015 RID: 21
public class Image_move : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
	// Token: 0x0600005D RID: 93 RVA: 0x000030F0 File Offset: 0x000012F0
	private void Awake()
	{
		this.this_transform = base.GetComponent<RectTransform>();
		this.finish_position = this.this_transform.localPosition;
		this.scrolling = Sa_IS.input_Main.Main.Scrolling;
		this.main_image = base.GetComponent<Image>();
		Transform child = base.transform.GetChild(0);
		this.color_image = ((child != null) ? child.transform.GetComponent<Image>() : null);
		this.color_image.color = new Color(1f, 1f, 1f, 0f);
		this.color_image.raycastTarget = false;
		this.main_image.alphaHitTestMinimumThreshold = 0.5f;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x000031A1 File Offset: 0x000013A1
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("OnMouseEnter()");
	}

	// Token: 0x0600005F RID: 95 RVA: 0x000031AD File Offset: 0x000013AD
	public void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("OnMouseExit()");
	}

	// Token: 0x06000060 RID: 96 RVA: 0x000031BC File Offset: 0x000013BC
	public void OnPointerDown(PointerEventData eventData)
	{
		if (!this.mover)
		{
			if (!this.finish)
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
				return;
			}
		}
		else if (!this.finish)
		{
			if (this.coroutine != null)
			{
				base.StopCoroutine(this.coroutine);
			}
			this.mover = false;
			this.Test_Finish_position();
		}
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00003269 File Offset: 0x00001469
	public void OnPointerUp(PointerEventData eventData)
	{
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000326B File Offset: 0x0000146B
	private IEnumerator IE_Move_and_Rotation()
	{
		float screen_multiply = 1080f / (float)Screen.height;
		Debug.Log(string.Format("Мультиплай - {0}", screen_multiply));
		while (this.mover)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			Vector2 vector = Mouse.current.scroll.ReadValue();
			Vector2 a = Mouse.current.position.ReadValue();
			this.Z_rotate += vector.y / 24f;
			this.this_transform.localPosition = this.position_this - this.curcor_position_down * (this.Multiply_position * screen_multiply) + a * (this.Multiply_position * screen_multiply);
			this.this_transform.localRotation = Quaternion.Euler(0f, 0f, this.Z_rotate);
		}
		yield break;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000327C File Offset: 0x0000147C
	private void Test_Finish_position()
	{
		Debug.Log(string.Format("Угол поворота - {0}", this.this_transform.localRotation.eulerAngles.z));
		if (Vector3.Distance(this.finish_position, this.this_transform.localPosition) < 100f && (this.this_transform.localRotation.eulerAngles.z < 18f || this.this_transform.localRotation.eulerAngles.z > 342f))
		{
			Debug.Log("ДЕТАЛЬ НА МЕСТО");
			this.finish = true;
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

	// Token: 0x06000064 RID: 100 RVA: 0x00003495 File Offset: 0x00001695
	private IEnumerator IE_finish_detal_position()
	{
		base.StartCoroutine(this.IE_finish_color());
		float value = 0f;
		float Z_finish = (float)((this.this_transform.localRotation.eulerAngles.z < 180f) ? 0 : 360);
		Vector3 finish_start_position = this.this_transform.localPosition;
		float Z_finish_start_angle = this.this_transform.localRotation.eulerAngles.z;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_finish;
			this.this_transform.localPosition = Vector3.Lerp(finish_start_position, this.finish_position, value);
			this.this_transform.localRotation = Quaternion.Euler(0f, 0f, Mathf.Lerp(Z_finish_start_angle, Z_finish, value));
		}
		yield break;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x000034A4 File Offset: 0x000016A4
	private IEnumerator IE_finish_color()
	{
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_color;
			this.color_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, value));
		}
		value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += Time.deltaTime * this.speed_color;
			this.main_image.color = new Color(1f, 1f, 1f, Mathf.Lerp(1f, 0f, value));
		}
		yield break;
	}

	// Token: 0x0400006E RID: 110
	private Image main_image;

	// Token: 0x0400006F RID: 111
	private Image color_image;

	// Token: 0x04000070 RID: 112
	[SerializeField]
	private RectTransform this_transform;

	// Token: 0x04000071 RID: 113
	[SerializeField]
	private Vector2 position_this;

	// Token: 0x04000072 RID: 114
	[SerializeField]
	private Vector2 curcor_position_down;

	// Token: 0x04000073 RID: 115
	[SerializeField]
	private bool mover;

	// Token: 0x04000074 RID: 116
	[SerializeField]
	private bool finish;

	// Token: 0x04000075 RID: 117
	[SerializeField]
	private InputAction scrolling;

	// Token: 0x04000076 RID: 118
	[SerializeField]
	private float Z_rotate;

	// Token: 0x04000077 RID: 119
	[SerializeField]
	private Vector3 finish_position;

	// Token: 0x04000078 RID: 120
	[SerializeField]
	private float speed_finish;

	// Token: 0x04000079 RID: 121
	[SerializeField]
	private float speed_color;

	// Token: 0x0400007A RID: 122
	[SerializeField]
	private float Multiply_position = 2.86f;

	// Token: 0x0400007B RID: 123
	[SerializeField]
	private float Multiply_max_y = 1450f;

	// Token: 0x0400007C RID: 124
	private Coroutine coroutine;
}
