namespace DW2ModelParser.Views
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ModelTypeComboBox = new System.Windows.Forms.ComboBox();
            this.SelectModelTypeLabel = new System.Windows.Forms.Label();
            this.SelectModelFileLabel = new System.Windows.Forms.Label();
            this.SelectModelFileButton = new System.Windows.Forms.Button();
            this.LoadedModelFilePathLabel = new System.Windows.Forms.Label();
            this.ModelFileTextBox = new System.Windows.Forms.TextBox();
            this.IdleFileTextBox = new System.Windows.Forms.TextBox();
            this.IdleFileLabel = new System.Windows.Forms.Label();
            this.SmallDamageTextBox = new System.Windows.Forms.TextBox();
            this.SmallDamageFileLabel = new System.Windows.Forms.Label();
            this.LargeDamageFileTextbox = new System.Windows.Forms.TextBox();
            this.LargeDamageFileLabel = new System.Windows.Forms.Label();
            this.CityAnimationFileTextBox = new System.Windows.Forms.TextBox();
            this.CityAnimationFileLabel = new System.Windows.Forms.Label();
            this.DungeonAnimationFileTextBox = new System.Windows.Forms.TextBox();
            this.DungeonAnimationFileLabel = new System.Windows.Forms.Label();
            this.Attack1FileTextBox = new System.Windows.Forms.TextBox();
            this.Attack1FileLabel = new System.Windows.Forms.Label();
            this.Attack2FileTextBox = new System.Windows.Forms.TextBox();
            this.Attack2FileLabel = new System.Windows.Forms.Label();
            this.Attack3FileTextBox = new System.Windows.Forms.TextBox();
            this.Attack3FileLabel = new System.Windows.Forms.Label();
            this.WinFileTextBox = new System.Windows.Forms.TextBox();
            this.WinFileLabel = new System.Windows.Forms.Label();
            this.GettingUpFileTextBox = new System.Windows.Forms.TextBox();
            this.GettingUpFileLabel = new System.Windows.Forms.Label();
            this.DeadAnimationTextBox = new System.Windows.Forms.TextBox();
            this.DeadAnimationFileLabel = new System.Windows.Forms.Label();
            this.TexturePictureBox = new System.Windows.Forms.PictureBox();
            this.ClutPictureBox = new System.Windows.Forms.PictureBox();
            this.ExtractTextureButton = new System.Windows.Forms.Button();
            this.ClutLabel = new System.Windows.Forms.Label();
            this.ClutScaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.TextureScaledLabel = new System.Windows.Forms.Label();
            this.TextureScaleUpDown = new System.Windows.Forms.NumericUpDown();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.DrawUVsCheckbox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.TexturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClutPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClutScaleUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureScaleUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // ModelTypeComboBox
            // 
            this.ModelTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModelTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ModelTypeComboBox.FormattingEnabled = true;
            this.ModelTypeComboBox.Location = new System.Drawing.Point(39, 61);
            this.ModelTypeComboBox.Name = "ModelTypeComboBox";
            this.ModelTypeComboBox.Size = new System.Drawing.Size(130, 28);
            this.ModelTypeComboBox.TabIndex = 1;
            this.ModelTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.ModelTypeComboBox_SelectedIndexChanged);
            // 
            // SelectModelTypeLabel
            // 
            this.SelectModelTypeLabel.AutoSize = true;
            this.SelectModelTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SelectModelTypeLabel.ForeColor = System.Drawing.Color.White;
            this.SelectModelTypeLabel.Location = new System.Drawing.Point(35, 32);
            this.SelectModelTypeLabel.Name = "SelectModelTypeLabel";
            this.SelectModelTypeLabel.Size = new System.Drawing.Size(139, 20);
            this.SelectModelTypeLabel.TabIndex = 0;
            this.SelectModelTypeLabel.Text = "Select model type:";
            // 
            // SelectModelFileLabel
            // 
            this.SelectModelFileLabel.AutoSize = true;
            this.SelectModelFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SelectModelFileLabel.ForeColor = System.Drawing.Color.White;
            this.SelectModelFileLabel.Location = new System.Drawing.Point(180, 32);
            this.SelectModelFileLabel.Name = "SelectModelFileLabel";
            this.SelectModelFileLabel.Size = new System.Drawing.Size(139, 20);
            this.SelectModelFileLabel.TabIndex = 2;
            this.SelectModelFileLabel.Text = "Selecy [M]odel file:";
            // 
            // SelectModelFileButton
            // 
            this.SelectModelFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.SelectModelFileButton.Location = new System.Drawing.Point(184, 55);
            this.SelectModelFileButton.Name = "SelectModelFileButton";
            this.SelectModelFileButton.Size = new System.Drawing.Size(130, 34);
            this.SelectModelFileButton.TabIndex = 3;
            this.SelectModelFileButton.Text = "Select Model";
            this.SelectModelFileButton.UseVisualStyleBackColor = true;
            this.SelectModelFileButton.Click += new System.EventHandler(this.SelectModelFileButton_Click);
            // 
            // LoadedModelFilePathLabel
            // 
            this.LoadedModelFilePathLabel.AutoSize = true;
            this.LoadedModelFilePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LoadedModelFilePathLabel.ForeColor = System.Drawing.Color.White;
            this.LoadedModelFilePathLabel.Location = new System.Drawing.Point(36, 116);
            this.LoadedModelFilePathLabel.Name = "LoadedModelFilePathLabel";
            this.LoadedModelFilePathLabel.Size = new System.Drawing.Size(100, 18);
            this.LoadedModelFilePathLabel.TabIndex = 4;
            this.LoadedModelFilePathLabel.Text = "[M] Model file:";
            // 
            // ModelFileTextBox
            // 
            this.ModelFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ModelFileTextBox.Location = new System.Drawing.Point(39, 137);
            this.ModelFileTextBox.Name = "ModelFileTextBox";
            this.ModelFileTextBox.ReadOnly = true;
            this.ModelFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.ModelFileTextBox.Size = new System.Drawing.Size(648, 24);
            this.ModelFileTextBox.TabIndex = 5;
            // 
            // IdleFileTextBox
            // 
            this.IdleFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.IdleFileTextBox.Location = new System.Drawing.Point(39, 185);
            this.IdleFileTextBox.Name = "IdleFileTextBox";
            this.IdleFileTextBox.ReadOnly = true;
            this.IdleFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.IdleFileTextBox.Size = new System.Drawing.Size(648, 24);
            this.IdleFileTextBox.TabIndex = 7;
            // 
            // IdleFileLabel
            // 
            this.IdleFileLabel.AutoSize = true;
            this.IdleFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.IdleFileLabel.ForeColor = System.Drawing.Color.White;
            this.IdleFileLabel.Location = new System.Drawing.Point(36, 164);
            this.IdleFileLabel.Name = "IdleFileLabel";
            this.IdleFileLabel.Size = new System.Drawing.Size(145, 18);
            this.IdleFileLabel.TabIndex = 6;
            this.IdleFileLabel.Text = "[A] Idle animation file:";
            // 
            // SmallDamageTextBox
            // 
            this.SmallDamageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SmallDamageTextBox.Location = new System.Drawing.Point(39, 233);
            this.SmallDamageTextBox.Name = "SmallDamageTextBox";
            this.SmallDamageTextBox.ReadOnly = true;
            this.SmallDamageTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SmallDamageTextBox.Size = new System.Drawing.Size(648, 24);
            this.SmallDamageTextBox.TabIndex = 9;
            // 
            // SmallDamageFileLabel
            // 
            this.SmallDamageFileLabel.AutoSize = true;
            this.SmallDamageFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.SmallDamageFileLabel.ForeColor = System.Drawing.Color.White;
            this.SmallDamageFileLabel.Location = new System.Drawing.Point(36, 212);
            this.SmallDamageFileLabel.Name = "SmallDamageFileLabel";
            this.SmallDamageFileLabel.Size = new System.Drawing.Size(218, 18);
            this.SmallDamageFileLabel.TabIndex = 8;
            this.SmallDamageFileLabel.Text = "[B] Small damage animation file:";
            // 
            // LargeDamageFileTextbox
            // 
            this.LargeDamageFileTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LargeDamageFileTextbox.Location = new System.Drawing.Point(39, 281);
            this.LargeDamageFileTextbox.Name = "LargeDamageFileTextbox";
            this.LargeDamageFileTextbox.ReadOnly = true;
            this.LargeDamageFileTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.LargeDamageFileTextbox.Size = new System.Drawing.Size(648, 24);
            this.LargeDamageFileTextbox.TabIndex = 11;
            // 
            // LargeDamageFileLabel
            // 
            this.LargeDamageFileLabel.AutoSize = true;
            this.LargeDamageFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.LargeDamageFileLabel.ForeColor = System.Drawing.Color.White;
            this.LargeDamageFileLabel.Location = new System.Drawing.Point(36, 260);
            this.LargeDamageFileLabel.Name = "LargeDamageFileLabel";
            this.LargeDamageFileLabel.Size = new System.Drawing.Size(219, 18);
            this.LargeDamageFileLabel.TabIndex = 10;
            this.LargeDamageFileLabel.Text = "[C] Large damage animation file:";
            // 
            // CityAnimationFileTextBox
            // 
            this.CityAnimationFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CityAnimationFileTextBox.Location = new System.Drawing.Point(39, 329);
            this.CityAnimationFileTextBox.Name = "CityAnimationFileTextBox";
            this.CityAnimationFileTextBox.ReadOnly = true;
            this.CityAnimationFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.CityAnimationFileTextBox.Size = new System.Drawing.Size(648, 24);
            this.CityAnimationFileTextBox.TabIndex = 13;
            // 
            // CityAnimationFileLabel
            // 
            this.CityAnimationFileLabel.AutoSize = true;
            this.CityAnimationFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.CityAnimationFileLabel.ForeColor = System.Drawing.Color.White;
            this.CityAnimationFileLabel.Location = new System.Drawing.Point(36, 308);
            this.CityAnimationFileLabel.Name = "CityAnimationFileLabel";
            this.CityAnimationFileLabel.Size = new System.Drawing.Size(254, 18);
            this.CityAnimationFileLabel.TabIndex = 12;
            this.CityAnimationFileLabel.Text = "[D] City Idle, Walk, Talk animation file:";
            // 
            // DungeonAnimationFileTextBox
            // 
            this.DungeonAnimationFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DungeonAnimationFileTextBox.Location = new System.Drawing.Point(39, 377);
            this.DungeonAnimationFileTextBox.Name = "DungeonAnimationFileTextBox";
            this.DungeonAnimationFileTextBox.ReadOnly = true;
            this.DungeonAnimationFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DungeonAnimationFileTextBox.Size = new System.Drawing.Size(648, 24);
            this.DungeonAnimationFileTextBox.TabIndex = 15;
            // 
            // DungeonAnimationFileLabel
            // 
            this.DungeonAnimationFileLabel.AutoSize = true;
            this.DungeonAnimationFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DungeonAnimationFileLabel.ForeColor = System.Drawing.Color.White;
            this.DungeonAnimationFileLabel.Location = new System.Drawing.Point(36, 356);
            this.DungeonAnimationFileLabel.Name = "DungeonAnimationFileLabel";
            this.DungeonAnimationFileLabel.Size = new System.Drawing.Size(184, 18);
            this.DungeonAnimationFileLabel.TabIndex = 14;
            this.DungeonAnimationFileLabel.Text = "[E] Dungeon animation file:";
            // 
            // Attack1FileTextBox
            // 
            this.Attack1FileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Attack1FileTextBox.Location = new System.Drawing.Point(39, 425);
            this.Attack1FileTextBox.Name = "Attack1FileTextBox";
            this.Attack1FileTextBox.ReadOnly = true;
            this.Attack1FileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Attack1FileTextBox.Size = new System.Drawing.Size(648, 24);
            this.Attack1FileTextBox.TabIndex = 17;
            // 
            // Attack1FileLabel
            // 
            this.Attack1FileLabel.AutoSize = true;
            this.Attack1FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Attack1FileLabel.ForeColor = System.Drawing.Color.White;
            this.Attack1FileLabel.Location = new System.Drawing.Point(36, 404);
            this.Attack1FileLabel.Name = "Attack1FileLabel";
            this.Attack1FileLabel.Size = new System.Drawing.Size(176, 18);
            this.Attack1FileLabel.TabIndex = 16;
            this.Attack1FileLabel.Text = "[F] Attack 1 animation file:";
            // 
            // Attack2FileTextBox
            // 
            this.Attack2FileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Attack2FileTextBox.Location = new System.Drawing.Point(39, 473);
            this.Attack2FileTextBox.Name = "Attack2FileTextBox";
            this.Attack2FileTextBox.ReadOnly = true;
            this.Attack2FileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Attack2FileTextBox.Size = new System.Drawing.Size(648, 24);
            this.Attack2FileTextBox.TabIndex = 19;
            // 
            // Attack2FileLabel
            // 
            this.Attack2FileLabel.AutoSize = true;
            this.Attack2FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Attack2FileLabel.ForeColor = System.Drawing.Color.White;
            this.Attack2FileLabel.Location = new System.Drawing.Point(36, 452);
            this.Attack2FileLabel.Name = "Attack2FileLabel";
            this.Attack2FileLabel.Size = new System.Drawing.Size(179, 18);
            this.Attack2FileLabel.TabIndex = 18;
            this.Attack2FileLabel.Text = "[G] Attack 2 animation file:";
            // 
            // Attack3FileTextBox
            // 
            this.Attack3FileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Attack3FileTextBox.Location = new System.Drawing.Point(39, 521);
            this.Attack3FileTextBox.Name = "Attack3FileTextBox";
            this.Attack3FileTextBox.ReadOnly = true;
            this.Attack3FileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.Attack3FileTextBox.Size = new System.Drawing.Size(648, 24);
            this.Attack3FileTextBox.TabIndex = 21;
            // 
            // Attack3FileLabel
            // 
            this.Attack3FileLabel.AutoSize = true;
            this.Attack3FileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.Attack3FileLabel.ForeColor = System.Drawing.Color.White;
            this.Attack3FileLabel.Location = new System.Drawing.Point(36, 500);
            this.Attack3FileLabel.Name = "Attack3FileLabel";
            this.Attack3FileLabel.Size = new System.Drawing.Size(178, 18);
            this.Attack3FileLabel.TabIndex = 20;
            this.Attack3FileLabel.Text = "[H] Attack 3 animation file:";
            // 
            // WinFileTextBox
            // 
            this.WinFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.WinFileTextBox.Location = new System.Drawing.Point(39, 569);
            this.WinFileTextBox.Name = "WinFileTextBox";
            this.WinFileTextBox.ReadOnly = true;
            this.WinFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.WinFileTextBox.Size = new System.Drawing.Size(648, 24);
            this.WinFileTextBox.TabIndex = 23;
            // 
            // WinFileLabel
            // 
            this.WinFileLabel.AutoSize = true;
            this.WinFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.WinFileLabel.ForeColor = System.Drawing.Color.White;
            this.WinFileLabel.Location = new System.Drawing.Point(36, 548);
            this.WinFileLabel.Name = "WinFileLabel";
            this.WinFileLabel.Size = new System.Drawing.Size(143, 18);
            this.WinFileLabel.TabIndex = 22;
            this.WinFileLabel.Text = "[I] Win animation file:";
            // 
            // GettingUpFileTextBox
            // 
            this.GettingUpFileTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.GettingUpFileTextBox.Location = new System.Drawing.Point(39, 617);
            this.GettingUpFileTextBox.Name = "GettingUpFileTextBox";
            this.GettingUpFileTextBox.ReadOnly = true;
            this.GettingUpFileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.GettingUpFileTextBox.Size = new System.Drawing.Size(648, 24);
            this.GettingUpFileTextBox.TabIndex = 25;
            // 
            // GettingUpFileLabel
            // 
            this.GettingUpFileLabel.AutoSize = true;
            this.GettingUpFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.GettingUpFileLabel.ForeColor = System.Drawing.Color.White;
            this.GettingUpFileLabel.Location = new System.Drawing.Point(36, 596);
            this.GettingUpFileLabel.Name = "GettingUpFileLabel";
            this.GettingUpFileLabel.Size = new System.Drawing.Size(189, 18);
            this.GettingUpFileLabel.TabIndex = 24;
            this.GettingUpFileLabel.Text = "[J] Getting up animation file:";
            // 
            // DeadAnimationTextBox
            // 
            this.DeadAnimationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DeadAnimationTextBox.Location = new System.Drawing.Point(39, 665);
            this.DeadAnimationTextBox.Name = "DeadAnimationTextBox";
            this.DeadAnimationTextBox.ReadOnly = true;
            this.DeadAnimationTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.DeadAnimationTextBox.Size = new System.Drawing.Size(648, 24);
            this.DeadAnimationTextBox.TabIndex = 27;
            // 
            // DeadAnimationFileLabel
            // 
            this.DeadAnimationFileLabel.AutoSize = true;
            this.DeadAnimationFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DeadAnimationFileLabel.ForeColor = System.Drawing.Color.White;
            this.DeadAnimationFileLabel.Location = new System.Drawing.Point(36, 644);
            this.DeadAnimationFileLabel.Name = "DeadAnimationFileLabel";
            this.DeadAnimationFileLabel.Size = new System.Drawing.Size(159, 18);
            this.DeadAnimationFileLabel.TabIndex = 26;
            this.DeadAnimationFileLabel.Text = "[K] Dead animation file:";
            // 
            // TexturePictureBox
            // 
            this.TexturePictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.TexturePictureBox.Location = new System.Drawing.Point(717, 84);
            this.TexturePictureBox.Name = "TexturePictureBox";
            this.TexturePictureBox.Size = new System.Drawing.Size(128, 256);
            this.TexturePictureBox.TabIndex = 28;
            this.TexturePictureBox.TabStop = false;
            // 
            // ClutPictureBox
            // 
            this.ClutPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClutPictureBox.Location = new System.Drawing.Point(717, 411);
            this.ClutPictureBox.Name = "ClutPictureBox";
            this.ClutPictureBox.Size = new System.Drawing.Size(16, 16);
            this.ClutPictureBox.TabIndex = 29;
            this.ClutPictureBox.TabStop = false;
            this.ToolTip.SetToolTip(this.ClutPictureBox, "Colour palettes that appear twice have alpha enabled on \r\nthe first occurance and" +
        " disabled on the second occurance.\r\n");
            // 
            // ExtractTextureButton
            // 
            this.ExtractTextureButton.BackColor = System.Drawing.Color.DimGray;
            this.ExtractTextureButton.Enabled = false;
            this.ExtractTextureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExtractTextureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ExtractTextureButton.Location = new System.Drawing.Point(559, 97);
            this.ExtractTextureButton.Name = "ExtractTextureButton";
            this.ExtractTextureButton.Size = new System.Drawing.Size(128, 32);
            this.ExtractTextureButton.TabIndex = 30;
            this.ExtractTextureButton.Text = "Extract Texture";
            this.ExtractTextureButton.UseVisualStyleBackColor = false;
            this.ExtractTextureButton.EnabledChanged += new System.EventHandler(this.ExtractTextureButton_EnabledChanged);
            this.ExtractTextureButton.Click += new System.EventHandler(this.ExtractTextureButton_Click);
            // 
            // ClutLabel
            // 
            this.ClutLabel.AutoSize = true;
            this.ClutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.ClutLabel.ForeColor = System.Drawing.Color.White;
            this.ClutLabel.Location = new System.Drawing.Point(714, 356);
            this.ClutLabel.Name = "ClutLabel";
            this.ClutLabel.Size = new System.Drawing.Size(90, 18);
            this.ClutLabel.TabIndex = 31;
            this.ClutLabel.Text = "CLUT scale:";
            // 
            // ClutScaleUpDown
            // 
            this.ClutScaleUpDown.Enabled = false;
            this.ClutScaleUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ClutScaleUpDown.Location = new System.Drawing.Point(717, 382);
            this.ClutScaleUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ClutScaleUpDown.Name = "ClutScaleUpDown";
            this.ClutScaleUpDown.Size = new System.Drawing.Size(42, 23);
            this.ClutScaleUpDown.TabIndex = 32;
            this.ClutScaleUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ClutScaleUpDown.ValueChanged += new System.EventHandler(this.ClutScaleUpDown_ValueChanged);
            // 
            // TextureScaledLabel
            // 
            this.TextureScaledLabel.AutoSize = true;
            this.TextureScaledLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.TextureScaledLabel.ForeColor = System.Drawing.Color.White;
            this.TextureScaledLabel.Location = new System.Drawing.Point(714, 32);
            this.TextureScaledLabel.Name = "TextureScaledLabel";
            this.TextureScaledLabel.Size = new System.Drawing.Size(100, 18);
            this.TextureScaledLabel.TabIndex = 33;
            this.TextureScaledLabel.Text = "Texture scale:";
            // 
            // TextureScaleUpDown
            // 
            this.TextureScaleUpDown.Enabled = false;
            this.TextureScaleUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.TextureScaleUpDown.Location = new System.Drawing.Point(717, 53);
            this.TextureScaleUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TextureScaleUpDown.Name = "TextureScaleUpDown";
            this.TextureScaleUpDown.Size = new System.Drawing.Size(42, 23);
            this.TextureScaleUpDown.TabIndex = 34;
            this.TextureScaleUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TextureScaleUpDown.ValueChanged += new System.EventHandler(this.TextureScaleUpDown_ValueChanged);
            // 
            // DrawUVsCheckbox
            // 
            this.DrawUVsCheckbox.AutoSize = true;
            this.DrawUVsCheckbox.Enabled = false;
            this.DrawUVsCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.DrawUVsCheckbox.ForeColor = System.Drawing.Color.White;
            this.DrawUVsCheckbox.Location = new System.Drawing.Point(766, 54);
            this.DrawUVsCheckbox.Name = "DrawUVsCheckbox";
            this.DrawUVsCheckbox.Size = new System.Drawing.Size(94, 22);
            this.DrawUVsCheckbox.TabIndex = 35;
            this.DrawUVsCheckbox.Text = "Draw UVs";
            this.DrawUVsCheckbox.UseVisualStyleBackColor = true;
            this.DrawUVsCheckbox.CheckedChanged += new System.EventHandler(this.DrawUVsCheckbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(930, 720);
            this.Controls.Add(this.DrawUVsCheckbox);
            this.Controls.Add(this.TextureScaleUpDown);
            this.Controls.Add(this.TextureScaledLabel);
            this.Controls.Add(this.ClutScaleUpDown);
            this.Controls.Add(this.ClutLabel);
            this.Controls.Add(this.ExtractTextureButton);
            this.Controls.Add(this.ClutPictureBox);
            this.Controls.Add(this.TexturePictureBox);
            this.Controls.Add(this.DeadAnimationTextBox);
            this.Controls.Add(this.DeadAnimationFileLabel);
            this.Controls.Add(this.GettingUpFileTextBox);
            this.Controls.Add(this.GettingUpFileLabel);
            this.Controls.Add(this.WinFileTextBox);
            this.Controls.Add(this.WinFileLabel);
            this.Controls.Add(this.Attack3FileTextBox);
            this.Controls.Add(this.Attack3FileLabel);
            this.Controls.Add(this.Attack2FileTextBox);
            this.Controls.Add(this.Attack2FileLabel);
            this.Controls.Add(this.Attack1FileTextBox);
            this.Controls.Add(this.Attack1FileLabel);
            this.Controls.Add(this.DungeonAnimationFileTextBox);
            this.Controls.Add(this.DungeonAnimationFileLabel);
            this.Controls.Add(this.CityAnimationFileTextBox);
            this.Controls.Add(this.CityAnimationFileLabel);
            this.Controls.Add(this.LargeDamageFileTextbox);
            this.Controls.Add(this.LargeDamageFileLabel);
            this.Controls.Add(this.SmallDamageTextBox);
            this.Controls.Add(this.SmallDamageFileLabel);
            this.Controls.Add(this.IdleFileTextBox);
            this.Controls.Add(this.IdleFileLabel);
            this.Controls.Add(this.ModelFileTextBox);
            this.Controls.Add(this.LoadedModelFilePathLabel);
            this.Controls.Add(this.SelectModelFileButton);
            this.Controls.Add(this.SelectModelFileLabel);
            this.Controls.Add(this.SelectModelTypeLabel);
            this.Controls.Add(this.ModelTypeComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TexturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClutPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ClutScaleUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TextureScaleUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ModelTypeComboBox;
        private System.Windows.Forms.Label SelectModelTypeLabel;
        private System.Windows.Forms.Label SelectModelFileLabel;
        private System.Windows.Forms.Button SelectModelFileButton;
        private System.Windows.Forms.Label LoadedModelFilePathLabel;
        private System.Windows.Forms.TextBox ModelFileTextBox;
        private System.Windows.Forms.TextBox IdleFileTextBox;
        private System.Windows.Forms.Label IdleFileLabel;
        private System.Windows.Forms.TextBox SmallDamageTextBox;
        private System.Windows.Forms.Label SmallDamageFileLabel;
        private System.Windows.Forms.TextBox LargeDamageFileTextbox;
        private System.Windows.Forms.Label LargeDamageFileLabel;
        private System.Windows.Forms.TextBox CityAnimationFileTextBox;
        private System.Windows.Forms.Label CityAnimationFileLabel;
        private System.Windows.Forms.TextBox DungeonAnimationFileTextBox;
        private System.Windows.Forms.Label DungeonAnimationFileLabel;
        private System.Windows.Forms.TextBox Attack1FileTextBox;
        private System.Windows.Forms.Label Attack1FileLabel;
        private System.Windows.Forms.TextBox Attack2FileTextBox;
        private System.Windows.Forms.Label Attack2FileLabel;
        private System.Windows.Forms.TextBox Attack3FileTextBox;
        private System.Windows.Forms.Label Attack3FileLabel;
        private System.Windows.Forms.TextBox WinFileTextBox;
        private System.Windows.Forms.Label WinFileLabel;
        private System.Windows.Forms.TextBox GettingUpFileTextBox;
        private System.Windows.Forms.Label GettingUpFileLabel;
        private System.Windows.Forms.TextBox DeadAnimationTextBox;
        private System.Windows.Forms.Label DeadAnimationFileLabel;
        private System.Windows.Forms.PictureBox TexturePictureBox;
        private System.Windows.Forms.PictureBox ClutPictureBox;
        private System.Windows.Forms.Button ExtractTextureButton;
        private System.Windows.Forms.Label ClutLabel;
        private System.Windows.Forms.NumericUpDown ClutScaleUpDown;
        private System.Windows.Forms.Label TextureScaledLabel;
        private System.Windows.Forms.NumericUpDown TextureScaleUpDown;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.CheckBox DrawUVsCheckbox;
    }
}

