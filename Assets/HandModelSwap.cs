using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandModelSwap : MonoBehaviour
{
    public XRDirectInteractor leftHandInteractor;   // 左手的XRDirectInteractor
    public XRDirectInteractor rightHandInteractor;  // 右手的XRDirectInteractor
    public GameObject newLeftHandModel;             // 新的左手模型
    public GameObject newRightHandModel;            // 新的右手模型

    private GameObject originalLeftHandModel;       // 原始左手模型
    private GameObject originalRightHandModel;      // 原始右手模型

    void Start()
    {
        // 保存原始手模型引用
        if (leftHandInteractor && leftHandInteractor.transform.childCount > 0)
        {
            originalLeftHandModel = leftHandInteractor.transform.GetChild(0).gameObject;
        }
        if (rightHandInteractor && rightHandInteractor.transform.childCount > 0)
        {
            originalRightHandModel = rightHandInteractor.transform.GetChild(0).gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InteractableObject")) // 确保互动物体有适当的标签
        {
            SwapHandModel(other, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractableObject"))
        {
            SwapHandModel(other, false);
        }
    }

    void SwapHandModel(Collider handCollider, bool isSwap)
    {
        // 确保手的Collider与手的Interactor关联
        XRDirectInteractor interactor = handCollider.GetComponentInParent<XRDirectInteractor>();
        if (interactor == null) return;

        if (interactor == leftHandInteractor)
        {
            ToggleHandModel(isSwap, originalLeftHandModel, newLeftHandModel);
        }
        else if (interactor == rightHandInteractor)
        {
            ToggleHandModel(isSwap, originalRightHandModel, newRightHandModel);
        }
    }

    void ToggleHandModel(bool isSwap, GameObject originalHand, GameObject newHand)
    {
        if (originalHand == null || newHand == null) return;

        originalHand.SetActive(!isSwap);
        newHand.SetActive(isSwap);
    }
}
