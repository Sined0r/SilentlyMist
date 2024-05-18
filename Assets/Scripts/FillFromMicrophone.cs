using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class FillFromMicrophone : MonoBehaviour
{
    public Image audioBar;
    public Slider sensitivitySlider;
    public AudioLoudnessDetector detector;

    public float minimumSensibility = 20;
    public float maximumSensibility = 500;
    public float currentloudnessSensibility = 100f;
    public float threshold = 0.1f;

    public GameObject screamText;

    public static UnityAction OnScreamDetected;

    private void Start()
    {
        if (sensitivitySlider == null) return;

        sensitivitySlider.value = .7f;
        SetLoudnessSensibility(sensitivitySlider.value);
    }

    private void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * currentloudnessSensibility;
        if (loudness < threshold) loudness = 0.01f;

        audioBar.fillAmount = loudness;

        if (loudness > .7f) OnScreamDetected?.Invoke();

        if (loudness > .7f && !screamText.activeInHierarchy) screamText.SetActive(true);
        if (loudness <= .7f && screamText.activeInHierarchy) screamText.SetActive(false);
    }

    public void SetLoudnessSensibility(float t)
    {
        currentloudnessSensibility = Mathf.Lerp(minimumSensibility, maximumSensibility, t);
    }
}
