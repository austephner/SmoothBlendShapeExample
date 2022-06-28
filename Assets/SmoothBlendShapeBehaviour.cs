using System.Collections.Generic;
using UnityEngine;

public class SmoothBlendShapeBehaviour : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _smr;

    [SerializeField] private float _blendShapeTransitionSpeed = 3.0f;
    
    private List<float> _targetWeights = new List<float>();

    private void Start() 
    {
        for (int i = 0; i < _smr.sharedMesh.blendShapeCount; i++) 
        {
            _targetWeights.Add(_smr.GetBlendShapeWeight(i));
        }
    }

    private void Update() 
    {
        for (int i = 0; i < _targetWeights.Count; i++) 
        {
            // you could use Lerp here instead of MoveTowards if you want
    
            _smr.SetBlendShapeWeight(
                i, 
                Mathf.MoveTowards(
                    _smr.GetBlendShapeWeight(i),
                    _targetWeights[i],
                    Time.deltaTime * _blendShapeTransitionSpeed));
        }
    }

    public void SetBlendShapeWeight(string blendShapeName, float value) 
    {
        SetBlendShapeWeight(
            _smr.sharedMesh.GetBlendShapeIndex(blendShapeName), 
            value);
    }

    public void SetBlendShapeWeight(int blendShapeIndex, float value) 
    {
        _targetWeights[blendShapeIndex] = value;
    }
}