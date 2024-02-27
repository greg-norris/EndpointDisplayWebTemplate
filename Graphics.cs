using GHIElectronics.Endpoint.Core;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Device.Gpio.Drivers;
using System.Device.Gpio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;

namespace EndpointDisplayWebTemplate
{
    public class Graphics
    {
        SKBitmap bitmap;
        SKBitmap bitmapBackground;
        SKCanvas canvas;

        public Graphics()
        {
            bitmap = new SKBitmap(480, 272, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

            var img = Resources.background;
            var info = new SKImageInfo(480, 272); // width and height of rect
            bitmapBackground = SKBitmap.Decode(img, info);

            canvas = new SKCanvas(bitmap);

            Display.Initialize();
        }
        public void Flush()
        {
            var data = bitmap.Copy(SKColorType.Rgb565).Bytes;
            Display.Flush(data, 0, data.Length);
        }

    }
}
