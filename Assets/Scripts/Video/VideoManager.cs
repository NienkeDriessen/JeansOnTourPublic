using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    VideoPlayer VideoPlayer;
    GameObject Video;
    private void Awake()
    {
        GameObject VideoPlayerObject = GameObject.Find("VideoPlayer");
        VideoPlayer = VideoPlayerObject.GetComponent<VideoPlayer>();
        Video = GameObject.Find("Video");
        VideoPlayer.Pause();
    }

    public void PlayVideo()
    {
        StartCoroutine(ScaleVideo(0.3f));
        VideoPlayer.Play();
    }


    private IEnumerator ScaleVideo(float duration)
    {
        RectTransform rt = Video.GetComponent<RectTransform>();
        Vector3 startScale = rt.localScale;
        Vector3 targetScale = new Vector3(1, 1, 1);
        var elapsed = 0f;

        while (elapsed < duration)
        {
            var t = elapsed / duration;
            rt.localScale = Vector3.Lerp(startScale, targetScale, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        rt.localScale = targetScale;
    }
}
