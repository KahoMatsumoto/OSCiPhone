using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OSCController : MonoBehaviour
{
	void Start()
	{
		OSCHandler.Instance.Init();

	}

	// Update is called once per frame
	void Update()
	{
        ListenToOSC();
		
	}




	void ListenToOSC()
	{
        int x = 0;
		OSCHandler.Instance.UpdateLogs();
		Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
		servers = OSCHandler.Instance.Servers;

		foreach (KeyValuePair<string, ServerLog> item in servers)
		{
			Debug.Log(item.Value.log.Count);
			if (item.Value.log.Count > 0)
			{
				Debug.Log("count is more than zero");
				int lastPacketIndex = item.Value.packets.Count - 1;

				string s = item.Value.packets[lastPacketIndex].Data[0].ToString();
				if (item.Value.packets[lastPacketIndex].Address == "/change")
				{
                    changeColor(int.Parse(s));
					Debug.Log("change color");
				}
			}
		}
		OSCHandler.Instance.UpdateLogs();
	}
    void changeColor(int x){
        float changeRed = 0.0f;
        float changeGreen = 0.0f;
        float cahngeBlue = 0.0f;
        float cahngeAlpha = 1.0f;
        if (x == 0) changeRed = 1.0f;
        if (x == 1) changeGreen = 1.0f;
		this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, cahngeBlue, cahngeAlpha);

	}
}