using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

	Vector3 pos;
	int cnt = 0;
	int flag = 0;
	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		pos.y = Time.deltaTime;

		if(pos.y <= 2.35)
		{
			
			if(cnt > 60)
			{
				flag = 1;
			
			}

			if(cnt < 0)
			{
				flag = 0;
			}

			if(flag == 0)
			{
				pos.x += 3 * 0.94f;
				cnt++;
			}
			if(flag == 1)
			{
				pos.x -= 3 * 0.94f;
				cnt--;
			}

		}

			transform.position = pos;
	}
}
