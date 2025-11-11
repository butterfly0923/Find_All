using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

// Token: 0x02000011 RID: 17
public class Color_Recept_All : MonoBehaviour
{
	// Token: 0x0600004A RID: 74 RVA: 0x00002E94 File Offset: 0x00001094
	private void Awake()
	{
		this.key_1 = Sa_IS.input_Main.Main.Key_1;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00002EB9 File Offset: 0x000010B9
	private void OnEnable()
	{
		this.key_1.started += this.key_1_t;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00002ED2 File Offset: 0x000010D2
	private void OnDisable()
	{
		this.key_1.started -= this.key_1_t;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002EEB File Offset: 0x000010EB
	private void key_1_t(InputAction.CallbackContext cc)
	{
		Debug.Log("Кнопка 1 нажимается");
		base.StartCoroutine(this.IE_alpha_plus());
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002F04 File Offset: 0x00001104
	private IEnumerator IE_alpha_plus()
	{
		float value = 0f;
		while (value < 1f)
		{
			yield return new WaitForSeconds(Time.deltaTime);
			value += this.speed_value * Time.deltaTime;
			this.image_full_recept.color = new Color(1f, 1f, 1f, this.animationCurve_alpha.Evaluate(value));
		}
		yield break;
	}

	// Token: 0x04000058 RID: 88
	private InputAction key_1;

	// Token: 0x04000059 RID: 89
	[SerializeField]
	private AnimationCurve animationCurve_alpha;

	// Token: 0x0400005A RID: 90
	[SerializeField]
	private Image image_full_recept;

	// Token: 0x0400005B RID: 91
	[SerializeField]
	private float speed_value;
}
