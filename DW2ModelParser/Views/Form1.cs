using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DW2ModelParser.Base;
using DW2ModelParser.FileTypes;
using DW2ModelParser.Headers;
using DW2ModelParser.Structs;
using DW2ModelParser.Utilities;

namespace DW2ModelParser.Views
{
    public partial class Form1 : Form
    {
        public enum ModelFileType
        {
            Battle,
            Dungeon,
            City,
        }
        private ModelFileType ModelType;

        Dictionary<ModelFileType, string[]> ModelTypeAnimationPrefixMap = new Dictionary<ModelFileType, string[]>()
        {
            {ModelFileType.Battle, new string[] {"A", "B", "C", "D", "F", "G", "H", "I", "J", "K" }},
            {ModelFileType.Dungeon, new string[] {"E"}},
            {ModelFileType.City, new string[] {"D"}},
        };

        private FileInfo ModelFileInfo { get; set; }
        private ModelFile LoadedModelFile { get; set; }
        private int ClutScale { get; set; }
        private int TextureScale { get; set; }
        private bool DrawUvs { get; set; }

        private Size TexturePictureBoxOrigSize { get; set; }
        private Point ClutPictureBoxOrigLocation { get; set; }
        private Point ClutLabelOrigLocation { get; set; }
        private Point ClutUpDownOrigLocation { get; set; }

        public Form1()
        {
            InitializeComponent();
            InitializeValues();

            //ModelFile mFile = new ModelFile(@"C:\EmulatorsAndRomhacking\DigimonWorld2\AAA\4.AAA\MODEL\MODEL000\M003AGUM - Copy.BIN");
            //Console.WriteLine(Environment.NewLine);
            //AnimationFile aFile = new AnimationFile(@"C:\EmulatorsAndRomhacking\DigimonWorld2\AAA\4.AAA\MODEL\MODEL000\A003AGUM - Copy.BIN", mFile.ModelHeader.BoneCount);
        }

        private void InitializeValues()
        {
            ModelTypeComboBox.DataSource = Enum.GetValues(typeof(ModelFileType));
            ModelTypeComboBox.SelectedIndex = 0;
            ClutScale = (int)ClutScaleUpDown.Value;
            TextureScale = (int)TextureScaleUpDown.Value;
            DrawUvs = DrawUVsCheckbox.Checked;
            DrawUVsCheckbox.Enabled = false;

            TexturePictureBoxOrigSize = TexturePictureBox.Size;
            ClutPictureBoxOrigLocation = ClutPictureBox.Location;
            ClutLabelOrigLocation = ClutLabel.Location;
            ClutUpDownOrigLocation = ClutScaleUpDown.Location;

        }

        /// <summary>
        /// Reset all loaded values
        /// </summary>
        private void ResetValues()
        {
            LoadedModelFile = null;
            ModelFileInfo = null;
            TexturePictureBox = null;
            ClutPictureBox = null;

            ExtractTextureButton.Enabled = false;
            ClutScaleUpDown.Enabled = false;
            TextureScaleUpDown.Enabled = false;
            DrawUVsCheckbox.Enabled = false;

            ModelFileTextBox.Text = "";
            IdleFileTextBox.Text = "";
            SmallDamageTextBox.Text = "";
            LargeDamageFileTextbox.Text = "";
            CityAnimationFileTextBox.Text = "";
            DungeonAnimationFileTextBox.Text = "";
            Attack1FileTextBox.Text = "";
            Attack2FileTextBox.Text = "";
            Attack3FileTextBox.Text = "";
            WinFileTextBox.Text = "";
            GettingUpFileTextBox.Text = "";
            DeadAnimationTextBox.Text = "";
        }

        private void EnableTextureOptions()
        {
            ExtractTextureButton.Enabled = true;
        }

        /// <summary>
        /// Find the related animation files for the loaded model, based on the selected <see cref="ModelType"/>
        /// </summary>
        private void FindRelatedAnimationFiles()
        {
            string modelFileName = ModelFileInfo.Name;
            string modelFilePath = ModelFileInfo.Directory.FullName;
            string[] prefixes = ModelTypeAnimationPrefixMap[ModelType];
            string[] animationFilepaths = new string[prefixes.Length];
            for (int i = 0; i < prefixes.Length; i++)
            {
                string newFileName = modelFileName.Remove(0, 1).Insert(0, prefixes[i]);
                string newFilePath = Path.Combine(modelFilePath, newFileName);
                animationFilepaths[i] = File.Exists(newFilePath) ? newFilePath : "File not found/Does not exist";
            }

            PopulateAnimationFilepathComboBoxes(animationFilepaths);
        }

        /// <summary>
        /// Set the filepaths for all the related animation files to their respective textboxes
        /// </summary>
        /// <param name="animationFilepaths">The filepaths to show</param>
        private void PopulateAnimationFilepathComboBoxes(string[] animationFilepaths)
        {
            switch (ModelType)
            {
                case ModelFileType.Battle:
                    IdleFileTextBox.Text = animationFilepaths[0];
                    SmallDamageTextBox.Text = animationFilepaths[1];
                    LargeDamageFileTextbox.Text = animationFilepaths[2];
                    CityAnimationFileTextBox.Text = animationFilepaths[3];
                    DungeonAnimationFileTextBox.Text = "N/A";
                    Attack1FileTextBox.Text = animationFilepaths[4];
                    Attack2FileTextBox.Text = animationFilepaths[5];
                    Attack3FileTextBox.Text = animationFilepaths[6];
                    WinFileTextBox.Text = animationFilepaths[7];
                    GettingUpFileTextBox.Text = animationFilepaths[8];
                    DeadAnimationTextBox.Text = animationFilepaths[9];
                    break;
                case ModelFileType.Dungeon:
                    IdleFileTextBox.Text = "N/A";
                    SmallDamageTextBox.Text = "N/A";
                    LargeDamageFileTextbox.Text = "N/A";
                    CityAnimationFileTextBox.Text = "N/A";
                    DungeonAnimationFileTextBox.Text = animationFilepaths[0];
                    Attack1FileTextBox.Text = "N/A";
                    Attack2FileTextBox.Text = "N/A";
                    Attack3FileTextBox.Text = "N/A";
                    WinFileTextBox.Text = "N/A";
                    GettingUpFileTextBox.Text = "N/A";
                    DeadAnimationTextBox.Text = "N/A";
                    break;
                case ModelFileType.City:
                    IdleFileTextBox.Text = "N/A";
                    SmallDamageTextBox.Text = "N/A";
                    LargeDamageFileTextbox.Text = "N/A";
                    CityAnimationFileTextBox.Text = animationFilepaths[0];
                    DungeonAnimationFileTextBox.Text = "N/A";
                    Attack1FileTextBox.Text = "N/A";
                    Attack2FileTextBox.Text = "N/A";
                    Attack3FileTextBox.Text = "N/A";
                    WinFileTextBox.Text = "N/A";
                    GettingUpFileTextBox.Text = "N/A";
                    DeadAnimationTextBox.Text = "N/A";
                    break;
                default:
                    break;
            }
        }

        private void GetBonesPrimitiveData()
        {
            Bitmap textureBmp = new Bitmap(LoadedModelFile.ModelTimHeader._TruePixelWidth * TextureScale, LoadedModelFile.ModelTimHeader.Height * TextureScale);
            //Bitmap textureBmp = new Bitmap(TexturePictureBox.Image);

            foreach (var bonesPrimitives in LoadedModelFile.PrimitivesData)
            {
                foreach (var primitive in bonesPrimitives)
                {
                    switch (primitive.Type)
                    {
                        case BasePrimitive.PrimitiveType.Tri:
                            RenderBoneTextureData(ref textureBmp, (TriPrimitive)primitive);
                            break;

                        case BasePrimitive.PrimitiveType.Quad:
                            RenderBoneTextureData(ref textureBmp, (QuadPrimitive)primitive);
                            break;

                        default:
                            break;
                    }
                }
            }
            TexturePictureBox.Image = textureBmp;
        }

        private void RenderBoneTextureData(ref Bitmap textureBmp, TriPrimitive primitiveData)
        {
            int clutOffset = LoadedModelFile.ModelHeader.TimPointer + ModelTimHeader._HeaderLength + primitiveData.ClutOffset;
            if (DrawUvs)
                DrawUvTriOutlines(textureBmp, primitiveData.UvMap.Point1, primitiveData.UvMap.Point2, primitiveData.UvMap.Point3);

            //Order the UVs by width
            var vOrderedUvs = primitiveData.UvMap.GetUvsAsArray().OrderBy(uv => uv.V).ToArray();
            //Order the UVs by height
            var uOrderedUvs = primitiveData.UvMap.GetUvsAsArray().OrderBy(uv => uv.U).ToArray();

            //Loop from min to max height
            for (int v = vOrderedUvs[0].V * TextureScale; v < vOrderedUvs[2].V * TextureScale; v += TextureScale)
            {
                //Loop from min to max width
                for (int u = uOrderedUvs[0].U * TextureScale; u < uOrderedUvs[2].U * TextureScale; u += TextureScale * 2)
                {
                    //if (Maths.PointIsInTriangle(primitiveData.UvMap.Point1 * TextureScale, primitiveData.UvMap.Point2 * TextureScale, primitiveData.UvMap.Point3 * TextureScale, new Point(u, v)))
                    //if (Maths.PointIsInTriangle(primitiveData.UvMap.Point2 * TextureScale, primitiveData.UvMap.Point3 * TextureScale, primitiveData.UvMap.Point1 * TextureScale, new Point(u, v)))
                    //if (Maths.PointIsInTriangle(primitiveData.UvMap.Point3 * TextureScale, primitiveData.UvMap.Point1 * TextureScale, primitiveData.UvMap.Point2 * TextureScale, new Point(u, v)))
                    //if (Maths.PointIsInTriangle(primitiveData.UvMap.Point1 * TextureScale, primitiveData.UvMap.Point3 * TextureScale, primitiveData.UvMap.Point2 * TextureScale, new Point(u, v)))
                    //if (Maths.PointIsInTriangle(primitiveData.UvMap.Point2 * TextureScale, primitiveData.UvMap.Point1 * TextureScale, primitiveData.UvMap.Point3 * TextureScale, new Point(u, v)))
                    {
                        int pixelId = (u / 2 / TextureScale) + (v * LoadedModelFile.ModelTimHeader._TrueByteWidth / TextureScale);

                        //Get the byte for the pixel we want the draw
                        byte pixelValue = LoadedModelFile.TextureData[pixelId];

                        //Then get the high and low nibble which each represent a pixel. With the low nibble being the right pixel, and high the left.
                        byte leftPixel = pixelValue.LowNibble();
                        byte rightPixel = pixelValue.HighNibble();

                        int ClutOffset = (primitiveData.ClutOffset - 0x3E00) / 2;


                        //First we draw the left pixel N times based on scale
                        for (int vScaled = 0; vScaled < TextureScale; vScaled++)
                            for (int uScaled = 0; uScaled < TextureScale; uScaled++)
                                textureBmp.SetPixel(u + uScaled, v + vScaled, LoadedModelFile.CLUT.Colours[ClutOffset + leftPixel]);


                        ////Then the right pixel
                        for (int yScaled = 0; yScaled < TextureScale; yScaled++)
                            for (int xScaled = 0; xScaled < TextureScale; xScaled++)
                                textureBmp.SetPixel(u + xScaled + TextureScale, v + yScaled, LoadedModelFile.CLUT.Colours[ClutOffset + rightPixel]);

                    }
                }
            }
        }


        private void RenderBoneTextureData(ref Bitmap textureBmp, QuadPrimitive primitiveData)
        {
            int clutOffset = LoadedModelFile.ModelHeader.TimPointer + ModelTimHeader._HeaderLength + primitiveData.ClutOffset;

            if (DrawUvs)
            {
                DrawUvTriOutlines(textureBmp, primitiveData.UvMap.Point1, primitiveData.UvMap.Point2, primitiveData.UvMap.Point3);
                DrawUvTriOutlines(textureBmp, primitiveData.UvMap.Point4, primitiveData.UvMap.Point2, primitiveData.UvMap.Point3);
            }

            var vOrderedUvs = primitiveData.UvMap.GetUvsAsArray().Take(3).OrderBy(uv => uv.V).ToArray();
            var uOrderedUvs = primitiveData.UvMap.GetUvsAsArray().Take(3).OrderBy(uv => uv.U).ToArray();

            for (int v = vOrderedUvs[0].V * TextureScale; v < vOrderedUvs[2].V * TextureScale; v += TextureScale)
            {
                for (int u = uOrderedUvs[0].U * TextureScale; u < uOrderedUvs[2].U * TextureScale; u += TextureScale * 2)
                {
                    //if (Maths.PointIsInTriangle(primitiveData.UvMap.Point1 * TextureScale, primitiveData.UvMap.Point2 * TextureScale, primitiveData.UvMap.Point3 * TextureScale, new Point(u, v)))
                    {
                        int pixelId = (u / 2 / TextureScale) + (v * LoadedModelFile.ModelTimHeader._TrueByteWidth / TextureScale);

                        //Get the byte for the pixel we want the draw
                        byte pixelValue = LoadedModelFile.TextureData[pixelId];

                        //Then get the high and low nibble which each represent a pixel. With the low nibble being the right pixel, and high the left.
                        byte leftPixel = pixelValue.LowNibble();
                        byte rightPixel = pixelValue.HighNibble();

                        int ClutOffset = (primitiveData.ClutOffset - 0x3E00) / 2;
                        //textureBmp.SetPixel(u, v, LoadedModelFile.CLUT.Colours[ClutOffset + leftPixel]);
                        //textureBmp.SetPixel(u + 1, v, LoadedModelFile.CLUT.Colours[ClutOffset + rightPixel]);

                        //First we draw the left pixel N times based on scale
                        for (int vScaled = 0; vScaled < TextureScale; vScaled++)
                            for (int uScaled = 0; uScaled < TextureScale; uScaled++)
                                textureBmp.SetPixel(u + uScaled, v + vScaled, LoadedModelFile.CLUT.Colours[ClutOffset + leftPixel]);


                        //Then the right pixel
                        for (int yScaled = 0; yScaled < TextureScale; yScaled++)
                            for (int xScaled = 0; xScaled < TextureScale; xScaled++)
                                textureBmp.SetPixel(u + xScaled + TextureScale, v + yScaled, LoadedModelFile.CLUT.Colours[ClutOffset + rightPixel]);

                    }
                }
            }

            vOrderedUvs = primitiveData.UvMap.GetUvsAsArray().Skip(1).OrderBy(uv => uv.V).ToArray();
            uOrderedUvs = primitiveData.UvMap.GetUvsAsArray().Skip(1).OrderBy(uv => uv.U).ToArray();

            for (int v = vOrderedUvs[0].V * TextureScale; v < vOrderedUvs[2].V * TextureScale; v += TextureScale)
            {
                for (int u = uOrderedUvs[0].U * TextureScale; u < uOrderedUvs[2].U * TextureScale; u += TextureScale * 2)
                {
                    if (Maths.PointIsInTriangle(primitiveData.UvMap.Point3 * TextureScale, primitiveData.UvMap.Point2 * TextureScale, primitiveData.UvMap.Point4 * TextureScale, new Point(u, v)))
                    {
                        int pixelId = (u / 2 / TextureScale) + (v * LoadedModelFile.ModelTimHeader._TrueByteWidth / TextureScale);

                        //Get the byte for the pixel we want the draw
                        byte pixelValue = LoadedModelFile.TextureData[pixelId];

                        //Then get the high and low nibble which each represent a pixel. With the low nibble being the right pixel, and high the left.
                        byte leftPixel = pixelValue.LowNibble();
                        byte rightPixel = pixelValue.HighNibble();

                        int ClutOffset = (primitiveData.ClutOffset - 0x3E00) / 2;
                        //textureBmp.SetPixel(u, v, LoadedModelFile.CLUT.Colours[ClutOffset + leftPixel]);
                        //textureBmp.SetPixel(u + 1, v, LoadedModelFile.CLUT.Colours[ClutOffset + rightPixel]);

                        //First we draw the left pixel N times based on scale
                        for (int vScaled = 0; vScaled < TextureScale; vScaled++)
                            for (int uScaled = 0; uScaled < TextureScale; uScaled++)
                                textureBmp.SetPixel(u + uScaled, v + vScaled, LoadedModelFile.CLUT.Colours[ClutOffset + leftPixel]);


                        ////Then the right pixel
                        for (int yScaled = 0; yScaled < TextureScale; yScaled++)
                            for (int xScaled = 0; xScaled < TextureScale; xScaled++)
                                textureBmp.SetPixel(u + xScaled + TextureScale, v + yScaled, LoadedModelFile.CLUT.Colours[ClutOffset + rightPixel]);

                    }
                }
            }
        }

        /// <summary>
        /// Draw the outlines of the UVs between the given UV coordinates
        /// </summary>
        /// <param name="textureBmp">The Bitmap on which to draw the lines</param>
        /// <param name="uv1">UV Coordinate 1</param>
        /// <param name="uv2">UV Coordinate 2</param>
        /// <param name="uv3">UV Coordinate 3</param>
        private void DrawUvTriOutlines(Bitmap textureBmp, UvCoord uv1, UvCoord uv2, UvCoord uv3)
        {
            //Pen p = new Pen(Color.FromKnownColor((KnownColor)(47 + (uv1.U + uv1.V) % 21)), 1);
            Pen p = new Pen(Color.Red, 2);
            if (uv2.V == 0)
            {
                Console.WriteLine($"{uv1}, {uv2}, {uv3}");
            }
            using (var graphics = Graphics.FromImage(textureBmp))
            {
                graphics.DrawLine(p, uv1 * TextureScale, uv2 * TextureScale);
                graphics.DrawLine(p, uv2 * TextureScale, uv3 * TextureScale);
                graphics.DrawLine(p, uv3 * TextureScale, uv1 * TextureScale);

            }
            TexturePictureBox.Image = textureBmp;
        }

        private void RenderModelTextureScaled()
        {
            return;
            //We use the TruePixelWidth because that is the actual width of the texture, when accounting for nibbles and the wrong width count
            Bitmap textureBmp = new Bitmap(LoadedModelFile.ModelTimHeader._TruePixelWidth * TextureScale, LoadedModelFile.ModelTimHeader.Height * TextureScale);

            for (int v = 0; v < textureBmp.Height; v += TextureScale)
            {
                //We need to loop to the true pixel width to fill the whole BMP
                //for (int x = 0; x < LoadedModelFile.ModelTimHeader._TruePixelWidth; x += (TextureScale * 2))
                for (int u = 0; u < textureBmp.Width; u += TextureScale * 2)
                {
                    //But we only need to grab the TrueByteWidth for the X value of getting the pixelID
                    //Thus we need to divide the X pixel value by 2.
                    //And divide by the clut scale as this only affects the rending, and not the actual source data
                    int pixelId = (u / 2 / TextureScale) + (v * LoadedModelFile.ModelTimHeader._TrueByteWidth / TextureScale);

                    //Get the byte for the pixel we want the draw
                    byte pixelValue = LoadedModelFile.TextureData[pixelId];

                    //Then get the high and low nibble which each represent a pixel. With the low nibble being the right pixel, and high the left.
                    byte leftPixel = pixelValue.LowNibble();
                    byte rightPixel = pixelValue.HighNibble();

                    //First we draw the left pixel N times based on scale
                    for (int vScaled = 0; vScaled < TextureScale; vScaled++)
                        for (int uScaled = 0; uScaled < TextureScale; uScaled++)
                            textureBmp.SetPixel(u + uScaled, v + vScaled, LoadedModelFile.CLUT.Colours[leftPixel + 128]);


                    ////Then the right pixel
                    for (int ys = 0; ys < TextureScale; ys++)
                        for (int xs = 0; xs < TextureScale; xs++)
                            textureBmp.SetPixel(u + xs + TextureScale, v + ys, LoadedModelFile.CLUT.Colours[rightPixel + 128]);
                }
            }
            TexturePictureBox.Image = textureBmp;
        }

        /// <summary>
        /// Render the last 0x200 bytes that are in the texture wich denote the CLUT
        /// Because by default each colour is only 1 pixel we apply user-defined scaling to make it more visible
        /// </summary>
        private void RenderModelClutScaled()
        {
            Bitmap clutBmp = new Bitmap(ColourLookupTable.ClutWidth * ClutScale, ColourLookupTable.ClutHeight * ClutScale);

            for (int v = 0; v < clutBmp.Height; v += ClutScale)
            {
                for (int u = 0; u < clutBmp.Width; u += ClutScale)
                {
                    //Get the ID of the colour we want to draw
                    int colId = (u / ClutScale) + (v * ColourLookupTable.ClutWidth / ClutScale);

                    //We need to render each pixel N amount of times based on the scaling applied to the clut
                    for (int vScaled = 0; vScaled < ClutScale; vScaled++)
                        for (int uScaled = 0; uScaled < ClutScale; uScaled++)
                            clutBmp.SetPixel(u + uScaled, v + vScaled, LoadedModelFile.CLUT.Colours[colId]);
                }
            }

            ClutPictureBox.Image = clutBmp;
        }

        private void RepositionClutUI()
        {
            int heightModifier = TexturePictureBoxOrigSize.Height * (TextureScale - 1);
            ClutPictureBox.Location = new Point(ClutPictureBoxOrigLocation.X, ClutPictureBoxOrigLocation.Y + heightModifier);
            ClutLabel.Location = new Point(ClutLabelOrigLocation.X, ClutLabelOrigLocation.Y + heightModifier);
            ClutScaleUpDown.Location = new Point(ClutUpDownOrigLocation.X, ClutUpDownOrigLocation.Y + heightModifier);
        }

        #region UserEvents
        private void ModelTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModelType = (ModelFileType)Enum.Parse(typeof(ModelFileType), ((ComboBox)(sender)).SelectedItem.ToString());
        }

        private void SelectModelFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                RestoreDirectory = true,
                Filter = "binary files (.bin)|*.bin|All files(*.*)|*.*",
                Title = "Select model file",
                FileName = "M*",
                DefaultExt = ".BIN"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ModelFileInfo = new FileInfo(fileDialog.FileName);
                ModelFileTextBox.Text = fileDialog.FileName;
                FindRelatedAnimationFiles();
                EnableTextureOptions();
            }
            else
            {
                ResetValues();
            }
        }

        private void ExtractTextureButton_Click(object sender, EventArgs e)
        {
            LoadedModelFile = new ModelFile(ModelFileInfo.FullName);
            if (LoadedModelFile == null)
                return;

            RenderModelClutScaled();
            RenderModelTextureScaled();
            GetBonesPrimitiveData();
            ClutScaleUpDown.Enabled = true;
            TextureScaleUpDown.Enabled = true;
            DrawUVsCheckbox.Enabled = true;
        }

        private void ExtractTextureButton_EnabledChanged(object sender, EventArgs e)
        {
            Button extractTextureButton = (Button)sender;
            extractTextureButton.BackColor = extractTextureButton.Enabled ? Color.WhiteSmoke : Color.DimGray;
        }

        private void ClutScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            ClutScale = (int)((NumericUpDown)sender).Value;
            ClutPictureBox.Width = ColourLookupTable.ClutWidth * ClutScale;
            ClutPictureBox.Height = ColourLookupTable.ClutHeight * ClutScale;

            RenderModelClutScaled();
        }

        private void TextureScaleUpDown_ValueChanged(object sender, EventArgs e)
        {
            TextureScale = (int)((NumericUpDown)sender).Value;
            TexturePictureBox.Width = LoadedModelFile.ModelTimHeader._TruePixelWidth * TextureScale;
            TexturePictureBox.Height = LoadedModelFile.ModelTimHeader.Height * TextureScale;

            RenderModelTextureScaled();
            GetBonesPrimitiveData();
            RepositionClutUI();
        }

        private void DrawUVsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            DrawUvs = ((CheckBox)sender).Checked;
            RenderModelTextureScaled();
            GetBonesPrimitiveData();
        }
        #endregion
    }
}
