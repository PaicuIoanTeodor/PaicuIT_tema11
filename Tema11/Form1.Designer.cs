
namespace OpenTK3_StandardTemplate_WinForms
{
    partial class MainForm
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
            this.showAxes = new System.Windows.Forms.CheckBox();
            this.changeBackground = new System.Windows.Forms.Button();
            this.lblOx = new System.Windows.Forms.Label();
            this.lblOy = new System.Windows.Forms.Label();
            this.lblOz = new System.Windows.Forms.Label();
            this.resetScene = new System.Windows.Forms.Button();
            this.enableRotation = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // showAxes
            // 
            this.showAxes.AutoSize = true;
            this.showAxes.Checked = true;
            this.showAxes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showAxes.Location = new System.Drawing.Point(1534, 24);
            this.showAxes.Margin = new System.Windows.Forms.Padding(6);
            this.showAxes.Name = "showAxes";
            this.showAxes.Size = new System.Drawing.Size(138, 29);
            this.showAxes.TabIndex = 0;
            this.showAxes.Text = "Show Axes";
            this.showAxes.UseVisualStyleBackColor = true;
            this.showAxes.CheckedChanged += new System.EventHandler(this.showAxes_CheckedChanged);
            // 
            // changeBackground
            // 
            this.changeBackground.Location = new System.Drawing.Point(1534, 199);
            this.changeBackground.Margin = new System.Windows.Forms.Padding(6);
            this.changeBackground.Name = "changeBackground";
            this.changeBackground.Size = new System.Drawing.Size(367, 59);
            this.changeBackground.TabIndex = 1;
            this.changeBackground.Text = "Change background color";
            this.changeBackground.UseVisualStyleBackColor = true;
            this.changeBackground.Click += new System.EventHandler(this.changeBackground_Click);
            // 
            // lblOx
            // 
            this.lblOx.BackColor = System.Drawing.Color.Red;
            this.lblOx.Location = new System.Drawing.Point(1575, 65);
            this.lblOx.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOx.Name = "lblOx";
            this.lblOx.Size = new System.Drawing.Size(73, 37);
            this.lblOx.TabIndex = 2;
            this.lblOx.Text = "Ox";
            this.lblOx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOy
            // 
            this.lblOy.BackColor = System.Drawing.Color.Green;
            this.lblOy.Location = new System.Drawing.Point(1659, 65);
            this.lblOy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOy.Name = "lblOy";
            this.lblOy.Size = new System.Drawing.Size(73, 37);
            this.lblOy.TabIndex = 3;
            this.lblOy.Text = "Oy";
            this.lblOy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOz
            // 
            this.lblOz.BackColor = System.Drawing.Color.Blue;
            this.lblOz.Location = new System.Drawing.Point(1744, 65);
            this.lblOz.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblOz.Name = "lblOz";
            this.lblOz.Size = new System.Drawing.Size(73, 37);
            this.lblOz.TabIndex = 4;
            this.lblOz.Text = "Oz";
            this.lblOz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetScene
            // 
            this.resetScene.Location = new System.Drawing.Point(1534, 270);
            this.resetScene.Margin = new System.Windows.Forms.Padding(6);
            this.resetScene.Name = "resetScene";
            this.resetScene.Size = new System.Drawing.Size(367, 59);
            this.resetScene.TabIndex = 5;
            this.resetScene.Text = "Reset scene";
            this.resetScene.UseVisualStyleBackColor = true;
            this.resetScene.Click += new System.EventHandler(this.resetScene_Click);
            // 
            // enableRotation
            // 
            this.enableRotation.AutoSize = true;
            this.enableRotation.Location = new System.Drawing.Point(1534, 107);
            this.enableRotation.Margin = new System.Windows.Forms.Padding(6);
            this.enableRotation.Name = "enableRotation";
            this.enableRotation.Size = new System.Drawing.Size(232, 29);
            this.enableRotation.TabIndex = 6;
            this.enableRotation.Text = "Enable mouse rotation";
            this.enableRotation.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1534, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(367, 69);
            this.button1.TabIndex = 8;
            this.button1.Text = "Iluminare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.toggleLightingButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1534, 556);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(367, 81);
            this.button2.TabIndex = 9;
            this.button2.Text = "texturare";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.applyTextureButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1534, 456);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(367, 82);
            this.button3.TabIndex = 10;
            this.button3.Text = "Alpha Blending";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.toggleAlphaBlendingButton_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1534, 669);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(367, 80);
            this.button4.TabIndex = 11;
            this.button4.Text = "Miscare pe axa z";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.toggleMovementButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1923, 1152);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.enableRotation);
            this.Controls.Add(this.resetScene);
            this.Controls.Add(this.lblOz);
            this.Controls.Add(this.lblOy);
            this.Controls.Add(this.lblOx);
            this.Controls.Add(this.changeBackground);
            this.Controls.Add(this.showAxes);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Text = "OpenTK 3";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox showAxes;
        private System.Windows.Forms.Button changeBackground;
        private System.Windows.Forms.Label lblOx;
        private System.Windows.Forms.Label lblOy;
        private System.Windows.Forms.Label lblOz;
        private System.Windows.Forms.Button resetScene;
        private System.Windows.Forms.CheckBox enableRotation;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

