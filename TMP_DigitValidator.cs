using System;

namespace TMPro
{
	// Token: 0x020000BD RID: 189
	[Serializable]
	public class TMP_DigitValidator : TMP_InputValidator
	{
		// Token: 0x06000533 RID: 1331 RVA: 0x00018B0C File Offset: 0x00016D0C
		public override char Validate(ref string text, ref int pos, char ch)
		{
			if (ch >= '0' && ch <= '9')
			{
				text += ch.ToString();
				pos++;
				return ch;
			}
			return '\0';
		}
	}
}
