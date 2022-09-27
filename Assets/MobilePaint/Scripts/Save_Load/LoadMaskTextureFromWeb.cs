using UnityEngine;
using System.Collections;
using unitycoder_MobilePaint;
using UnityEngine.Networking;
using UnityEditor;

namespace unitycoder_MobilePaint_samples
	{

	public class LoadTextureFromWeb : MonoBehaviour 
	{
		public string url = "";
		
		IEnumerator Start() {
			MobilePaint mobilePaint = PaintManager.mobilePaint;

			// Start b download of the given URL
			using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
			{
                // Wait for download to complete
                yield return request.SendWebRequest();

                if (request.isHttpError || request.isNetworkError)
                {
                    Debug.Log(request.error);
                }
                else
                {
                    // assign texture, NOTE
                    Texture2D image = DownloadHandlerTexture.GetContent(request);
                    mobilePaint.maskTex = image;
                }
            }
		}
	}
}