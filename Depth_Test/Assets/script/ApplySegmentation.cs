using System.Collections.Generic;
using UnityEngine;

public class ApplySegmentation : MonoBehaviour
{

    public Shader segmentShader;
    public Camera segmentCamera;

    Dictionary<string, Color32> segmentDict = new Dictionary<string, Color32>();

    void Start()
    {
        // Fill the Dictionary with Tag names and corresponding colors
        segmentDict.Add("wall", new Color32(1, 1, 1, 255));
        segmentDict.Add("building", new Color32(2, 2, 2, 255));
        segmentDict.Add("sky", new Color32(3, 3, 3, 255));
        segmentDict.Add("floor", new Color32(4, 4, 4, 255));
        segmentDict.Add("tree", new Color32(5, 5, 5, 255));
        segmentDict.Add("ceiling", new Color32(6, 6, 6, 255));
        segmentDict.Add("road", new Color32(7, 7, 7, 255));
        segmentDict.Add("bed", new Color32(8, 8, 8, 255));
        segmentDict.Add("windowpane", new Color32(9, 9, 9, 255));
        segmentDict.Add("grass", new Color32(10, 10, 10, 255));
        segmentDict.Add("cabinet", new Color32(11, 11, 11, 255));
        segmentDict.Add("sidewalk", new Color32(12, 12, 12, 255));
        segmentDict.Add("person", new Color32(13, 13, 13, 255));
        segmentDict.Add("earth", new Color32(14, 14, 14, 255));
        segmentDict.Add("door", new Color32(15, 15, 15, 255));
        segmentDict.Add("table", new Color32(16, 16, 16, 255));
        segmentDict.Add("mountain", new Color32(17, 17, 17, 255));
        segmentDict.Add("plant", new Color32(18, 18, 18, 255));
        segmentDict.Add("curtain", new Color32(19, 19, 19, 255));
        segmentDict.Add("chair", new Color32(20, 20, 20, 255));
        segmentDict.Add("car", new Color32(21, 21, 21, 255));
        segmentDict.Add("water", new Color32(22, 22, 22, 255));
        segmentDict.Add("painting", new Color32(23, 23, 23, 255));
        segmentDict.Add("sofa", new Color32(24, 24, 24, 255));
        segmentDict.Add("shelf", new Color32(25, 25, 25, 255));
        segmentDict.Add("house", new Color32(26, 26, 26, 255));
        segmentDict.Add("sea", new Color32(27, 27, 27, 255));
        segmentDict.Add("mirror", new Color32(28, 28, 28, 255));
        segmentDict.Add("rug", new Color32(29, 29, 29, 255));
        segmentDict.Add("field", new Color32(30, 30, 30, 255));
        segmentDict.Add("armchair", new Color32(31, 31, 31, 255));
        segmentDict.Add("seat", new Color32(32, 32, 32, 255));
        segmentDict.Add("fence", new Color32(33, 33, 33, 255));
        segmentDict.Add("desk", new Color32(34, 34, 34, 255));
        segmentDict.Add("rock", new Color32(35, 35, 35, 255));
        segmentDict.Add("wardrobe", new Color32(36, 36, 36, 255));
        segmentDict.Add("lamp", new Color32(37, 37, 37, 255));
        segmentDict.Add("bathtub", new Color32(38, 38, 38, 255));
        segmentDict.Add("railing", new Color32(39, 39, 39, 255));
        segmentDict.Add("cushion", new Color32(40, 40, 40, 255));
        segmentDict.Add("base", new Color32(41, 41, 41, 255));
        segmentDict.Add("box", new Color32(42, 42, 42, 255));
        segmentDict.Add("column", new Color32(43, 43, 43, 255));
        segmentDict.Add("signboard", new Color32(44, 44, 44, 255));
        segmentDict.Add("chest", new Color32(45, 45, 45, 255));
        segmentDict.Add("counter", new Color32(46, 46, 46, 255));
        segmentDict.Add("sand", new Color32(47, 47, 47, 255));
        segmentDict.Add("sink", new Color32(48, 48, 48, 255));
        segmentDict.Add("skyscraper", new Color32(49, 49, 49, 255));
        segmentDict.Add("fireplace", new Color32(50, 50, 50, 255));
        segmentDict.Add("refrigerator", new Color32(51, 51, 51, 255));
        segmentDict.Add("grandstand", new Color32(52, 52, 52, 255));
        segmentDict.Add("path", new Color32(53, 53, 53, 255));
        segmentDict.Add("stairs", new Color32(54, 54, 54, 255));
        segmentDict.Add("runway", new Color32(55, 55, 55, 255));
        segmentDict.Add("case", new Color32(56, 56, 56, 255));
        segmentDict.Add("pool", new Color32(57, 57, 57, 255));
        segmentDict.Add("pillow", new Color32(58, 58, 58, 255));
        segmentDict.Add("screen", new Color32(59, 59, 59, 255));
        segmentDict.Add("stairway", new Color32(60, 60, 60, 255));
        segmentDict.Add("river", new Color32(61, 61, 61, 255));
        segmentDict.Add("bridge", new Color32(62, 62, 62, 255));
        segmentDict.Add("bookcase", new Color32(63, 63, 63, 255));
        segmentDict.Add("blind", new Color32(64, 64, 64, 255));
        segmentDict.Add("coffee", new Color32(65, 65, 65, 255));
        segmentDict.Add("toilet", new Color32(66, 66, 66, 255));
        segmentDict.Add("flower", new Color32(67, 67, 67, 255));
        segmentDict.Add("book", new Color32(68, 68, 68, 255));
        segmentDict.Add("hill", new Color32(69, 69, 69, 255));
        segmentDict.Add("bench", new Color32(70, 70, 70, 255));
        segmentDict.Add("countertop", new Color32(71, 71, 71, 255));
        segmentDict.Add("stove", new Color32(72, 72, 72, 255));
        segmentDict.Add("palm", new Color32(73, 73, 73, 255));
        segmentDict.Add("kitchen", new Color32(74, 74, 74, 255));
        segmentDict.Add("computer", new Color32(75, 75, 75, 255));
        segmentDict.Add("swivel", new Color32(76, 76, 76, 255));
        segmentDict.Add("boat", new Color32(77, 77, 77, 255));
        segmentDict.Add("bar", new Color32(78, 78, 78, 255));
        segmentDict.Add("arcade", new Color32(79, 79, 79, 255));
        segmentDict.Add("hovel", new Color32(80, 80, 80, 255));
        segmentDict.Add("bus", new Color32(81, 81, 81, 255));
        segmentDict.Add("towel", new Color32(82, 82, 82, 255));
        segmentDict.Add("light", new Color32(83, 83, 83, 255));
        segmentDict.Add("truck", new Color32(84, 84, 84, 255));
        segmentDict.Add("tower", new Color32(85, 85, 85, 255));
        segmentDict.Add("chandelier", new Color32(86, 86, 86, 255));
        segmentDict.Add("awning", new Color32(87, 87, 87, 255));
        segmentDict.Add("streetlight", new Color32(88, 88, 88, 255));
        segmentDict.Add("booth", new Color32(89, 89, 89, 255));
        segmentDict.Add("television", new Color32(90, 90, 90, 255));
        segmentDict.Add("airplane", new Color32(91, 91, 91, 255));
        segmentDict.Add("dirt", new Color32(92, 92, 92, 255));
        segmentDict.Add("apparel", new Color32(93, 93, 93, 255));
        segmentDict.Add("pole", new Color32(94, 94, 94, 255));
        segmentDict.Add("land", new Color32(95, 95, 95, 255));
        segmentDict.Add("bannister", new Color32(96, 96, 96, 255));
        segmentDict.Add("escalator", new Color32(97, 97, 97, 255));
        segmentDict.Add("ottoman", new Color32(98, 98, 98, 255));
        segmentDict.Add("bottle", new Color32(99, 99, 99, 255));
        segmentDict.Add("buffet", new Color32(100, 100, 100, 255));
        segmentDict.Add("poster", new Color32(101, 101, 101, 255));
        segmentDict.Add("stage", new Color32(102, 102, 102, 255));
        segmentDict.Add("van", new Color32(103, 103, 103, 255));
        segmentDict.Add("ship", new Color32(104, 104, 104, 255));
        segmentDict.Add("fountain", new Color32(105, 105, 105, 255));
        segmentDict.Add("conveyer", new Color32(106, 106, 106, 255));
        segmentDict.Add("canopy", new Color32(107, 107, 107, 255));
        segmentDict.Add("washer", new Color32(108, 108, 108, 255));
        segmentDict.Add("plaything", new Color32(109, 109, 109, 255));
        segmentDict.Add("swimming", new Color32(110, 110, 110, 255));
        segmentDict.Add("stool", new Color32(111, 111, 111, 255));
        segmentDict.Add("barrel", new Color32(112, 112, 112, 255));
        segmentDict.Add("basket", new Color32(113, 113, 113, 255));
        segmentDict.Add("waterfall", new Color32(114, 114, 114, 255));
        segmentDict.Add("tent", new Color32(115, 115, 115, 255));
        segmentDict.Add("bag", new Color32(116, 116, 116, 255));
        segmentDict.Add("minibike", new Color32(117, 117, 117, 255));
        segmentDict.Add("cradle", new Color32(118, 118, 118, 255));
        segmentDict.Add("oven", new Color32(119, 119, 119, 255));
        segmentDict.Add("ball", new Color32(120, 120, 120, 255));
        segmentDict.Add("food", new Color32(121, 121, 121, 255));
        segmentDict.Add("step", new Color32(122, 122, 122, 255));
        segmentDict.Add("tank", new Color32(123, 123, 123, 255));
        segmentDict.Add("trade", new Color32(124, 124, 124, 255));
        segmentDict.Add("microwave", new Color32(125, 125, 125, 255));
        segmentDict.Add("pot", new Color32(126, 126, 126, 255));
        segmentDict.Add("animal", new Color32(127, 127, 127, 255));
        segmentDict.Add("bicycle", new Color32(128, 128, 128, 255));
        segmentDict.Add("lake", new Color32(129, 129, 129, 255));
        segmentDict.Add("dishwasher", new Color32(130, 130, 130, 255));
        segmentDict.Add("projection", new Color32(131, 131, 131, 255));
        segmentDict.Add("blanket", new Color32(132, 132, 132, 255));
        segmentDict.Add("sculpture", new Color32(133, 133, 133, 255));
        segmentDict.Add("hood", new Color32(134, 134, 134, 255));
        segmentDict.Add("sconce", new Color32(135, 135, 135, 255));
        segmentDict.Add("vase", new Color32(136, 136, 136, 255));
        segmentDict.Add("traffic", new Color32(137, 137, 137, 255));
        segmentDict.Add("tray", new Color32(138, 138, 138, 255));
        segmentDict.Add("ashcan", new Color32(139, 139, 139, 255));
        segmentDict.Add("fan", new Color32(140, 140, 140, 255));
        segmentDict.Add("pier", new Color32(141, 141, 141, 255));
        segmentDict.Add("crt", new Color32(142, 142, 142, 255));
        segmentDict.Add("plate", new Color32(143, 143, 143, 255));
        segmentDict.Add("monitor", new Color32(144, 144, 144, 255));
        segmentDict.Add("bulletin", new Color32(145, 145, 145, 255));
        segmentDict.Add("shower", new Color32(146, 146, 146, 255));
        segmentDict.Add("radiator", new Color32(147, 147, 147, 255));
        segmentDict.Add("glass", new Color32(148, 148, 148, 255));
        segmentDict.Add("clock", new Color32(149, 149, 149, 255));
        segmentDict.Add("flag", new Color32(150, 150, 150, 255));

        // Find all GameObjects with Mesh Renderer and add a color variable to be
        // used by the shader in it's MaterialPropertyBlock
        var renderers = FindObjectsOfType<MeshRenderer>();
        var mpb = new MaterialPropertyBlock();
        foreach (var r in renderers)
        {

            if (segmentDict.TryGetValue(r.transform.tag, out Color32 outColor))
            {
                mpb.SetColor("_SegmentColor", outColor);
                r.SetPropertyBlock(mpb);
            }
        }

        // Finally set the Segment shader as replacement shader
        segmentCamera.SetReplacementShader(segmentShader, "RenderType");
    }
}
