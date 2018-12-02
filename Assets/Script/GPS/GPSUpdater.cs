using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSUpdater : MonoBehaviour {

    public float IntervalSeconds = 1.0f;
    public LocationServiceStatus Status;
    public LocationInfo Location;
    private bool gIsDialog = false;

    /// =======================================================================
    /// 起動スクリプト
    /// =======================================================================
    IEnumerator Start()
    {
        // 使う前に setlabel を呼んどく。
        DialogManager.Instance.SetLabel("OK", "No", "Close");

        while (true)
        {
            this.Status = Input.location.status;

            if (Input.location.isEnabledByUser)
            {
                switch (this.Status)
                {
                    case LocationServiceStatus.Stopped:
                        Input.location.Start();
                        break;

                    case LocationServiceStatus.Running:
                        this.Location = Input.location.lastData;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                // 位置情報を有効にするようにユーザーへ要求
                ShowDialog_gps();
                gIsDialog = true;
            }

            // 指定した秒数後に再度判定を走らせる
            yield return new WaitForSeconds(IntervalSeconds);
        }
    }


    private void ShowDialog_gps()
    {
        if( gIsDialog)
        {
            return;
        }

        // YES NO ダイアログ
        DialogManager.Instance.ShowSelectDialog(
           "設定からGPSの使用を許可してください。",
            (bool result) =>
            {
                gIsDialog = false;
                Application.Quit();
            });
    }

}
