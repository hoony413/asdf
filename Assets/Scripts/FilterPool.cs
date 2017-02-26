using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityStandardAssets.ImageEffects;

public class FilterPool : MonoBehaviour
{
    public enum eFilter
    {
        BloomOptimized,
        BlurOptimized,
        ColorCorrectionCurves,
        ContrastEnhance,
        CreaseShading,
        DepthOfField,
        EdgeDetection,
        Fisheye,
        Grayscale,
        SepiaTone,
        TiltShift,
        Tonemapping,
        VignetteAndChromaticAberration,
        MAX
    }

    private UnityStandardAssets.ImageEffects.BloomOptimized bloomObtimized;
    private UnityStandardAssets.ImageEffects.BlurOptimized blurOptimized;
    private UnityStandardAssets.ImageEffects.ColorCorrectionCurves colorCorrectionCurves;
    private UnityStandardAssets.ImageEffects.ContrastEnhance contrastEnhance;
    private UnityStandardAssets.ImageEffects.CreaseShading creaseShading;
    private UnityStandardAssets.ImageEffects.DepthOfField depthOfField;
    private UnityStandardAssets.ImageEffects.EdgeDetection edgeDetection;
    private UnityStandardAssets.ImageEffects.Fisheye fishEye;
    private UnityStandardAssets.ImageEffects.Grayscale grayScale;
    private UnityStandardAssets.ImageEffects.SepiaTone sepiaTone;
    private UnityStandardAssets.ImageEffects.TiltShift tiltShift;
    private UnityStandardAssets.ImageEffects.Tonemapping toneMapping;
    private UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration vignetteAndChromaticAberration;

    public void SetUp()
    {
        bloomObtimized = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.BloomOptimized>();
        blurOptimized = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>();
        colorCorrectionCurves = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>();
        contrastEnhance = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.ContrastEnhance>();
        creaseShading = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.CreaseShading>();
        depthOfField = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.DepthOfField>();
        edgeDetection = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.EdgeDetection>();
        fishEye = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.Fisheye>();
        grayScale = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.Grayscale>();
        sepiaTone = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.SepiaTone>();
        tiltShift = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.TiltShift>();
        toneMapping = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.Tonemapping>();
        vignetteAndChromaticAberration = CameraController.instance.GetComponent<UnityStandardAssets.ImageEffects.VignetteAndChromaticAberration>();

        CameraController.instance.DicFilter.Add(eFilter.BloomOptimized, bloomObtimized);
        CameraController.instance.DicFilter.Add(eFilter.BlurOptimized, blurOptimized);
        CameraController.instance.DicFilter.Add(eFilter.ColorCorrectionCurves, colorCorrectionCurves);
        CameraController.instance.DicFilter.Add(eFilter.ContrastEnhance, contrastEnhance);
        CameraController.instance.DicFilter.Add(eFilter.CreaseShading, creaseShading);
        CameraController.instance.DicFilter.Add(eFilter.DepthOfField, depthOfField);
        CameraController.instance.DicFilter.Add(eFilter.EdgeDetection, edgeDetection);
        CameraController.instance.DicFilter.Add(eFilter.Fisheye, fishEye);
        CameraController.instance.DicFilter.Add(eFilter.Grayscale, grayScale);
        CameraController.instance.DicFilter.Add(eFilter.SepiaTone, sepiaTone);
        CameraController.instance.DicFilter.Add(eFilter.TiltShift, tiltShift);
        CameraController.instance.DicFilter.Add(eFilter.Tonemapping, toneMapping);
        CameraController.instance.DicFilter.Add(eFilter.VignetteAndChromaticAberration, vignetteAndChromaticAberration);
    }

}