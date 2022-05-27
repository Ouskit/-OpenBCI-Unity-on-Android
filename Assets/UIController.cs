using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    private GanglionController _ganglionController;
    public Image[] impedanceIcon;
    public Text[] impedanceValues;
    public Text[] eegValues;
    public Image ConnectStatus;
    void Start()
    {
        _ganglionController = GameObject.Find("GanglionController").GetComponent<GanglionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_ganglionController.connectionStatus)
            ConnectStatus.color = Color.green;
        else
            ConnectStatus.color = Color.red;
        
        for (int i = 0; i < eegValues.Length; i++)
        {
            eegValues[i].text = _ganglionController.GetEegData(i).ToString();
        }
        
        for (int i = 0; i < impedanceIcon.Length; i++)
        {
            impedanceValues[i].text = _ganglionController.GetImpedanceData(i).ToString();
            if (_ganglionController.GetImpedanceData(i) > 30)
            {
                impedanceIcon[i].color = Color.red;
            }
            else
            {
                impedanceIcon[i].color = Color.green;
            }
        }
    }
}
