using HK.UserInterface.Enums;
using UnityEngine;
using UnityEngine.Assertions;

namespace HK.UserInterface
{
    /// <summary>
    /// <see cref="Enums"/>の拡張クラス
    /// </summary>
    public static partial class Extensions
    {
        public static Color ToColor(this ColorType type)
        {
            switch (type)
            {
                case ColorType.LightGreenishBlue:
                    return new Color(0.33f, 0.94f, 0.77f);
                case ColorType.FadeoPoster:
                    return new Color(0.51f, 0.93f, 0.93f);
                case ColorType.GreenDarnerTail:
                    return new Color(0.45f, 0.73f, 1f);
                case ColorType.ShyMoment:
                    return new Color(0.64f, 0.61f, 1f);
                case ColorType.MintLeaf:
                    return new Color(0f, 0.72f, 0.58f);
                case ColorType.RobinsEggBlue:
                    return new Color(0f, 0.81f, 0.79f);
                case ColorType.ElectronBlue:
                    return new Color(0.04f, 0.52f, 0.89f);
                case ColorType.ExodusFruit:
                    return new Color(0.42f, 0.36f, 0.91f);
                case ColorType.SourLemon:
                    return new Color(1f, 0.92f, 0.65f);
                case ColorType.FirstDate:
                    return new Color(0.98f, 0.69f, 0.63f);
                case ColorType.PinkGlamour:
                    return new Color(1f, 0.46f, 0.46f);
                case ColorType.Pico8Pink:
                    return new Color(0.99f, 0.47f, 0.66f);
                case ColorType.BrightYarrow:
                    return new Color(0.99f, 0.8f, 0.43f);
                case ColorType.OrangeVille:
                    return new Color(0.88f, 0.44f, 0.33f);
                case ColorType.ChiGong:
                    return new Color(0.84f, 0.19f, 0.19f);
                case ColorType.PrunusAvium:
                    return new Color(0.91f, 0.26f, 0.58f);
                case ColorType.CityLight:
                    return new Color(0.87f, 0.9f, 0.91f);
                case ColorType.SoothingBreeze:
                    return new Color(0.7f, 0.75f, 0.76f);
                case ColorType.AmericanRiver:
                    return new Color(0.39f, 0.43f, 0.45f);
                case ColorType.DraculaOrchid:
                    return new Color(0.18f, 0.2f, 0.21f);
                default:
                    Assert.IsTrue(false, string.Format("未対応の値です {0}", type));
                    return Color.black;
            }
        }
    }
}
