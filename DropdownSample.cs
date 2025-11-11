using System;
using TMPro;
using UnityEngine;

// Token: 0x020000BB RID: 187
public class DropdownSample : MonoBehaviour
{
	// Token: 0x0600052E RID: 1326 RVA: 0x00018A6C File Offset: 0x00016C6C
	public void OnButtonClick()
	{
		this.text.text = ((this.dropdownWithPlaceholder.value > -1) ? ("Selected values:\n" + this.dropdownWithoutPlaceholder.value.ToString() + " - " + this.dropdownWithPlaceholder.value.ToString()) : "Error: Please make a selection");
	}

	// Token: 0x04000582 RID: 1410
	[SerializeField]
	private TextMeshProUGUI text;

	// Token: 0x04000583 RID: 1411
	[SerializeField]
	private TMP_Dropdown dropdownWithoutPlaceholder;

	// Token: 0x04000584 RID: 1412
	[SerializeField]
	private TMP_Dropdown dropdownWithPlaceholder;
}
