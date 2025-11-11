using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class Storage
{
	// Token: 0x060004D6 RID: 1238 RVA: 0x00017352 File Offset: 0x00015552
	public Storage()
	{
		this.file_path = Application.dataPath + "/Data_SL/";
		this.InitBinaryFormatter();
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x00017378 File Offset: 0x00015578
	private void InitBinaryFormatter()
	{
		this.formatter = new BinaryFormatter();
		SurrogateSelector surrogateSelector = new SurrogateSelector();
		Vector3SerializationSurrogate surrogate = new Vector3SerializationSurrogate();
		QuaternionSerializationSurrogate surrogate2 = new QuaternionSerializationSurrogate();
		surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), surrogate);
		surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), surrogate2);
		this.formatter.SurrogateSelector = surrogateSelector;
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x000173E4 File Offset: 0x000155E4
	public object Load(object load_file_value)
	{
		if (!File.Exists(this.file_path + load_file_value.ToString()))
		{
			if (load_file_value != null)
			{
				this.Save(load_file_value);
			}
			return load_file_value;
		}
		FileStream fileStream = File.Open(this.file_path + load_file_value.ToString(), FileMode.Open);
		object result = this.formatter.Deserialize(fileStream);
		Debug.Log(((load_file_value != null) ? load_file_value.ToString() : null) + "LOAD");
		fileStream.Close();
		return result;
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x0001745C File Offset: 0x0001565C
	public void Save(object save_file_value)
	{
		if (!Directory.Exists(this.file_path))
		{
			Directory.CreateDirectory(this.file_path);
		}
		FileStream fileStream = File.Create(this.file_path + save_file_value.ToString());
		this.formatter.Serialize(fileStream, save_file_value);
		fileStream.Close();
		Debug.Log(((save_file_value != null) ? save_file_value.ToString() : null) + "SAVE");
	}

	// Token: 0x04000535 RID: 1333
	private string file_path;

	// Token: 0x04000536 RID: 1334
	private BinaryFormatter formatter;
}
