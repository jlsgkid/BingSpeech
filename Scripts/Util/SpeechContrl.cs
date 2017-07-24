using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechContrl : MonoBehaviour {

	[SerializeField] private Spider spider;
	[SerializeField] private GameObject fire_ps;
	[SerializeField] private bool isEyeIn = false;
	private string rtnStr = "defalut";
	[SerializeField] private Text text;
	[SerializeField] private GameObject StartFog;
    private ParticleSystem magicDua;
	AndroidJavaObject plugin = null;
	private bool isCanSpeech = true;
	[SerializeField] private LightTransform lightTrans;
	private int flg = 0;

	void Start(){
		magicDua = StartFog.GetComponent<ParticleSystem> ();
		#if UNITY_ANDROID && !UNITY_EDITOR
		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject currentUnityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity"); 
		plugin = new AndroidJavaObject("com.microsoft.CognitiveServicesExample.MainActivity");
		#endif
	}

	// Update is called once per frame
	void Update () {
		if("フラッシュ".Equals(rtnStr)){
			fire_ps.SetActive (true);
			if(spider != null && isEyeIn==true){
				spider.GetDamage (50);
			}
			rtnStr = "";
			StartCoroutine (UtilTool.SetObjUnEnaleAfterTime(StartFog, 4.0f));
			StartCoroutine (UtilTool.SetObjUnEnaleAfterTime(fire_ps, 3.0f));
		}else if("光".Equals(rtnStr)||"光り".Equals(rtnStr)||"ひかり".Equals(rtnStr) ){
			lightTrans.StartBlink ();
			rtnStr = "";
			//StartCoroutine (UtilTool.SetObjUnEnaleAfterTime(StartFog, 4.0f));
		}
		else if(!"声を入力してください".Equals(rtnStr) && flg == 1){
		//else if("".Equals(rtnStr)){
			isCanSpeech = true;
		}
		//test
		#if UNITY_EDITOR
		if(Input.GetKeyDown(KeyCode.X)){
			rtnStr = "光";
			StartFog.SetActive (true);
			if(!magicDua.isPlaying){
				magicDua.Play ();
			}
		}
		#endif

		#if UNITY_ANDROID && !UNITY_EDITOR
		if(GvrController.ClickButtonDown == true){
			if(isCanSpeech){
				rtnStr = "声を入力してください";
				text.text = "声を入力してください";
			    isCanSpeech = false;
				startRecognition();
			}
		}
		#endif
//		if(isEyeIn){
//		}
	}

	public void SpeechBegin(){
		isEyeIn = true;
	}

	public void startRecognition(){
		Invoke ("ChangeText", 3);
		plugin.Call("StartButton_Click");
	}
	public void ShowResult(string resultText){
		flg = 1;
		rtnStr = resultText;
		text.text = rtnStr;
	}

	private void ChangeText(){
		text.text = "認識中...";
		rtnStr = "認識中...";
		StartFog.SetActive (true);
		if(!magicDua.isPlaying){
			magicDua.Play ();
		}
	}
}
