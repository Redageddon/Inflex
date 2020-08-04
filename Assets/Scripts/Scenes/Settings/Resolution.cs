using UnityEngine;

namespace Scenes.Settings
{
    public class Resolution
    {
        public Resolution()
        {
        }

        public Resolution(int height, int width, int refreshRate)
        {
            this.Height      = height;
            this.Width       = width;
            this.RefreshRate = refreshRate;
        }

        public float Corner => Mathf.Sqrt(this.Width * this.Width + this.Height * this.Height) / 2;

        public          int    Width       { get; set; }
        public          int    Height      { get; set; }
        public          int    RefreshRate { get; set; }
        public override string ToString()  => $"{this.Width} x {this.Height} @ {this.RefreshRate}Hz";
    }
}