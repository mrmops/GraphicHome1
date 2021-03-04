namespace WindowsFormsApp1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.driwerPanel = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.DrawButton = new System.Windows.Forms.Button();
            this.InitGraphicsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.figures = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rotationInputY = new System.Windows.Forms.TextBox();
            this.rotationInputX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rotateTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.scaleTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.driwerPanel)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.rotateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.scaleTrackBar)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.driwerPanel);
            this.groupBox1.Location = new System.Drawing.Point(139, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(485, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // driwerPanel
            // 
            this.driwerPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.driwerPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.driwerPanel.Location = new System.Drawing.Point(2, 15);
            this.driwerPanel.Margin = new System.Windows.Forms.Padding(2);
            this.driwerPanel.Name = "driwerPanel";
            this.driwerPanel.Size = new System.Drawing.Size(479, 550);
            this.driwerPanel.TabIndex = 0;
            this.driwerPanel.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.DrawButton);
            this.groupBox2.Controls.Add(this.InitGraphicsButton);
            this.groupBox2.Location = new System.Drawing.Point(6, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(125, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.UseCompatibleTextRendering = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(5, 56);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(112, 21);
            this.comboBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберете фигуру";
            // 
            // button3
            // 
            this.button3.AutoSize = true;
            this.button3.Location = new System.Drawing.Point(4, 166);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 31);
            this.button3.TabIndex = 2;
            this.button3.Text = "Стереть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnHideGraphicsClick);
            // 
            // DrawButton
            // 
            this.DrawButton.AutoSize = true;
            this.DrawButton.Enabled = false;
            this.DrawButton.Location = new System.Drawing.Point(4, 130);
            this.DrawButton.Margin = new System.Windows.Forms.Padding(2);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(117, 31);
            this.DrawButton.TabIndex = 1;
            this.DrawButton.Text = "Рисовать";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.OnDrawButtonClick);
            // 
            // InitGraphicsButton
            // 
            this.InitGraphicsButton.AutoSize = true;
            this.InitGraphicsButton.Location = new System.Drawing.Point(4, 95);
            this.InitGraphicsButton.Margin = new System.Windows.Forms.Padding(2);
            this.InitGraphicsButton.Name = "InitGraphicsButton";
            this.InitGraphicsButton.Size = new System.Drawing.Size(117, 31);
            this.InitGraphicsButton.TabIndex = 0;
            this.InitGraphicsButton.Text = "Включить графику";
            this.InitGraphicsButton.UseVisualStyleBackColor = true;
            this.InitGraphicsButton.Click += new System.EventHandler(this.OnInitGraphicsClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 569);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(761, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ошибки";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Location = new System.Drawing.Point(6, 226);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(125, 339);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Поля ввода";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.AutoSize = true;
            this.groupBox5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox5.Controls.Add(this.figures);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(122, 212);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Фигуры";
            // 
            // figures
            // 
            this.figures.FormattingEnabled = true;
            this.figures.Location = new System.Drawing.Point(8, 20);
            this.figures.Name = "figures";
            this.figures.Size = new System.Drawing.Size(108, 173);
            this.figures.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.AutoSize = true;
            this.groupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.comboBox2);
            this.groupBox6.Controls.Add(this.rotationInputY);
            this.groupBox6.Controls.Add(this.rotationInputX);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.rotateTrackBar);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.scaleTrackBar);
            this.groupBox6.Location = new System.Drawing.Point(1, 221);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(125, 272);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Настройки фигуры";
            // 
            // rotationInputY
            // 
            this.rotationInputY.Location = new System.Drawing.Point(8, 178);
            this.rotationInputY.Name = "rotationInputY";
            this.rotationInputY.Size = new System.Drawing.Size(108, 20);
            this.rotationInputY.TabIndex = 6;
            // 
            // rotationInputX
            // 
            this.rotationInputX.Location = new System.Drawing.Point(8, 155);
            this.rotationInputX.Name = "rotationInputX";
            this.rotationInputX.Size = new System.Drawing.Size(108, 20);
            this.rotationInputX.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Точка поворота";
            // 
            // rotateTrackBar
            // 
            this.rotateTrackBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.rotateTrackBar.LargeChange = 10;
            this.rotateTrackBar.Location = new System.Drawing.Point(6, 97);
            this.rotateTrackBar.Maximum = 360;
            this.rotateTrackBar.Name = "rotateTrackBar";
            this.rotateTrackBar.Size = new System.Drawing.Size(111, 45);
            this.rotateTrackBar.TabIndex = 3;
            this.rotateTrackBar.Scroll += new System.EventHandler(this.rotateTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Поворот";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Масштаб";
            // 
            // scaleTrackBar
            // 
            this.scaleTrackBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.scaleTrackBar.Location = new System.Drawing.Point(6, 49);
            this.scaleTrackBar.Maximum = 100;
            this.scaleTrackBar.Minimum = 10;
            this.scaleTrackBar.Name = "scaleTrackBar";
            this.scaleTrackBar.Size = new System.Drawing.Size(111, 45);
            this.scaleTrackBar.TabIndex = 0;
            this.scaleTrackBar.Value = 10;
            this.scaleTrackBar.Scroll += new System.EventHandler(this.scaleTrackBar_Scroll);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.groupBox4);
            this.groupBox7.Controls.Add(this.groupBox2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(137, 569);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSize = true;
            this.groupBox8.Controls.Add(this.groupBox6);
            this.groupBox8.Controls.Add(this.groupBox5);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox8.Location = new System.Drawing.Point(626, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(135, 569);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(9, 232);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(110, 21);
            this.comboBox2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 28);
            this.label5.TabIndex = 8;
            this.label5.Text = "Анимация перемещения";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(761, 625);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(664, 664);
            this.Name = "Form1";
            this.Text = "Drawer";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.driwerPanel)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.rotateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.scaleTrackBar)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox rotationInputX;
        private System.Windows.Forms.TextBox rotationInputY;

        private System.Windows.Forms.GroupBox groupBox8;

        private System.Windows.Forms.GroupBox groupBox7;

        private System.Windows.Forms.TrackBar rotateTrackBar;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar scaleTrackBar;

        private System.Windows.Forms.GroupBox groupBox6;

        private System.Windows.Forms.ListBox figures;
        private System.Windows.Forms.GroupBox groupBox5;

        private System.Windows.Forms.ComboBox comboBox1;

        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.PictureBox driwerPanel;

        private System.Windows.Forms.Button InitGraphicsButton;
        private System.Windows.Forms.Button DrawButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.Label label1;
        

        #endregion
    }
}