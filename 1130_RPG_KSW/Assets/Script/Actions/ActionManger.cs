using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManger : MonoBehaviour
{

    IEnd _curr = null;

    public void StartAction(IEnd action)
    {
        if (_curr == action) return;     // 액션중이면 바로 반환

        if (_curr != null)               // 값이있으면 공격 종료 
        {

            _curr.End();
        }

        _curr = action;
    }

    public void StopAction()
    {
        if (_curr != null)
        {
            _curr.End();
        }

        _curr = null;

    }

}
