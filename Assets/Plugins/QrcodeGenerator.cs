using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using ZXing.QrCode;
using ZXing.Datamatrix;
using UnityEngine.UI;

public class QrcodeGenerator : MonoBehaviour
{
    [SerializeField]
    RawImage rawImageReceiver;
    [SerializeField]
    Text _inpuFieldText;

    //public Text cafename;

    public string ash;
   

    Texture2D _storeencodedTexture;

    // Start is called before the first frame update
    void Start()
    {
        _storeencodedTexture = new Texture2D(256, 256); 
    }

    Color32[] Encode(string textForEncoding, int width,int height)
    {
        BarcodeWriter writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions       {
                Height = height,
                Width = width
            }
        };
        return writer.Write(textForEncoding);
    }



    public void OnClickEncode()
    {
        EncodeTextToQrcode();
    }

    void EncodeTextToQrcode()
    {
        _inpuFieldText.text = ash;
        Debug.Log(_inpuFieldText);
        string textWrite = string.IsNullOrEmpty(_inpuFieldText.text) ? "some text" : _inpuFieldText.text;
        Color32[] _convertPixelToTexture = Encode(textWrite, _storeencodedTexture.width, _storeencodedTexture.height);
        _storeencodedTexture.SetPixels32(_convertPixelToTexture);
        _storeencodedTexture.Apply();

        rawImageReceiver.texture = _storeencodedTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
