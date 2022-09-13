using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class t_BasicAlgo : MonoBehaviour, ITweenBehaviour
{
	enum t_TYPE 
	{
		TRANSLATE,
		ROTATE,
		SCALE
	}

	[SerializeField]
	private t_TYPE tweenType = t_TYPE.TRANSLATE;

	[SerializeField]
	private Vector3 toValue = new Vector3(0,0,0);
	[SerializeField]
	private Vector3 fromValue= new Vector3(-2500,0,0);
	[SerializeField]
	private Vector3 hideValue= new Vector3(2500,0,0);
	[SerializeField]
	private iTween.EaseType easeType = iTween.EaseType.linear;

	[SerializeField]
	private float time = 0.5f;

	public void Show()
	{
		iTween.ValueTo(gameObject,iTween.Hash("from",fromValue,"to",toValue,"time",time, "easetype", easeType,"onUpdate","UpdateToValue", "looptype", iTween.LoopType.none, "oncomplete", "CallBack_Show", "oncompletetarget", this.gameObject));
	}

	public void UpdateToValue(Vector3 newValue)
	{
		

		switch (tweenType) 
		{
			case t_TYPE.TRANSLATE:
				GetComponent<RectTransform> ().localPosition = newValue;
				break;
			case t_TYPE.ROTATE:
				GetComponent<RectTransform> ().localEulerAngles = newValue;
				break;
			case t_TYPE.SCALE:
				GetComponent<RectTransform> ().localScale = newValue;
				break;

		}

	}


	public void Hide()
	{
		iTween.ValueTo(gameObject,iTween.Hash("from",toValue,"to",hideValue,"time",time,"onUpdate","UpdateToValue", "looptype", iTween.LoopType.none, "oncomplete", "CallBack_Hide", "oncompletetarget", this.gameObject));

	}

	public void CallBack_Show()
	{
		if (GetComponent<UIScreen>().isTimeScaleSetZero) 
		{
			Time.timeScale = 0;
		}
	}

	public void CallBack_Hide()
	{
		
		gameObject.SetActive (false);
	}




}


