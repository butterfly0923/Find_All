using System;

// Token: 0x02000060 RID: 96
public class Time_converter
{
	// Token: 0x0600026D RID: 621 RVA: 0x0000CE24 File Offset: 0x0000B024
	public static string FormatMinuts(float elapsed)
	{
		int num = (int)(elapsed * 100f) / 6000;
		return string.Format("{0:00}", num);
	}

	// Token: 0x0600026E RID: 622 RVA: 0x0000CE50 File Offset: 0x0000B050
	public static string FormatMinuts_do_10(float elapsed)
	{
		int num = (int)(elapsed * 100f) / 6000;
		return string.Format("{0:0}", num);
	}

	// Token: 0x0600026F RID: 623 RVA: 0x0000CE7C File Offset: 0x0000B07C
	public static string FormatSeconds(float elapsed)
	{
		int num = (int)(elapsed * 100f) % 6000 / 100;
		return string.Format("{0:00}", num);
	}
}
