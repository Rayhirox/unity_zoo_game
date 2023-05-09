using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 挂载在信息UI上
public class AnimalInfo : MonoBehaviour
{
    public Text infoText;
    public WindowControl Interaction;
    public MouseLook Camera;
    public bool enable;

    //保存动物
    private GameObject _animal;
    void Start()
    {
        enable = true;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(_animal.TryGetComponent<Light>(out Light light))
            {
                light.enabled = !light.enabled;
            }
            else if(_animal.TryGetComponent<ParticleSystem>(out ParticleSystem ps))
            {
                foreach(Transform child in ps.transform)
                {
                    child.gameObject.SetActive(!child.gameObject.activeSelf);
                }
            }
            else MyDisable();
        }

    }

    // 开启信息显示
    public void MyEnable()
    {
        enable = true;
        Camera.LockCursor();
    }

    //打开交互界面 关闭信息显示
    public void MyDisable()
    {
        enable = false;
        Camera.UnLockCursor();
        Interaction.Activate();
    }

    //显示物体信息
    public void Activate(GameObject info)
    {
        if (!enable) return;
        if (info.TryGetComponent(out GroundDetection gd))
            infoText.text = info.name + ColoredText(gd.Hungriness);
        else infoText.text = info.name;
        _animal = info;
        gameObject.SetActive(true);
    }

    //关闭信息
    public void Inactivate()
    {
        gameObject.SetActive(false);
    }

    //按钮事件
    //改变动画
    public void ChangeState(int state)
    {
        if(_animal == null)
        {
            Debug.LogError("Animal Object is null");
            return;
        }
        if(state == 1)
        {
            _animal.GetComponent<GroundDetection>().Hungriness += 10;
        }
        _animal.GetComponent<Animator>().SetInteger("Behavior", state);
    }

    //改变外观
    public void ChangeAppearance()
    {
        Debug.Log(_animal.transform.name);
        GameObject magic = FindChild(_animal.transform, "Magic");
        magic.SetActive(!magic.activeSelf);
    }

    //面朝自己
    public void TurnToCamera()
    {
        _animal.transform.DOLookAt(Camera.transform.position, 1f, AxisConstraint.Y);

    }

    //饥饿度字体颜色
    private string ColoredText(int h)
    {
        if(h >= 70)
        {
            return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(Color.green), "  饥饿度：" + h.ToString());
        }
        else if(h >= 40)
        {
            return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(Color.yellow), "  饥饿度：" + h.ToString());
        }
        else
        {
            return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGBA(Color.red), "  饥饿度：" + h.ToString());
        }
    }

    //找子物体
    private GameObject FindChild(Transform parent, string target)
    {
        if (parent == null) return null;
        foreach(Transform child in parent)
        {
            if (child.name == target) return child.gameObject;
            GameObject ret = FindChild(child, target);
            if(ret != null) return ret;
        }
        return null;
    }
}
